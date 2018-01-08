using ArtCast.ViewModels.Menu;

namespace ArtCast.ViewModels
{
    public class MainViewModel
    {
        public MenuHeaderViewModel MenuHeaderViewModel { get; }
        public bool ShowMenu { get; set; }

        public MainViewModel()
        {
            MenuHeaderViewModel = new MenuHeaderViewModel();
        }

        public void GoToHomePage()
        {
            MenuHeaderViewModel.UserLoggedIn();
            ShowMenu = true;
        }
    }
}
