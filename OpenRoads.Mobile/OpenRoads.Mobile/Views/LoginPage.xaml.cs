using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenRoads.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LandingPageView();
        }
    }
}