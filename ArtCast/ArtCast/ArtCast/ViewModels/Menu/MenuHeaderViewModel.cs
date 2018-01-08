using ArtCast.Data;

namespace ArtCast.ViewModels.Menu
{
    public class MenuHeaderViewModel : ViewModelBase
    {
        #region Properties

        string _tenantName;
        public string TenantName
        {
            get => _tenantName;
            private set
            {
                if (_tenantName == value) return;

                _tenantName = value;
                OnPropertyChanged(nameof(TenantName));
            }
        }

        string _profilePicture;
        public string ProfilePicture
        {
            get => _profilePicture;
            private set
            {
                if (_profilePicture == value) return;

                _profilePicture = value;
                OnPropertyChanged(nameof(ProfilePicture));
            }
        }

        string _userName;
        public string UserName
        {
            get => _userName;
            private set
            {
                if (_userName == value) return;

                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        #endregion

        public void UserLoggedIn()
        {
            TenantName = "Тенант";
            ProfilePicture = AwesomeFontIcons.User;
            UserName = "Имя Фамилия";
        }

        public void UserLoggedOut()
        {
            TenantName = null;
            ProfilePicture = null;
            UserName = null;
        }
    }
}
