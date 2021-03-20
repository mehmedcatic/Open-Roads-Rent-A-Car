using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenRoads.Mobile.Helpers;
using OpenRoads.Mobile.ViewModels;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewView : ContentPage
    {
        private ReviewViewModel model = null;

        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _ratingService = new APIService("Rating");

        private int _reservationId;

        public ReviewView(int reservationId)
        {
            InitializeComponent();

            _reservationId = reservationId;

            BindingContext = model = new ReviewViewModel(_reservationId);



            backImage.Source = ImageSource.FromResource("OpenRoads.Mobile.Resources.backIcon.png");
            backImage.WidthRequest = 40;
            backImage.HeightRequest = 40;
            backImage.CornerRadius = 25;
            backImage.BackgroundColor = Color.White;

            SignOutBtn.Padding = new Thickness(3);
            SignOutBtn.CornerRadius = 3;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var ratingModel = await _ratingService.GetById<RatingModel>(_reservationId);
            if (ratingModel != null)
            {
                FillTheDataReview.IsVisible = false;
                ShowTheDataReview.IsVisible = true;
            }
            await model.Init();
            await Helper.LoadUserImage(_clientService, userImg);
        }

        private void SignOutBtn_OnClicked(object sender, EventArgs e)
        {
            Helper.SignOut();
        }

        private void UserImg_OnClicked(object sender, EventArgs e)
        {
            Helper.UserImgOnClick();
        }

        private void BackImage_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MyReservationsView();
        }

        private async void SubmitReviewBtn_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CommentEntry.Text) || ReviewPicker.SelectedItem == null)
            {
                await DisplayAlert("Warning", "Please fill in all fields!", "OK");
            }
            else
            {
                try
                {
                    var newRatingModel = (ReviewViewModel.ReservationGrade)ReviewPicker.SelectedItem;

                    var request = new RatingInsertUpdateRequest
                    {
                        ClientId = APIService.LoggedUserId,
                        Comment = CommentEntry.Text,
                        CreationDate = DateTime.Now,
                        RatingInt = newRatingModel.Grade,
                        RatingString = newRatingModel.Grade.ToString(),
                        ReservationId = _reservationId,
                        VehicleId = model.ReservationVehicleId
                    };

                    var ratingCreated = await _ratingService.Insert<RatingModel>(request);

                    if (ratingCreated != null)
                    {
                        await DisplayAlert("Success", "Rating created successfully!", "OK");
                        FillTheDataReview.IsVisible = false;
                        ShowTheDataReview.IsVisible = true;
                        await model.Init();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
               
            }
        }
    }
}