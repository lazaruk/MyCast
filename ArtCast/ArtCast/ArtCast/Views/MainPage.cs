using ArtCast.Views.Pages.Menu;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArtCast.Views
{
    public class MainPage: MasterDetailPage
    {
        public MainPage()
        {
            Master = new MenuPage(this);
            Detail = new NavigationPage(new StartPage());
            IsPresented = false;
            MasterBehavior = MasterBehavior.Popover;
            IsGestureEnabled = false;
            TogglePresentedCommand = new Command(ExecuteTogglePresentedCommand);
        }

        public ICommand TogglePresentedCommand { get; }
        private void ExecuteTogglePresentedCommand()
        {
            IsPresented = !IsPresented;
        }

        public void HideMenu()
        {
            IsPresented = false;
        }
    }
}
