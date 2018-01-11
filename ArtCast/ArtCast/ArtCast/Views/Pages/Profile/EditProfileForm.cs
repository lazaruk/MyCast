using ArtCast.Data;
using ArtCast.Styles;
using ArtCast.Views.Elements;
using ArtCast.Views.Elements.Profile;
using ArtCast.Views.Pages.Popups;
using Xamarin.Forms;

namespace ArtCast.Views.Pages.Profile
{
    public class EditProfileForm: BaseDialog
    {
        public EditProfileForm()
        {
            var button = new ButtonWithoutStyles
            {
                Text = "Сохранить",
                HorizontalOptions = LayoutOptions.End,
                Style = AppStyles.LoginAndRegisterButtonStyle,
                Command = App.Current.Navigation.ClosePopupCommand
            };

            var content = new StackLayout
            {
                Children =
                {
                    new EditProfileSectionView(EditProfileSections.UserInfo),
                    new EditProfileSectionView(EditProfileSections.Contacts),
                    button
                },
                Spacing = 15
            };

            AddChild(content);
        }
    }
}
