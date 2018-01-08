using System.Collections.Generic;
using Xamarin.Forms;

namespace ArtCast.Views.Elements
{
    public class ToolBar: ContentView
    {
        private readonly StackLayout _leftLayout;
        private readonly StackLayout _rightLayout;
        private readonly ContentView _centerView;

        public List<View> LeftItems
        {
            set
            {
                _leftLayout.Children.Clear();
                if (value == null) return;

                foreach (var item in value)
                {
                    _leftLayout.Children.Add(item);
                }
            }
        }

        public List<View> RightItems
        {
            set
            {
                _rightLayout.Children.Clear();
                if (value == null) return;

                foreach (var item in value)
                {
                    _rightLayout.Children.Add(item);
                }
            }
        }

        public View CenterItem
        {
            set => _centerView.Content = value;
        }

        public ToolBar()
        {
            _leftLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };

            _rightLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0, 1, 0, 0)
            };

            _centerView = new ContentView
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0, 1, 0, 0)
            };

            var grid = new Grid();
            grid.Children.Add(_leftLayout);
            grid.Children.Add(_centerView);
            grid.Children.Add(_rightLayout);

            Content = grid;
        }
    }
}
