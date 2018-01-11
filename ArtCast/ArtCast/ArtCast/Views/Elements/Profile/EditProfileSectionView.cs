using ArtCast.Data;
using ArtCast.Helpers;
using ArtCast.Styles;
using Xamarin.Forms;

namespace ArtCast.Views.Elements.Profile
{
    public class EditProfileSectionView : ContentView
    {
        private readonly ButtonWithoutStyles _toggleButton;
        private readonly Grid _sectionViewGrid;

        public EditProfileSectionView(EditProfileSections title)
        {
            _toggleButton = new ButtonWithoutStyles
            {
                FontFamily = AppStyles.FontAwesomeFamily,
                FontSize = 20,
                TextColor = Color.White,
                Text = AwesomeFontIcons.Down,
                HorizontalOptions = LayoutOptions.End,
                BackgroundColor = Color.Transparent,
                Command = new Command(ToggleCollapsed)
            };

            var titleLabel = new Label
            {
                Text = GetTitleSection(title),
                TextColor = Color.White,
                FontSize = 20,
                Margin = new Thickness(20, 5),
                VerticalOptions = LayoutOptions.Center
            };

            var titleGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Auto }
                },
                RowSpacing = 15,
                ColumnSpacing = 15,
                BackgroundColor = AppStyles.PrimaryColor
            };

            _sectionViewGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Star }
                },
                RowSpacing = 5,
                ColumnSpacing = 5,
                IsVisible = false,
                Margin = new Thickness(20, 0)
            };

            switch (title)
            {
                case EditProfileSections.UserInfo:
                    {
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetTitle("Имя"), 0, 0);
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetEntry(), 1, 0);
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetTitle("Возраст"), 0, 1);
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetEntry(), 1, 1);
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetTitle("Город"), 0, 2);
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetEntry(), 1, 2);
                        break;
                    }
                case EditProfileSections.Contacts:
                    {
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetTitle("Вконтакте"), 0, 0);
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetEntry(), 1, 0);
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetTitle("Facebook"), 0, 1);
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetEntry(), 1, 1);
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetTitle("Instagram"), 0, 2);
                        ViewsHelper.AddViewToGridOrSetPosition(_sectionViewGrid, GetEntry(), 1, 2);
                        break;
                    }
            }

            titleGrid.Children.Add(titleLabel);

            var tapBoxView = new BoxView { BackgroundColor = Color.Transparent };
            tapBoxView.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(ToggleCollapsed) });

            ViewsHelper.AddViewToGridAndExpand(titleGrid, tapBoxView);

            titleGrid.Children.Add(_toggleButton, 1, 0);

            Content = new StackLayout
            {
                Children = { titleGrid, _sectionViewGrid },
                Spacing = 15
            };
        }

        private static string GetTitleSection(EditProfileSections title)
        {
            switch (title)
            {
                case EditProfileSections.UserInfo: return "Личная информация";
                case EditProfileSections.Contacts: return "Контакты";
                default: return null;
            }
        }

        private void ToggleCollapsed()
        {
            _sectionViewGrid.IsVisible = !_sectionViewGrid.IsVisible;
            _toggleButton.Text = _sectionViewGrid.IsVisible ? AwesomeFontIcons.Up : AwesomeFontIcons.Down;
        }

        private static Label GetTitle(string title)
        {
            return new Label
            {
                Text = title,
                TextColor = AppStyles.PrimaryColor,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center
            };
        }

        private static EntryColor GetEntry()
        {
            return new EntryColor
            {
                TextColor = AppStyles.PrimaryColor,
                FontSize = 18
            };
        }
    }
}
