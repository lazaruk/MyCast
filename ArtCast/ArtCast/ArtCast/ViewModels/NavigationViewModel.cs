using ArtCast.Helpers;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ArtCast.Views.Pages.Base;
using Xamarin.Forms;

namespace ArtCast.ViewModels
{
    public class NavigationViewModel
    {
        private readonly INavigation _navigation;
        private bool _isNavigationPending;
        private readonly object _lockIsNavigationPending = new object();

        public NavigationViewModel(INavigation navigation)
        {
            _navigation = navigation;
            NavigateCommand = new Command<NavigateInfo>(ExecuteNavigateCommand);
            NavigateBackCommand = new Command<Type>(ExecuteNavigateBackCommand);
            ShowPopupCommand = new Command<CreatePopupInfo>(ExecuteOpenPopupCommand);
            ClosePopupCommand = new Command(ExecuteClosePopupCommand);
        }

        public BasePage CurrentPage => _navigation.NavigationStack.LastOrDefault() as BasePage;
        public Page CurrentModalPage => _navigation.ModalStack.LastOrDefault();
        public Type CurrentSectionRootPageType { get; private set; }

        public ICommand NavigateCommand { get; }
        private async void ExecuteNavigateCommand(NavigateInfo info)
        {
            await Navigate(info);
        }

        public async Task Navigate(NavigateInfo info)
        {
            if (info?.PageType != null && LockNavigation())
            {
                switch (info.Mode)
                {
                    case NavigateMode.Default:
                        CurrentSectionRootPageType = NavigationHelper.GetSectionRootPageTypeForPage(info.PageType);
                        var page = info.CreatePage();
                        await _navigation.PushAsync(page);
                        break;
                    case NavigateMode.RemovePrevious:
                    case NavigateMode.RemoveAllPrevious:
                        CurrentSectionRootPageType = NavigationHelper.GetSectionRootPageTypeForPage(info.PageType);
                        page = info.CreatePage();
                        await _navigation.PushAsync(page);

                        var numberPagesToRemove = info.Mode == NavigateMode.RemovePrevious ? (int?)(info.NavigateParam as int? ?? 1) : null;
                        while ((numberPagesToRemove == null || numberPagesToRemove > 0) && _navigation.NavigationStack.Count > 1)
                        {
                            _navigation.RemovePage(_navigation.NavigationStack[_navigation.NavigationStack.Count - 2]);
                            if (numberPagesToRemove != null) numberPagesToRemove--;
                        }
                        break;
                    case NavigateMode.ToSectionRoot:
                        var last = _navigation.NavigationStack.LastOrDefault();
                        if (last == null || last.GetType() != info.PageType)
                        {
                            CurrentSectionRootPageType = info.PageType;

                            page = _navigation.NavigationStack.FirstOrDefault(p => p.GetType() == info.PageType) as BasePage;
                            if (page != null)
                            {
                                var i = _navigation.NavigationStack.Count - 2;
                                var pageForRemove = _navigation.NavigationStack[i];
                                while (pageForRemove != page)
                                {
                                    _navigation.RemovePage(pageForRemove);
                                    pageForRemove = _navigation.NavigationStack[--i];
                                }
                                await _navigation.PopAsync();
                            }
                            else await _navigation.PushAsync(info.CreatePage());
                        }
                        break;
                    case NavigateMode.Modal:
                        var modalPage = info.CreateModalPage();
                        await _navigation.PushModalAsync(modalPage);
                        break;
                }
                UnlockNavigation();
            }
        }

        public ICommand NavigateBackCommand { get; }
        private async void ExecuteNavigateBackCommand(Type pageType)
        {
            await NavigateBack(pageType);
        }

        public async Task NavigateBack(Type pageType = null)
        {
            if (LockNavigation())
            {
                if (pageType != null)
                {
                    if (_navigation.NavigationStack.Any(p => p.GetType() == pageType))
                    {
                        var i = _navigation.NavigationStack.Count - 2;
                        var pageForRemove = _navigation.NavigationStack[i];
                        while (pageForRemove != null && pageForRemove.GetType() != pageType)
                        {
                            _navigation.RemovePage(pageForRemove);
                            pageForRemove = i > 0 ? _navigation.NavigationStack[--i] : null;
                        }
                    }
                }
                await _navigation.PopAsync();
                UnlockNavigation();
            }
        }

        public ICommand ShowPopupCommand { get; }
        private async void ExecuteOpenPopupCommand(CreatePopupInfo info)
        {
            await ShowPopup(info);
        }

        public async Task<BasePopup> ShowPopup(CreatePopupInfo info)
        {
            if (info?.PageType != null && LockNavigation())
            {
                var popup = info.CreatePopup();
                await _navigation.PushPopupAsync(popup);
                UnlockNavigation();
                if (info.WaitClosing)
                {
                    while (true)
                    {
                        await Task.Delay(100);
                        if (popup.IsClosed) break;
                    }
                }
                else return popup;
            }
            return null;
        }

        public ICommand ClosePopupCommand { get; }
        private async void ExecuteClosePopupCommand()
        {
            await ClosePopup();
        }

        public async Task ClosePopup()
        {
            if (LockNavigation())
            {
                await _navigation.PopPopupAsync(false);
                UnlockNavigation();
            }
        }

        public async Task CloseAllPopup()
        {
            await _navigation.PopAllPopupAsync();
        }

        private bool LockNavigation()
        {
            if (!_isNavigationPending)
            {
                lock (_lockIsNavigationPending)
                {
                    if (!_isNavigationPending)
                    {
                        _isNavigationPending = true;
                        return true;
                    }
                }
            }
            return false;
        }

        private void UnlockNavigation()
        {
            _isNavigationPending = false;
        }
    }

    public class NavigateInfo
    {
        public Type PageType { get; }
        public object PageArg { get; }
        public NavigateMode Mode { get; }
        public object NavigateParam { get; }

        public NavigateInfo(Type pageType, object pageArg = null, NavigateMode mode = NavigateMode.Default, object navigateParam = null)
        {
            PageType = pageType;
            PageArg = pageArg;
            Mode = mode;
            NavigateParam = navigateParam;
        }

        public BasePage CreatePage()
        {
            return (BasePage)(PageArg != null ? Activator.CreateInstance(PageType, PageArg) : Activator.CreateInstance(PageType));
        }

        public ContentPage CreateModalPage()
        {
            return (ContentPage)(PageArg != null ? Activator.CreateInstance(PageType, PageArg) : Activator.CreateInstance(PageType));
        }
    }

    public enum NavigateMode
    {
        Default,
        RemovePrevious,
        RemoveAllPrevious,
        ToSectionRoot,
        Modal
    }

    public class CreatePopupInfo
    {
        public Type PageType { get; }
        public object[] Args { get; }
        public bool WaitClosing { get; }

        public CreatePopupInfo(Type pageType, params object[] args)
        {
            PageType = pageType;
            Args = args;
        }

        public CreatePopupInfo(Type pageType, bool waitClosing, params object[] args)
        {
            PageType = pageType;
            Args = args;
            WaitClosing = waitClosing;
        }

        public BasePopup CreatePopup()
        {
            return (BasePopup)(Args.HasItems() ? Activator.CreateInstance(PageType, Args) : Activator.CreateInstance(PageType));
        }
    }
}
