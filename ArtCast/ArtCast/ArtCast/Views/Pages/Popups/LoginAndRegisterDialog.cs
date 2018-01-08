using ArtCast.Data;
using ArtCast.Styles;
using ArtCast.Views.Elements;
using ArtCast.Views.Pages.Base;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArtCast.Views.Pages.Popups
{
    public class LoginAndRegisterDialog : BasePopup
    {
        protected ButtonWithoutStyles NextButton { get; set; }
        private readonly StackLayout _contentLayout;
        private readonly StackLayout _circleLayout;
        protected Label Text { get; set; }

        public LoginAndRegisterDialog()
        {
            var crossButton = new ButtonWithoutStyles
            {
                FontSize = 30,
                HorizontalOptions = LayoutOptions.End,
                MinimumWidthRequest = 55,
                HeightRequest = 50,
                FontFamily = AppStyles.FontAwesomeFamily,
                Text = AwesomeFontIcons.Close,
                TextColor = AppStyles.PrimaryColor,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Command = App.Current.Navigation.ClosePopupCommand
            };

            Text = new Label
            {
                FontSize = 24,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            _circleLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 10
            };

            _contentLayout = new StackLayout
            {
                Margin = new Thickness(0, 0, 60, 0),
                Children = { Text, _circleLayout, new BoxView { Style = AppStyles.SeparatorStyle }}
            };

            NextButton = new ButtonWithoutStyles
            {
                Text = "Далее",
                HorizontalOptions = LayoutOptions.End,
                Style = AppStyles.LoginAndRegisterButtonStyle
            };

            var buttonGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition {Width = GridLength.Star},
                    new ColumnDefinition {Width = GridLength.Star}
                },
                Padding = new Thickness(0, 0, 20, 0)
            };
            buttonGrid.Children.Add(NextButton, 1, 0);

            Content = new ContentViewRoundedCorners
            {
                CornerRadius = 30,
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(60, 0),
                Content = new StackLayout {Children = {crossButton, _contentLayout, buttonGrid } },
                Padding = new Thickness(60, 10, 0, 30)
            };
        }

        protected void AddChild(View view)
        {
            _contentLayout.Children.Add(view);
        }

        protected virtual Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }
        
        protected virtual Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1);
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }

        protected void SetTitle(string title)
        {
            Text.Text = title;
        }

        protected void SetTitle(string title, Color textColor, LayoutOptions layoutOptions, double fontSize = 22)
        {
            Text.Text = title;
            Text.TextColor = textColor;
            Text.HorizontalOptions = layoutOptions;
            Text.FontSize = fontSize;
        }

        protected void GetCircle(int active)
        {
            _circleLayout.Children.Clear();

            for (var i = 0; i < 5; i++)
            {
                _circleLayout.Children.Add(i < active ? CreateCircle(AwesomeFontIcons.CircleOn) : CreateCircle(AwesomeFontIcons.CircleOff));
            }
        }

        private static Label CreateCircle(string iconSource)
        {
            return new Label
            {
                Text = iconSource,
                FontSize = 14,
                FontFamily = AppStyles.FontAwesomeFamily,
                TextColor = AppStyles.PrimaryColor,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Transparent
            };
        }
    }
}
