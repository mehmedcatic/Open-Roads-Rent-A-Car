using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenRoads.Mobile.Converters;
using OpenRoads.Mobile.Views;
using OpenRoads.Model;
using Xamarin.Forms;

namespace OpenRoads.Mobile.Helpers
{
    public static class Helper
    {
        public static async void SignOut()
        {
            //When we log out APIService.LoggedUserId will be set to 0, or nonexistent ---> check LoginViewModel -> Login() method for detailed info
            if (await Application.Current.MainPage.DisplayAlert("Warning", "Are you sure you want to log out?", "Yes", "No"))
            {
                APIService.LoggedUserId = 0;
                Application.Current.MainPage = new LandingPageView();
            }
        }

        public static void BackImageOnClick()
        {
            Application.Current.MainPage = new VehicleOfferView();
        }

        public static void UserImgOnClick()
        {
            Application.Current.MainPage = new MyProfileTabbedView();
        }


        //Load user image to small ButtonImage in navigation bar
        public static async Task LoadUserImage(APIService _service, ImageButton userImg)
        {
            //Get the logged user
            ClientModel user = await _service.GetById<ClientModel>(APIService.LoggedUserId);
            if (user != null)
            {
                //Check if user has a profile pic uploaded, if so set it to userImg btnImage
                if (user.ProfilePicture.Length != 0)
                {
                    ImageConverter converter = new ImageConverter();
                    userImg.Source = (ImageSource)converter.Convert(user.ProfilePicture, null, null, null);
                    userImg.HeightRequest = 45;
                    userImg.CornerRadius = 25;
                }
                else
                {
                    //If profile pic isn't uploaded set the image to static resource image for nonexistent images
                    userImg.Source = ImageSource.FromResource("OpenRoads.Mobile.Resources.userAvatar.png");
                    userImg.HeightRequest = 45;
                    userImg.CornerRadius = 25;
                }
            }
        }
    }
}
