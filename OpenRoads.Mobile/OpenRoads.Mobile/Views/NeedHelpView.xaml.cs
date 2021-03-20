using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenRoads.Mobile.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NeedHelpView : ContentPage
    {
        private readonly APIService _clientService = new APIService("Client");

        public NeedHelpView()
        {
            InitializeComponent();

            LogoImg.Source = ImageSource.FromResource("OpenRoads.Mobile.Resources.myLOGO.png");
            LogoImg.WidthRequest = 300;
            LogoImg.HeightRequest = 300;

            backImage.Source = ImageSource.FromResource("OpenRoads.Mobile.Resources.backIcon.png");
            backImage.WidthRequest = 40;
            backImage.HeightRequest = 40;
            backImage.CornerRadius = 25;
            backImage.BackgroundColor = Color.White;

            SignOutBtn.Padding = new Thickness(3);
            SignOutBtn.CornerRadius = 3;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Helper.LoadUserImage(_clientService, userImg);
        }

        private void UserImg_OnClicked(object sender, EventArgs e)
        {
            Helper.UserImgOnClick();
        }

        private void SignOutBtn_OnClicked(object sender, EventArgs e)
        {
            Helper.SignOut();
        }

        private void BackImage_OnClicked(object sender, EventArgs e)
        {
            Helper.BackImageOnClick();
        }



        private async void SubmitQuestionBtn_OnClicked(object sender, EventArgs e)
        {
            bool valid = true;
            if (string.IsNullOrWhiteSpace(QuestionEntry.Text))
            {
                await DisplayAlert("Warning", "Please write a question before submiting!", "OK");
                valid = false;
            }

            if (valid)
            {
                try
                {
                    var subject = "Question from customer";
                    List<string> toAddress = new List<string>();
                    toAddress.Add("openroads001@gmail.com");

                    await SendEmail(subject, QuestionEntry.Text, toAddress);
                    Application.Current.MainPage = new VehicleOfferView();
                }
                catch (Exception exception)
                {
                    await DisplayAlert("Error", "Ooops, something went wrong.. Please try again later!", "OK");
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        //Sending email through phone's email app, using Xamarin.Essentials
        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device  
                await DisplayAlert("Warning", "Email is not supported on this device!", "OK");
            }
            catch (Exception ex)
            {
                // Some other exception occurred  
                await DisplayAlert("Error", "Ooops, something went wrong.. Please try again later!", "OK");
            }
        }
    }
}