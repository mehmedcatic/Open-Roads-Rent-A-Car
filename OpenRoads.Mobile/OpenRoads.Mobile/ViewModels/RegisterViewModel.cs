using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenRoads.Mobile;
using OpenRoads.Mobile.ViewModels;
using OpenRoads.Mobile.Views;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using Xamarin.Forms;

namespace OpenRoads.Mobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _countryService = new APIService("Country");

        public RegisterViewModel()
        {
            InitCommand = new Command(async () => await Init());
            RegisterCommand = new Command(async () => await Register());
        }

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        DateTime _registrationDate;
        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { SetProperty(ref _registrationDate, value); }
        }

        string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        string _phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { SetProperty(ref _dateOfBirth, value); }
        }

        string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        string _city = string.Empty;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }


        public ObservableCollection<CountryModel> CountryList { get; set; } =
            new ObservableCollection<CountryModel>();

        CountryModel _selectedCountryModel = null;
        public CountryModel SelectedCountryModel
        {
            get { return _selectedCountryModel; }
            set
            {
                SetProperty(ref _selectedCountryModel, value);
             
            }
        }



        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            APIService.Username = "adminDesktop";
            APIService.Password = "test";

            var countries = await _countryService.Get<List<CountryModel>>(null);

            foreach (var x in countries)
            {
                CountryList.Add(x);
            }
        }


        public ICommand RegisterCommand { get; set; }


        private bool ValidateDoB(DateTime dateObj)
        {
            if (DateTime.Now.Year - dateObj.Year < 18)
                return false;
            if (DateTime.Now.Year - dateObj.Year == 18 && DateTime.Now.Month > dateObj.Month)
                return false;
            if (DateTime.Now.Year - dateObj.Year == 18 && DateTime.Now.Month == dateObj.Month && DateTime.Now.Day > dateObj.Day)
                return false;
            if (dateObj.Year < 1940)
                return false;
            return true;
        }

        private bool ValidatePassword(string password)
        {
            if (password.Length < 5)
                return false;

            bool containsSmallLetter = false, containsCapLett = false, containsDigit = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'A' && password[i] <= 'Z')
                {
                    containsCapLett = true;
                }

                if (password[i] >= 'a' && password[i] <= 'z')
                {
                    containsSmallLetter = true;
                }

                if (password[i] >= 48 && password[i] <= 57)
                {
                    containsDigit = true;
                }
            }

            if (!containsSmallLetter || !containsCapLett || !containsDigit)
            {
                return false;
            }

            return true;
        }
        public async Task Register()
        {
            IsBusy = true;
            APIService.Username = "adminDesktop";
            APIService.Password = "test";

            if(string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Address) || string.IsNullOrWhiteSpace(City) ||
               string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email) ||
               string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(PhoneNumber) ||
               SelectedCountryModel == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all fields!", "OK");
                IsBusy = false;
            }
            else if (!ValidateDoB(DateOfBirth))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You have to be over 18 and birth year higher than 1940 in order to register!", "OK");
                IsBusy = false;
            }
            else if(!ValidatePassword(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Password must contain upper-lower case letters and digits!", "OK");
                IsBusy = false;
            }
            else if (!Email.Contains("@"))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please input valid e-mail address!", "OK");
                IsBusy = false;
            }
            else
            {
                try
                {
                    ClientUpdateRequest request = new ClientUpdateRequest
                    {
                        Username = Username,
                        Active = true,
                        Address = Address,
                        City = City,
                        CleasPassword = Password,
                        CountryId = SelectedCountryModel.CountryId,
                        DateOfBirth = DateOfBirth,
                        Email = Email,
                        FirstName = FirstName,
                        LastName = LastName,
                        PhoneNumber = PhoneNumber,
                        RegistrationDate = DateTime.Now
                    };
                    var obj = await _clientService.Insert<dynamic>(request);

                    if (obj == null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error",
                            "Username or Email already exists, try another one!", "OK");
                        IsBusy = false;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Success!",
                            "Your account has been successfully created!", "OK");
                        Application.Current.MainPage = new LoginPage();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    IsBusy = false;
                }
            }
            
        }
    }
}
