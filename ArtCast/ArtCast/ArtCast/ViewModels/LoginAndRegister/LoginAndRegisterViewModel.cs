using ArtCast.Data;
using ArtCast.Models.LoginAndRegister;
using ArtCast.Models.User;
using ArtCast.Views.Pages.Home;
using ArtCast.Views.Pages.Profile;
using System;
using Xamarin.Forms;

namespace ArtCast.ViewModels.LoginAndRegister
{
    public class LoginAndRegisterViewModel: ViewModelBase
    {
        private readonly RequestRegisterModel _request;

        private Steps? _stepsSource;
        public Steps? StepsSource
        {
            get => _stepsSource;
            set { _stepsSource = value; OnPropertyChanged(nameof(StepsSource)); }
        }

        public LoginAndRegisterViewModel()
        {
            StepsSource = Steps.One;
            _request = new RequestRegisterModel();

            OneStepCommand = new Command<double>(ExecuteOneStepCommand);
            TwoStepCommand = new Command<double>(ExecuteTwoStepCommand);
            ThreeStepCommand = new Command<string>(ExecuteThreeStepCommand);
            FourStepCommand = new Command<string>(ExecuteFourStepCommand);
            FiveStepCommand = new Command<string>(ExecuteFiveStepCommand);
            LoginCommand = new Command<UserModel>(ExecuteLoginCommand);
        }

        public Command OneStepCommand { get; }
        private void ExecuteOneStepCommand(double value)
        {
            StepsSource = Steps.Two;
            _request.UserTypes = (UserTypes)Enum.Parse(typeof(UserTypes), value.ToString());
        }

        public Command TwoStepCommand { get; }
        private void ExecuteTwoStepCommand(double value)
        {
            StepsSource = Steps.Three;
            _request.Specialisation = (SpecTypes)Enum.Parse(typeof(SpecTypes), value.ToString());
        }

        public Command ThreeStepCommand { get; }
        private void ExecuteThreeStepCommand(string value)
        {
            StepsSource = Steps.Four;
            _request.Name = value;
        }

        public Command FourStepCommand { get; }
        private void ExecuteFourStepCommand(string value)
        {
            StepsSource = Steps.Five;
            _request.Email = value;
        }

        public Command FiveStepCommand { get; }
        private async void ExecuteFiveStepCommand(string value)
        {
            _request.Password = value;
            await App.Current.Navigation.ClosePopup();
            await App.Current.Navigation.Navigate(new NavigateInfo(typeof(ProfilePage), mode: NavigateMode.RemoveAllPrevious));
        }

        public Command LoginCommand { get; }
        private static async void ExecuteLoginCommand(UserModel model)
        {
            await App.Current.Navigation.ClosePopup();
            App.Current.MainViewModel.GoToHomePage();
            await App.Current.Navigation.Navigate(new NavigateInfo(typeof(HomePage), mode: NavigateMode.RemoveAllPrevious));
        }
    }
}
