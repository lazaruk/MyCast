using ArtCast.Views.Pages.Base;
using Xamarin.Forms;

namespace ArtCast.Views.Pages.Profile
{
    public class ProfilePage: PageWithNavigation
    {
        public ProfilePage():base("Профиль", false)
        {
            AddContent(new Label { Text = "Профиль" });
        }
    }
}
