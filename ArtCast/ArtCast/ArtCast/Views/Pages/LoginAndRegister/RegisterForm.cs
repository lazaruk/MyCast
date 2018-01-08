using ArtCast.Converters;
using ArtCast.Data;
using ArtCast.Helpers;
using ArtCast.Models.LoginAndRegister;
using ArtCast.Styles;
using ArtCast.ViewModels.LoginAndRegister;
using ArtCast.Views.Elements;
using ArtCast.Views.Pages.Popups;
using Syncfusion.SfRating.XForms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ArtCast.Views.Pages.LoginAndRegister
{
    public class RegisterForm: LoginAndRegisterDialog
    {
        private StackLayout _content;
        private readonly LoginAndRegisterViewModel _model;
        private readonly SfRating _rating;

        public RegisterForm()
        {
            _model = new LoginAndRegisterViewModel();

            _rating = new SfRating
            {
                EnableCustomView = true,
                ItemSpacing = 20,
                Value = 1,
                Precision = Precision.Standard
            };
            _rating.ValueChanged += (sender, args) => { NextButton.CommandParameter = _rating.Value; };
            
            StepOne();

            _model.PropertyChanged += (sender, args) =>
            {
                if (_model.StepsSource == Steps.Two) StepTwo();
                if (_model.StepsSource == Steps.Three) StepThree();
                if (_model.StepsSource == Steps.Four) StepFour();
                if (_model.StepsSource == Steps.Five) StepFive();
            };
        }

        private void StepOne()
        {
            SetTitle("Шаг 1");
            GetCircle(1);

            var answers = new List<AnswerUserRegisterModel> //todo from BD
            {
                new AnswerUserRegisterModel {User = UserTypes.Worker, Text = "Соискатель"},
                new AnswerUserRegisterModel {User = UserTypes.Employer, Text = "Работодатель"}
            };

            NextButton.CommandParameter = _rating.Value;
            NextButton.Command = _model.OneStepCommand;

            var collection = new ObservableCollection<SfRatingItem>();
            foreach (var answer in answers)
                collection.Add(GetRatingItem(answer));

            _rating.ItemCount = collection.Count;
            _rating.Items = collection;
            _rating.ItemSize = _rating.ItemCount * 50;
            _rating.WidthRequest = _rating.ItemCount * 100 + 20;

            _content = new StackLayout { Children = { _rating }, Padding = new Thickness(0, 20), HorizontalOptions = LayoutOptions.CenterAndExpand };

            AddChild(_content);
        }

        private void StepTwo()
        {
            _content.Children.Clear();

            SetTitle("Шаг 2");
            GetCircle(2);

            var answers = new List<AnswerSpecspecializationRegisterModel> //todo from BD
            {
                new AnswerSpecspecializationRegisterModel {Specspecialization = TypeBusiness.Model, Text = "Модельный бизнес"},
                new AnswerSpecspecializationRegisterModel {Specspecialization = TypeBusiness.Club, Text = "Клубный бизнес"},
                new AnswerSpecspecializationRegisterModel {Specspecialization = TypeBusiness.Show, Text = "Шоу-бизнес"}
            };

            var collection = new ObservableCollection<SfRatingItem>();
            foreach (var answer in answers)
                collection.Add(GetRatingItem(specAnswer: answer));

            _rating.ItemCount = collection.Count;
            _rating.Items = collection;
            _rating.ItemSize = _rating.ItemCount * 30;
            _rating.WidthRequest = _rating.ItemCount * 100 + 20;

            NextButton.CommandParameter = _rating.Value;
            NextButton.Command = _model.TwoStepCommand;

            _content.Children.Add(_rating);
        }

        private void StepThree()
        {
            _content.Children.Clear();

            SetTitle("Шаг 3");
            GetCircle(3);

            var input = new EntryColor
            {
                Placeholder = "Имя",
                WidthRequest = 150,
                TextColor = AppStyles.PrimaryColor,
                HorizontalTextAlignment = TextAlignment.Center
            };
            input.PropertyChanged += (sender, args) =>
            {
                NextButton.CommandParameter = input.Text;
                input.SetBinding(EntryColor.BorderColorProperty, new Binding(nameof(EntryColor.Text), source: input, converter: new StringHasValueToColorConverter { TrueColor = AppStyles.PrimaryColor, FalseColor = Color.Red, IgnoredValue = Device.RuntimePlatform == Device.iOS ? input.Placeholder : null }));
                if (input.Text.HasValue()) NextButton.Command = _model.ThreeStepCommand;
            };
            
            _content.Children.Add(input);
        }

        private void StepFour()
        {
            _content.Children.Clear();

            SetTitle("Шаг 4");
            GetCircle(4);

            var input = new EntryColor
            {
                Placeholder = "Email",
                WidthRequest = 200,
                TextColor = AppStyles.PrimaryColor,
                HorizontalTextAlignment = TextAlignment.Center
            };
            input.PropertyChanged += (sender, args) =>
            {
                NextButton.CommandParameter = input.Text;
                input.SetBinding(EntryColor.BorderColorProperty, new Binding(nameof(EntryColor.Text), source: input, converter: new StringHasValueToColorConverter { TrueColor = AppStyles.PrimaryColor, FalseColor = Color.Red, IgnoredValue = Device.RuntimePlatform == Device.iOS ? input.Placeholder : null }));
                if (input.Text.HasValue()) NextButton.Command = _model.FourStepCommand;
            };
            
            NextButton.WidthRequest = 150;
            
            _content.Children.Add(input);
        }

        private void StepFive()
        {
            _content.Children.Clear();

            SetTitle("Шаг 5");
            GetCircle(5);

            var input = new EntryColor
            {
                Placeholder = "Пароль",
                WidthRequest = 200,
                TextColor = AppStyles.PrimaryColor,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var reenterInput = new EntryColor
            {
                Placeholder = "Повторно пароль",
                WidthRequest = 200,
                TextColor = AppStyles.PrimaryColor,
                HorizontalTextAlignment = TextAlignment.Center
            };

            input.PropertyChanged += (sender, args) =>
            {
                input.SetBinding(EntryColor.BorderColorProperty, new Binding(nameof(EntryColor.Text), source: input, converter: new StringHasValueToColorConverter { TrueColor = AppStyles.PrimaryColor, FalseColor = Color.Red, IgnoredValue = Device.RuntimePlatform == Device.iOS ? input.Placeholder : null }));
                if (input.Text == reenterInput.Text && input.Text.HasValue())
                {
                    NextButton.CommandParameter = reenterInput.Text;
                    NextButton.Command = _model.FiveStepCommand;
                }
            };
            
            reenterInput.PropertyChanged += (sender, args) =>
            {
                reenterInput.SetBinding(EntryColor.BorderColorProperty, new Binding(nameof(EntryColor.Text), source: reenterInput, converter: new StringHasValueToColorConverter { TrueColor = AppStyles.PrimaryColor, FalseColor = Color.Red, IgnoredValue = Device.RuntimePlatform == Device.iOS ? reenterInput.Placeholder : null }));
                if (input.Text == reenterInput.Text && input.Text.HasValue())
                {
                    NextButton.CommandParameter = reenterInput.Text;
                    NextButton.Command = _model.FiveStepCommand;
                }
            };
            
            NextButton.Text = "Зарегистрироваться";
            NextButton.WidthRequest = 150;
            
            _content.Children.Add(input);
            _content.Children.Add(reenterInput);
        }
        
        private static SfRatingItem GetRatingItem(AnswerUserRegisterModel userAnswer = null, AnswerSpecspecializationRegisterModel specAnswer = null)
        {
            var icon = string.Empty;

            switch (userAnswer?.User)
            {
                case UserTypes.Worker: icon = AwesomeFontIcons.User; break;
                case UserTypes.Employer: icon = AwesomeFontIcons.WorkUser; break;
            }

            switch (specAnswer?.Specspecialization)
            {
                case TypeBusiness.Model: icon = AwesomeFontIcons.Camera; break;
                case TypeBusiness.Club: icon = AwesomeFontIcons.Star; break;
                case TypeBusiness.Show: icon = AwesomeFontIcons.Star; break;
            }

            return new SfRatingItem
            {
                SelectedView = new ChangeIconView(icon, userAnswer?.Text ?? specAnswer?.Text, true),
                UnSelectedView = new ChangeIconView(icon, userAnswer?.Text ?? specAnswer?.Text, false)
            };
        }
    }
}
