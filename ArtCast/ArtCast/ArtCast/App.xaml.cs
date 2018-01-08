using ArtCast.ViewModels;
using ArtCast.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArtCast
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            Current = this;
            MainPage = new MainPage();
            Navigation = new NavigationViewModel(MainPage.Detail.Navigation);
        }

        protected override void OnStart()
        {
            IsActive = true;
        }

        protected override void OnSleep()
        {
            IsActive = false;
            Navigation.CurrentPage?.OnSleep();
        }

        protected override void OnResume()
        {
            IsActive = true;
        }

        public bool IsActive { get; private set; }
        public NavigationViewModel Navigation { get; }
        public new static App Current { get; private set; }
        public MainViewModel MainViewModel { get; } = new MainViewModel();

        private MainPage _mainPage;
        public new MainPage MainPage
        {
            get => _mainPage;
            private set => base.MainPage = _mainPage = value;
        }
    }
}