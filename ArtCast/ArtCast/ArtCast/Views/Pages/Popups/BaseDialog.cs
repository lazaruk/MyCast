using ArtCast.Data;
using ArtCast.Styles;
using ArtCast.Views.Elements;
using ArtCast.Views.Pages.Base;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArtCast.Views.Pages.Popups
{
    public class BaseDialog: BasePopup
    {
        private readonly StackLayout _contentLayout;

        public BaseDialog()
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

            _contentLayout = new StackLayout
            {
                Margin = new Thickness(0, 0, 60, 0)
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

            Content = new ContentViewRoundedCorners
            {
                CornerRadius = 30,
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(60, 0),
                Content = new StackLayout { Children = { crossButton, _contentLayout, buttonGrid } },
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
    }
}
