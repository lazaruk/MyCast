using ArtCast.Styles;
using ArtCast.ViewModels.Menu;
using Xamarin.Forms;

namespace ArtCast.Views.Pages.Menu
{
    public class MenuHeaderView : ContentView
    {
        public MenuHeaderView(MenuHeaderViewModel viewModel)
        {
            BindingContext = viewModel;

            #region Init Controls

            var profilePictureLabel = new Label { Style = AppStyles.UserPictureLabelStyle };
            var tenantNameLabel = new Label { Style = AppStyles.UserInfoLabelStyle };
            var userNameLabel = new Label { Style = AppStyles.UserInfoLabelStyle };

            #endregion

            #region Setup Binding

            profilePictureLabel.SetBinding(Label.TextProperty, nameof(MenuHeaderViewModel.ProfilePicture));
            tenantNameLabel.SetBinding(Label.TextProperty, nameof(MenuHeaderViewModel.TenantName));
            userNameLabel.SetBinding(Label.TextProperty, nameof(MenuHeaderViewModel.UserName));

            #endregion

            #region Setup layout

            var userInfoLayout = new StackLayout
            {
                Children = { tenantNameLabel, userNameLabel },
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            var profileLayout = new StackLayout
            {
                Children = { profilePictureLabel, userInfoLayout },
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 25
            };

            var separator = new BoxView { Style = AppStyles.SeparatorStyle };

            var headerLayout = new StackLayout
            {
                Children = { profileLayout },
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 15,
                Padding = new Thickness(40, 20, 20, 5)
            };

            Content = new StackLayout
            {
                Children = { headerLayout, separator },
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            #endregion
        }
    }
}
