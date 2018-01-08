using Xamarin.Forms;

namespace ArtCast.Views.Pages.Base
{
    public class BasePage: ContentPage
    {
        protected BasePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public virtual void SetTitle(string title) { }

        public virtual void OnSleep() { }

        public virtual void OnResume() { }
    }
}
