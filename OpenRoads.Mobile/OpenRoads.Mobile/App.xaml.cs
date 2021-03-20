using System;
using OpenRoads.Mobile.Services;
using OpenRoads.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenRoads.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LandingPageView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
