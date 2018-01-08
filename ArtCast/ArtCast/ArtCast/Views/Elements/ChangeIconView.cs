using ArtCast.Styles;
using Xamarin.Forms;

namespace ArtCast.Views.Elements
{
    public class ChangeIconView: ContentView
    {
        public ChangeIconView(string iconSource, string ratingText, bool isSelected)
        {
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition { Height = 40 });
            grid.ColumnSpacing = 0;
            grid.RowSpacing = 0;
            grid.Margin = 0;

            var icon = new Label
            {
                Text = iconSource,
                FontSize = 45,
                FontFamily = AppStyles.FontAwesomeFamily,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Transparent
            };

            if (isSelected) icon.TextColor = AppStyles.PrimaryColor;

            var textLabel = new Label
            {
                Text = ratingText,
                FontSize = 15,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black
            };

            if (isSelected) textLabel.TextColor = AppStyles.PrimaryColor;
            
            grid.Children.Add(textLabel, 0, 1);
            grid.Children.Add(icon, 0, 0);
            Content = grid;
        }
    }
}
