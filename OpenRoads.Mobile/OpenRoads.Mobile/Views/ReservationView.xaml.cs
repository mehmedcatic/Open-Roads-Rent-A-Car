using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenRoads.Mobile;
using OpenRoads.Mobile.Helpers;
using OpenRoads.Mobile.ViewModels;
using OpenRoads.Model;
using Stripe;
using Stripe.Issuing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationView : ContentPage
    {
        private ReservationViewModel model = null;

        private int _vehicleId;
        private DateTime _startDate;
        private DateTime _endDate;

        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _clientService = new APIService("Client");

        public ReservationView(int vehicleId, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();

            _vehicleId = vehicleId;
            _startDate = startDate;
            _endDate = endDate;

            BindingContext = model = new ReservationViewModel(_vehicleId, _startDate, _endDate);

            
            backImage.Source = ImageSource.FromResource("OpenRoads.Mobile.Resources.backIcon.png");
            backImage.WidthRequest = 40;
            backImage.HeightRequest = 40;
            backImage.CornerRadius = 25;
            backImage.BackgroundColor = Color.White;

            SignOutBtn.Padding = new Thickness(3);
            SignOutBtn.CornerRadius = 3;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            await Helper.LoadUserImage(_clientService, userImg);
        }

        private void SignOutBtn_OnClicked(object sender, EventArgs e)
        {
            Helper.SignOut();
        }

        private void UserImg_OnClicked(object sender, EventArgs e)
        {
            Helper.UserImgOnClick();
        }

        private void BackImage_OnClicked(object sender, EventArgs e)
        {
            Helper.BackImageOnClick();
        }


        //On change of the insurance type
        private async void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var insurance = (InsuranceModel) InsurancePicker.SelectedItem;
            int daysDiff = 0;


            //If months of the reservation are the same
            if (_startDate.Year == _endDate.Year && _startDate.Month == _endDate.Month)
                daysDiff = _endDate.Day - _startDate.Day + 1;


            //If months are different, such as 22.3. - 10.4.
            if (_startDate.Year == _endDate.Year && _startDate.Month < _endDate.Month)
            {
                var daysInMonth = DateTime.DaysInMonth(_startDate.Year, _startDate.Month);
                var counter = 0;
                //Calculate the days in the month above, for 10.4. --> i = 0; i < 10
                for (int i = 0; i < _endDate.Day; i++)
                {
                    counter++;
                }

                //For the lower month, start from the last day of the month, then go down to the startDate day
                for (int i = daysInMonth; i >= _startDate.Day; i--)
                {
                    counter++;
                }

                daysDiff = counter;
            }

            var vehicle = await _vehicleService.GetById<Model.VehicleModel>(_vehicleId);
            var totalPrice = (daysDiff * vehicle.PriceByDay) + insurance.Price;
            var vehiclePrice = daysDiff * vehicle.PriceByDay;
            
            model.TotalPrice = $"{totalPrice}KM";
            model.VehicleRentalPrice = $"{vehiclePrice}KM";
            model.InsurancePrice = $"{insurance.Price}KM";

        }

        //Validate inputs before submiting
        private async void Button_OnClicked(object sender, EventArgs e)
        {
            bool valid = true;
            if (model.SelectedInsuranceType == null)
            {
                await DisplayAlert("Warning", "Please select insurance type!", "OK");
                valid = false;
            }
            if (valid && !inPersonCB.IsChecked && !creditCardCB.IsChecked)
            {
                await DisplayAlert("Warning", "Please select payment option!", "OK");
                valid = false;
            }

            if (valid && inPersonCB.IsChecked && creditCardCB.IsChecked)
            {
                await DisplayAlert("Warning", "Please select only one payment option!", "OK");
                valid = false;
            }

            if (valid && creditCardCB.IsChecked)
            {
                if (string.IsNullOrWhiteSpace(ExpiryMonthEntry.Text) ||
                    string.IsNullOrWhiteSpace(ExpiryYearEntry.Text) || string.IsNullOrWhiteSpace(CVCEntry.Text)
                    || string.IsNullOrWhiteSpace(CCNumberEntry.Text))
                {
                    await DisplayAlert("Warning", "Please input all credit card information!", "OK");
                    valid = false;
                }

                if (valid && !validateCreditCardInfo())
                {
                    await DisplayAlert("Warning", "Please input valid credit card data!", "OK");
                    valid = false;
                }
            }

            //If every input valid
            if (valid)
            {
                model.CreateReservationCommand.Execute(null);

                //Created a payment service using STRIPE plugin
                if (!inPersonCB.IsChecked)
                {
                    CancellationTokenSource tokenSource = new CancellationTokenSource();
                    CancellationToken token = tokenSource.Token;

                    //Create new token
                    var Token = CreateToken();

                    if (Token != null)
                    {
                        //If token created proceed to payment
                        MakePayment(Token);
                    }
                    else
                    {
                        await DisplayAlert("Warning", "Something went wrong... Please try again later!", "OK");
                    }
                }

               
            }
        }

        private TokenService Tokenservice;
        private Token stripeToken;
        private string StripeTestApiKey = "pk_test_51IVMgHL2mA4sjL4DRy2L5lHRBoT8DUxuIDq0gtLYYPADSgS4bxwYKEsNWtEWL5W2aBj3PRP7VZ2AFzCHiDwlZ4Us002omrXQ4c";

        private string CreateToken()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeTestApiKey;
                var service = new ChargeService();
                var Tokenoptions = new TokenCreateOptions
                {
                    Card = new CreditCardOptions
                    {
                        Number = CCNumberEntry.Text,
                        ExpYear = long.Parse(ExpiryYearEntry.Text),
                        ExpMonth = long.Parse(ExpiryMonthEntry.Text),
                        Cvc = CVCEntry.Text
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            { 
                DisplayAlert("Warning", "Something went wrong... Please try again later!", "OK");
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        //All of the information below is for test purposes only and it's not set to represent the actual payment process.
        public bool MakePayment(string token)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51IVMgHL2mA4sjL4DlGKctDWkZBf5I9TEsrxZcjF7R3OxFEkPEhA6HwjFUhbEU6C8MXkDrsccbuR4TnIJSoxuarqe00PvgDmaQp";
                var options = new ChargeCreateOptions
                {
                    Amount = (long)float.Parse("20000"),
                    Currency = "usd",
                    Description = "Charge for Jon.rosen@example.com",
                    Source = stripeToken.Id,
                    StatementDescriptor = "Custom descriptor",
                    Capture = true,
                    ReceiptEmail = "mcatic1402@gmail.com",
                };
                //Make Payment
                var service = new ChargeService();
                Charge charge = service.Create(options);
                return true;
            }
            catch (Exception ex)
            { 
                DisplayAlert("Warning", "Something went wrong... Please try again later!", "OK");
                Console.Write("Payment Gatway (CreateCharge)" + ex.Message);
                throw ex;
            }
        }

        private bool validateCreditCardInfo()
        {
            try
            {
                if (ExpiryMonthEntry.Text.Length != 2) return false;
                if (ExpiryYearEntry.Text.Length != 2) return false;
                if (CVCEntry.Text.Length > 4 || CVCEntry.Text.Length < 3) return false;
                if (CCNumberEntry.Text.Length < 12 || CCNumberEntry.Text.Length > 16) return false;


                if (!int.TryParse(ExpiryYearEntry.Text, out int yearInt)) return false;
                if(!int.TryParse(ExpiryMonthEntry.Text, out int monthInt)) return false;
                if(!int.TryParse(CVCEntry.Text, out int cvvInt)) return false;

                yearInt += 2000;

                if (yearInt < DateTime.Now.Year)
                    return false;
                if (yearInt > DateTime.Now.AddYears(16).Year)
                    return false;
                if (yearInt == DateTime.Now.Year && monthInt < DateTime.Now.Month)
                    return false;
                if (monthInt < 1 || monthInt > 12)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private void CreditCardCB_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (creditCardCB.IsChecked == true)
            {
                stackLayoutForCC.IsVisible = true;
            }
            else
            {
                stackLayoutForCC.IsVisible = false;
            }
        }


    }
}