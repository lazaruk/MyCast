using ArtCast.Views.Pages.Base;
using Xamarin.Forms;

namespace ArtCast.Views.Pages.Home
{
    public class HomePage : PageWithNavigation
    {
        public HomePage() : base("Главная", false)
        {
            var сontent = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };

            AddContent(сontent);
        }
    }
}