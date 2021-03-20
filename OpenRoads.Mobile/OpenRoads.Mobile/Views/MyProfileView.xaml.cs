using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenRoads.Mobile.Converters;
using OpenRoads.Mobile.Helpers;
using OpenRoads.Mobile.ViewModels;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfileView : ContentPage
    {
        private MyProfileViewModel model = null;

        private readonly APIService _clientService = new APIService("Client");

        private IPhotoPickerService _photoPickerService;

        public MyProfileView()
        {
            InitializeComponent();

            BindingContext = model = new MyProfileViewModel();


            backImage.Source = ImageSource.FromResource("OpenRoads.Mobile.Resources.backIcon.png");
            backImage.WidthRequest = 40;
            backImage.HeightRequest = 40;
            backImage.CornerRadius = 25;
            backImage.BackgroundColor = Color.White;

            SignOutBtn.Padding = new Thickness(3);
            SignOutBtn.CornerRadius = 3;


            //Register the photo picker service
            _photoPickerService = DependencyService.Get<IPhotoPickerService>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            await LoadClientProfilePicture();
            await Helper.LoadUserImage(_clientService, userImg);
        }

        private async Task LoadClientProfilePicture()
        {
            var client = await _clientService.GetById<ClientModel>(APIService.LoggedUserId);
            if (client != null)
            {
                if (client.ProfilePicture.Length != 0)
                {
                    ImageConverter converter = new ImageConverter();
                    UserImage.Source = (ImageSource) converter.Convert(client.ProfilePicture, null, null, null);
                    UserImage.WidthRequest = 400;
                }
                else
                {
                    UserImage.Source = ImageSource.FromResource("openRoads.Mobile.Resources.userAvatar.png");
                    UserImage.WidthRequest = 400;
                }
            }
        }

        private void BackImage_OnClicked(object sender, EventArgs e)
        {
            Helper.BackImageOnClick();   
        }

        private void UserImg_OnClicked(object sender, EventArgs e)
        {
            Helper.UserImgOnClick();
        }

        private void SignOutBtn_OnClicked(object sender, EventArgs e)
        {
            Helper.SignOut();
        }

        //if true enable user to edit his information, if false set entries to read only
        private void EnableEditMode(bool enable)
        {
            if (enable)
            {
                UploadProfilePictureBtn.IsVisible = true;
                SaveChangesBtn.IsVisible = true;
                CancelChangesBtn.IsVisible = true;

                EditProfileBtn.IsVisible = false;

                FirstNameEntry.IsReadOnly = false;
                LastNameEntry.IsReadOnly = false;
                DateOfBirthEntry.IsEnabled = true;
                PhoneNumberEntry.IsReadOnly = false;
                EmailEntry.IsReadOnly = false;
                AddressEntry.IsReadOnly = false;
                CityEntry.IsReadOnly = false;
                CountryPicker.IsEnabled = true;
                CountryPicker.IsVisible = true;
                CountryEntry.IsVisible = false;
                PasswordEntry.IsReadOnly = false;
                PasswordEntry.Text = "";
            }

            else
            {
                UploadProfilePictureBtn.IsVisible = false;
                SaveChangesBtn.IsVisible = false;
                CancelChangesBtn.IsVisible = false;

                EditProfileBtn.IsVisible = true;

                FirstNameEntry.IsReadOnly = true;
                LastNameEntry.IsReadOnly = true;
                DateOfBirthEntry.IsEnabled = false;
                PhoneNumberEntry.IsReadOnly = true;
                EmailEntry.IsReadOnly = true;
                AddressEntry.IsReadOnly = true;
                CityEntry.IsReadOnly = true;
                CountryPicker.IsEnabled = false;
                CountryPicker.IsVisible = false;
                CountryEntry.IsVisible = true;
                PasswordEntry.IsReadOnly = true;
                PasswordEntry.Text = "*****";
            }
        }

        private void EditProfileBtn_OnClicked(object sender, EventArgs e)
        {
            EnableEditMode(true);
        }

        private async void UploadProfilePictureBtn_OnClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await _photoPickerService.GetImageStreamAsync();
            if (stream != null)
            {
                UserImage.Source = ImageSource.FromStream(() => stream);

                byte[] userProfilePic = stream.ReadAllBytes();


                ClientUpdateRequest request = new ClientUpdateRequest();
                request.ProfilePicture = userProfilePic;
                if (await _clientService.Update<ClientModel>(APIService.LoggedUserId, request) != null)
                {
                    await LoadClientProfilePicture();
                    await Helper.LoadUserImage(_clientService, userImg);
                    await model.Init();
                    await DisplayAlert("Success", "Profile picture successfully added!", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Unexpected error has occured. Please try again later!", "OK");
                }
            }

            (sender as Button).IsEnabled = true;

        }

        private async void SaveChangesBtn_OnClicked(object sender, EventArgs e)
        {
            bool errorExists = false;

            //Check if entry is null or empty
            if (string.IsNullOrWhiteSpace(FirstNameEntry.Text) || string.IsNullOrWhiteSpace(LastNameEntry.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumberEntry.Text)
                || string.IsNullOrWhiteSpace(EmailEntry.Text) || string.IsNullOrWhiteSpace(AddressEntry.Text) ||
                string.IsNullOrWhiteSpace(CityEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text) 
                || CountryPicker.SelectedItem == null)
            {
                errorExists = true;
                await DisplayAlert("Warning", "Please fill in all fields!", "OK");
            }


            //Password validation
            if (!errorExists)
            {
                bool lowerCase = false, upperCase = false, numberExists = false;
                string charArr = PasswordEntry.Text;

                for (int i = 0; i < PasswordEntry.Text.Length; i++)
                {
                    if (charArr[i] >= 'A' && charArr[i] <= 'Z')
                        upperCase = true;
                    if (charArr[i] >= 'a' && charArr[i] <= 'z')
                        lowerCase = true;
                    if (charArr[i] >= 48 && charArr[i] <= 57)
                        numberExists = true;
                }

                if (!lowerCase || !upperCase || !numberExists)
                {
                    errorExists = true;
                    await DisplayAlert("Warning",
                        "Password must be from 5-25 characters and must include A-a and Number!", "OK");
                }

                if (!errorExists && PasswordEntry.Text.Length < 5)
                {
                    errorExists = true;
                    await DisplayAlert("Warning",
                        "Password must be from 5-25 characters and must include A-a and Number!", "OK");
                }
            }

            //Email validation
            if (!errorExists && !EmailEntry.Text.Contains("@"))
            {
                errorExists = true;
                await DisplayAlert("Warning", "Please enter valid email address!", "OK");
            }

            //Date of birth validation (18 < DoB < 1940 year)
            if (!errorExists)
            {
                var date = DateOfBirthEntry.Date.ToString("dd.MM.yyyy");
                int day, month, year;
                var dateParts = date.Split('.');
                day = int.Parse(dateParts[0]);
                month = int.Parse(dateParts[1]);
                year = int.Parse(dateParts[2]);

                int daysCount = 0;
                if ((DateTime.Today.Year - year) > 18)
                    daysCount = ((DateTime.Today.Year - year) * 365) + (month * 30) + day;
                if ((DateTime.Today.Year - year) == 18 && DateTime.Today.Month > month)
                    daysCount = (18 * 365) + (month * 30) + day;
                if ((DateTime.Today.Year - year) == 18 && DateTime.Today.Month == month && DateTime.Today.Day >= day)
                    daysCount = (18 * 365) + (month * 30) + day;
                if ((DateTime.Today.Year - year) == 18 && DateTime.Today.Month < month)
                    daysCount = (17 * 365) + (month * 30) + day;
                if ((DateTime.Today.Year - year) == 18 && DateTime.Today.Month == month && DateTime.Today.Day < day)
                    daysCount = (17 * 365) + (month * 30) + day;
               

                if (daysCount <= 6570 || year < 1940)
                {
                    errorExists = true;
                    await DisplayAlert("Warning", "You have to be over 18 to register or birth year under 1940!", "OK");
                }
            }

            //If everything valid
            if (!errorExists)
            {
                CountryModel selectedCountry = (CountryModel)CountryPicker.SelectedItem;

                ClientUpdateRequest request = new ClientUpdateRequest();
                request.Username = UsernameEntry.Text;
                request.DateOfBirth = DateOfBirthEntry.Date;
                request.Email = EmailEntry.Text;
                request.Active = true;
                request.FirstName = FirstNameEntry.Text;
                request.LastName = LastNameEntry.Text;
                request.PhoneNumber = PhoneNumberEntry.Text;
                request.Address = AddressEntry.Text;
                request.City = CityEntry.Text;
                request.CleasPassword = PasswordEntry.Text;
                request.RegistrationDate = RegistrationDateEntry.Date;
                request.CountryId = selectedCountry.CountryId;

                var clientUpdated = await _clientService.Update<ClientModel>(APIService.LoggedUserId, request);

                //If success
                if (clientUpdated != null)
                {
                    await DisplayAlert("Success", "Successfully updated!", "OK");
                    EnableEditMode(false);
                    await model.Init();
                }
            }

        }

        private async void CancelChangesBtn_OnClicked(object sender, EventArgs e)
        {
            if(await DisplayAlert("Warning", "Are you sure you want to cancel without saving changes?", "Yes", "No"))
                EnableEditMode(false);
        }

       
    }
}