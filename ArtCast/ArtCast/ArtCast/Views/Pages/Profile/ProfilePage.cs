using ArtCast.Views.Elements.Profile;
using ArtCast.Views.Pages.Base;

namespace ArtCast.Views.Pages.Profile
{
    public class ProfilePage: PageWithNavigation
    {
        public ProfilePage():base("Профиль", false)
        {
            var header = new HeaderProfileView();

            AddContent(header);
        }
    }
}
