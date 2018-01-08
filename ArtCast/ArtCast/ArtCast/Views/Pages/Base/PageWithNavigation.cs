using ArtCast.Views.Elements;
using Xamarin.Forms;

namespace ArtCast.Views.Pages.Base
{
    public class PageWithNavigation : BasePage
    {
        private readonly Grid _rootGrid;
        protected TopNavigationBar TopNavigationBar { get; }

        protected PageWithNavigation(string pageTitle, bool hasBackButton = true)
        {
            TopNavigationBar = new TopNavigationBar(pageTitle, hasBackButton);

            _rootGrid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Star},
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto}
                },
                RowSpacing = 0
            };

            _rootGrid.Children.Add(new AppTitle());
            _rootGrid.Children.Add(TopNavigationBar, 0, 1);
            
            Content = _rootGrid;
        }

        protected void AddContent(View content)
        {
            _rootGrid.Children.Add(content, 0, 2);
        }

        protected void AddCoachMarkView(View content)
        {
            _rootGrid.Children.Add(content, 0, 1);
            Grid.SetRowSpan(content, 4);
        }

        public override void SetTitle(string title)
        {
            TopNavigationBar.SetTitle(title);
        }

        protected void RemoveContent(View content)
        {
            if (content != null && _rootGrid.Children.Contains(content))
            {
                _rootGrid.Children.Remove(content);
            }
        }

        protected void SetBottomNavigationBar(View bottomNavigationBar)
        {
            _rootGrid.Children.Add(bottomNavigationBar, 0, 4);
        }

        protected override bool OnBackButtonPressed()
        {
            if (TopNavigationBar.BackButtonCommand != null)
            {
                TopNavigationBar.BackButtonCommand.Execute(null);
                return true;
            }
            return base.OnBackButtonPressed();
        }
    }
}
