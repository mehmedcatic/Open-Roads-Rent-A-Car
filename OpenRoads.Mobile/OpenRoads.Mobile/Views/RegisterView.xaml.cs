using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenRoads.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterView : ContentPage
    {
        private RegisterViewModel model = null;

        public RegisterView()
        {
            InitializeComponent();
            BindingContext = model = new RegisterViewModel();

            BackButton.Margin = new Thickness(0,5,0,0);
            SubmitButton.Margin = new Thickness(0, 5, 0, 0);
            DoBDate.MinimumDate = new DateTime(1940,1,1);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void BackButton_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LandingPageView();
        }
    }
}