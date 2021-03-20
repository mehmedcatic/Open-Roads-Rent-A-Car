using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using OpenRoads.Mobile.Helpers;
using OpenRoads.Mobile.ViewModels;
using OpenRoads.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace OpenRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehicleOfferView : ContentPage
    {
        private VehicleOfferViewModel model = null;

        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _personService = new APIService("Person");

        public VehicleOfferView()
        {
            InitializeComponent();
            BindingContext = model = new VehicleOfferViewModel();

            StartDate.MinimumDate = DateTime.Now;
            EndDate.MinimumDate = DateTime.Now;

            StartDateLabel.Padding = new Thickness(0, 0, 10, 0);
            EndDateLabel.Padding = new Thickness(0, 0, 15, 0);

            SignOutBtn.Padding = new Thickness(3);
            SignOutBtn.CornerRadius = 3;


        }

        public VehicleOfferView(string msg = null, ReservationModel reservationModel = null)
        {
            InitializeComponent();
            BindingContext = model = new VehicleOfferViewModel();

            StartDate.MinimumDate = DateTime.Now;
            EndDate.MinimumDate = DateTime.Now;

            StartDateLabel.Padding = new Thickness(0, 0, 10, 0);
            EndDateLabel.Padding = new Thickness(0, 0, 15, 0);

            SignOutBtn.Padding = new Thickness(3);
            SignOutBtn.CornerRadius = 3;

            if (msg != null)
            {
                DisplayAlert("Success", "Your reservation has been successfully created! Check your e-mail for additional info.", "OK");
                SendEmail(reservationModel);
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if (model.RecommendedVehiclesList.Count == 0)
                RecommendedVehiclesStackLayout.IsVisible = false;
            else
            {
                RecommendedVehiclesStackLayout.IsVisible = true;
                if (model.RecommendedVehiclesList.Count == 1)
                    RecommendedVehiclesStackLayout.HeightRequest = 260;
                if (model.RecommendedVehiclesList.Count == 2)
                    RecommendedVehiclesStackLayout.HeightRequest = 515;
                if (model.RecommendedVehiclesList.Count == 3)
                    RecommendedVehiclesStackLayout.HeightRequest = 770;
            }
            await Helper.LoadUserImage(_clientService, userImg);
        }

        
        //In order for this to work, you need to enable less secure apps access in your gmail account from which you're using smtp!
        //In this case we need to enable it for this account: openroads001@gmail.com
        //In order to do so visit this link: https://myaccount.google.com/lesssecureapps
        private async void SendEmail(ReservationModel reservationModel)
        {
            var client = await _clientService.GetById<ClientModel>(APIService.LoggedUserId);
            var person = await _personService.GetById<PersonModel>(client.PersonId);

            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("openroads001@gmail.com");
                mail.To.Add(person.Email);
                mail.Subject = "Reservation confirmation";
                mail.Body = "Your reservation has been successfully created! If you need additional info please contact our customer service at " +
                            "openroads001@gmail.com";
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("openroads001@gmail.com", "openROADS1");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }


        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (StartDate.Date >= EndDate.Date)
            {
                await DisplayAlert("Warning", "Please select valid dates for the reservation!", "OK");
            }
            else
            {
                Xamarin.Forms.Button btn = sender as Button;
                if (int.TryParse(btn.AutomationId, out int vehicleId))
                    Application.Current.MainPage = new ReservationView(vehicleId, StartDate.Date, EndDate.Date);
            }
            

        }


        private void UserImg_OnClicked(object sender, EventArgs e)
        {
            Helper.UserImgOnClick();

        }

        private void SignOutBtn_OnClicked(object sender, EventArgs e)
        {
            Helper.SignOut();
        }

        private void NeedHelpBtn_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NeedHelpView();
        }

        private bool IsReservationLongerThan28Days()
        {
            var startDate = StartDate.Date;
            var endDate = EndDate.Date;

            var daysCounter = 0;

            if (startDate.Year < endDate.Year)
            {
                if (startDate.Month == 12 && endDate.Month == 1)
                {
                    var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
                 
                    for (int i = 0; i < endDate.Day; i++)
                    {
                        daysCounter++;
                    }

                    for (int i = daysInMonth; i >= startDate.Day; i--)
                    {
                        daysCounter++;
                    }

                    if (daysCounter > 28)
                        return true;
                }

                else
                    return true;
            }

            if (startDate.Year == endDate.Year && startDate.Month == endDate.Month)
            {
                for (int i = startDate.Day; i < endDate.Day; i++)
                {
                    daysCounter++;
                }

                if (daysCounter > 28)
                    return true;
            }

            if (startDate.Year == endDate.Year && startDate.Month < endDate.Month)
            {
                if ((endDate.Month - startDate.Month) > 1)
                    return true;

                var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

                for (int i = 0; i < endDate.Day; i++)
                {
                    daysCounter++;
                }

                for (int i = daysInMonth; i >= startDate.Day; i--)
                {
                    daysCounter++;
                }

                if (daysCounter > 28)
                    return true;
            }

            return false;
        }

        private void StartDate_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            model.SelectedDateFrom = StartDate.Date;
            OnAppearing();
        }

        private async void EndDate_OnDateSelected(object sender, DateChangedEventArgs e)
        {
          
            if (StartDate.Date > EndDate.Date)
            {
                await DisplayAlert("Warning", "Start date can't be higher or equal than the end date!", "OK");
                StartDate.Date = DateTime.Now;
            }

            if (IsReservationLongerThan28Days())
            {
                await DisplayAlert("Alert", "If you need a vehicle rented for a period of more than 28 days contact out Customer Services office!", "OK");
                StartDate.Date = DateTime.Now;
                EndDate.Date = DateTime.Now;
            }
            else
            {
                model.SelectedDateTo = EndDate.Date;
                OnAppearing();
            }
        }

    }
}