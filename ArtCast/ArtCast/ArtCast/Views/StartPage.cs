using ArtCast.Styles;
using ArtCast.ViewModels;
using ArtCast.Views.Elements;
using ArtCast.Views.Pages.Base;
using ArtCast.Views.Pages.LoginAndRegister;
using Xamarin.Forms;

namespace ArtCast.Views
{
    public class StartPage : BasePage
    {
        private readonly ScrollView _scrollView;

        public StartPage()
        {
            Grid layout;
            Content = layout = new Grid();
            layout.Children.Add(_scrollView = new ScrollView());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AddPageContent();
        }
        
        private void AddPageContent()
        {
            var buttonLogin = new Button
            {
                Text = "Войти",
                BackgroundColor = AppStyles.PrimaryColor,
                TextColor = Color.White,
                Command = App.Current.Navigation.ShowPopupCommand,
                CommandParameter = new CreatePopupInfo(typeof(LoginForm))
            };

            var buttonRegister = new ButtonWithoutStyles
            {
                Text = "Регистрация",
                BackgroundColor = Color.Transparent,
                TextColor = AppStyles.PrimaryColor,
                Command = App.Current.Navigation.ShowPopupCommand,
                CommandParameter = new CreatePopupInfo(typeof(RegisterForm))
            };

            var buttonStack = new StackLayout { Children = { buttonLogin, buttonRegister } };

            var logo = new Image
            {
                Source = "logo.png", //todo from bd
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 400 //fix
            };

            var content = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition {Height = new GridLength(8, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(2, GridUnitType.Star)}
                }
            };
            content.Children.Add(logo, 0, 0);
            content.Children.Add(buttonStack, 0, 1);
            
            _scrollView.Content = content;
        }
    }
}