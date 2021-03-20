using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenRoads.Mobile;
using OpenRoads.Mobile.ViewModels;
using OpenRoads.Model;
using Xamarin.Forms;

namespace OpenRoads.Mobile.ViewModels
{
    public class MyProfileViewModel : BaseViewModel
    {
        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _personService = new APIService("Person");
        private readonly APIService _loginDataService = new APIService("LoginData");
        private readonly APIService _countryService = new APIService("Country");


        public MyProfileViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }


        public ObservableCollection<CountryModel> CountryList { get; set; } = new ObservableCollection<CountryModel>();


        string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        string _email;
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

        string _address;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        string _city;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private CountryModel _selectedCountryModel = null;
        public CountryModel SelectedCountryModel
        {
            get { return _selectedCountryModel; }
            set
            {
                SetProperty(ref _selectedCountryModel, value);
            }
        }

        string _countryString;
        public string CountryString
        {
            get { return _countryString; }
            set { SetProperty(ref _countryString, value); }
        }

        DateTime _registrationDate;
        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { SetProperty(ref _registrationDate, value); }

        }

        byte[] _clientProfilePicture;
        public byte[] ClientProfilePicture
        {
            get { return _clientProfilePicture; }
            set { SetProperty(ref _clientProfilePicture, value); }
        }



        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            try
            {
                var client = await _clientService.GetById<ClientModel>(APIService.LoggedUserId);
                var person = await _personService.GetById<PersonModel>(client.PersonId);
                var loginData = await _loginDataService.GetById<LoginDataModel>(person.LoginDataId);
                var country = await _countryService.GetById<CountryModel>(person.CountryId);

                var countries = await _countryService.Get<List<CountryModel>>(null);

                foreach (var x in countries)
                {
                    CountryList.Add(x);
                }

                FirstName = person.FirstName;
                LastName = person.LastName;
                PhoneNumber = person.PhoneNumber;
                Email = person.Email;
                DateOfBirth = person.DateOfBirth;
                Address = person.Address;
                City = person.City;
                Username = loginData.Username;
                Password = "*****";
                SelectedCountryModel = country;
                CountryString = country.Name;
                RegistrationDate = client.RegistrationDate;
                ClientProfilePicture = client.ProfilePicture;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

    }
}
