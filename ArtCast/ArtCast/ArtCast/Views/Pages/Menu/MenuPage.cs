using ArtCast.Data;
using ArtCast.Models.Menu;
using ArtCast.Styles;
using ArtCast.ViewModels;
using ArtCast.Views.Pages.Home;
using System.Collections.Generic;
using System.Windows.Input;
using ArtCast.Views.Pages.Profile;
using ArtCast.Views.Templates.Cells;
using Xamarin.Forms;

namespace ArtCast.Views.Pages.Menu
{
    public class MenuPage : ContentPage
    {
        private readonly ListView _listView;
        private readonly MainPage _mainPage;

        public MenuPage(MainPage mainPage)
        {
            Title = "Меню";
            _mainPage = mainPage;

            _navigateToPageCommand = new Command<NavigateInfo>(ExecuteNavigateToPageCommand);
            
            var masterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Text = "Пункт 1",
                    Icon = AwesomeFontIcons.Camera,
                    IconFontFamily = AppStyles.FontAwesomeFamily,
                    IconSize = 30,
                    IconMarginLeft = 25,
                    TextMargin = new Thickness(10, 7, 0, 0),
                    Command = _navigateToPageCommand,
                    CommandParameter = new NavigateInfo(typeof(ProfilePage))
                },
                new MasterPageItem
                {
                    Text = "Пункт 2",
                    Icon = AwesomeFontIcons.User,
                    IconFontFamily = AppStyles.FontAwesomeFamily,
                    IconSize = 30,
                    IconMarginLeft = 25,
                    TextMargin = new Thickness(10, 7, 0, 0),
                    Command = _navigateToPageCommand,
                    CommandParameter = new NavigateInfo(typeof(HomePage))
                }
            };

            _listView = new ListView
            {
                Header = new MenuHeaderView(App.Current.MainViewModel.MenuHeaderViewModel),
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() => {
                    var item = new ItemCell();
                    item.SetBinding(ItemCell.IconProperty, "Icon");
                    item.SetBinding(ItemCell.IconSizeProperty, "IconSize");
                    item.SetBinding(ItemCell.IconMarginLeftProperty, "IconMarginLeft");
                    item.SetBinding(ItemCell.TextProperty, "Text");
                    item.SetBinding(ItemCell.TextMarginProperty, "TextMargin");
                    item.SetBinding(ItemCell.CommandProperty, "Command");
                    item.SetBinding(ItemCell.CommandParameterProperty, "CommandParameter");
                    item.SetBinding(ItemCell.IconFontFamilyProperty, "IconFontFamily");
                    return item;
                }),
                SeparatorVisibility = SeparatorVisibility.None
            };
            
            Content = new StackLayout { Children = { _listView } };
        }

        private readonly ICommand _navigateToPageCommand;
        private async void ExecuteNavigateToPageCommand(NavigateInfo info)
        {
            _mainPage.HideMenu();
            await App.Current.Navigation.Navigate(info);
        }
    }
}