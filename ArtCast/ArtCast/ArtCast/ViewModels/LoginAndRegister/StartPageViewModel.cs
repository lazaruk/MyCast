using Xamarin.Forms;

namespace ArtCast.ViewModels.LoginAndRegister
{
    public class StartPageViewModel: ViewModelBase
    {
        public StartPageViewModel()
        {
            LoginCommand = new Command(ExecuteLoginCommand);
            RegisterCommand = new Command(ExecuteRegisterCommand);
        }
        
        public Command LoginCommand { get; }
        private static void ExecuteLoginCommand()
        {
            
        }

        public Command RegisterCommand { get; }
        private static void ExecuteRegisterCommand()
        {
            
        }
    }
}
