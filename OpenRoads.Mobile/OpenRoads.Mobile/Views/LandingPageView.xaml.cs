using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPageView : ContentPage
    {
       
        public LandingPageView()
        {
            InitializeComponent();

            //Set the background image
            backgroundImage.Source = ImageSource.FromResource("OpenRoads.Mobile.Resources.road.jpg");
            backgroundImage.Aspect = Aspect.AspectFill;
            backgroundImage.Opacity = 0.6;
        }


        private void SignIn_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }

        private void Register_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegisterView();
        }

    }
}