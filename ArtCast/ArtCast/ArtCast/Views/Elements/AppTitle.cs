using ArtCast.Data;
using ArtCast.Styles;
using Xamarin.Forms;

namespace ArtCast.Views.Elements
{
    public class AppTitle : ContentView
    {
        public AppTitle()
        {
            var content = new Grid();
            content.Children.Add(new Label
            {
                Text = "ла алал алал алала ала лал",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            });

            if (App.Current.MainViewModel.ShowMenu)
            {
                var menuButton = new ButtonWithoutStyles
                {
                    Command = App.Current.MainPage.TogglePresentedCommand,
                    Text = AwesomeFontIcons.Menu,
                    FontFamily = AppStyles.FontAwesomeFamily,
                    TextColor = AppStyles.MenuButtonColor,
                    FontSize = AppStyles.VeryLargeFontSize,
                    BackgroundColor = Color.Transparent,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    WidthRequest = 50
                };
                content.Children.Add(menuButton);
            }

            Content = content;

            HeightRequest = 50;
            BackgroundColor = Color.FromRgb(236, 236, 236);
        }
    }
}
