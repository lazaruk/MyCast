using ArtCast.Styles;
using ArtCast.ViewModels.LoginAndRegister;
using ArtCast.Views.Elements;
using ArtCast.Views.Pages.Popups;
using Xamarin.Forms;

namespace ArtCast.Views.Pages.LoginAndRegister
{
    public class LoginForm: LoginAndRegisterDialog
    {
        public LoginForm()
        {
            var model = new LoginAndRegisterViewModel();

            SetTitle("Вход");

            var email = new EntryColor
            {
                Placeholder = "Email",
                WidthRequest = 200,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = AppStyles.PrimaryColor
            };

            var password = new EntryColor
            {
                Placeholder = "Пароль",
                WidthRequest = 200,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = AppStyles.PrimaryColor
            };

            var content = new StackLayout
            {
                Children = { email, password },
                Padding = new Thickness(0, 20),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            NextButton.Text = "Войти";
            NextButton.Command = model.LoginCommand;

            AddChild(content);
        }
    }
}
