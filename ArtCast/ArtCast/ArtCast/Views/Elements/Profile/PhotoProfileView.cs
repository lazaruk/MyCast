using System.Collections.Generic;
using Xamarin.Forms;

namespace ArtCast.Views.Elements.Profile
{
    public class PhotoProfileView: ContentView
    {
        public PhotoProfileView(List<string> photos)
        {
            var itemsStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center
            };

            foreach (var photo in photos)
            {
                itemsStack.Children.Add(GetBox(photo));
            } 
            
            Content = new ScrollView
            {
                Orientation = ScrollOrientation.Horizontal,
                Content = itemsStack
            };
        }

        private Image GetBox(string source)
        {
            return new Image
            {
                WidthRequest = 100,
                HeightRequest = 100,
                Source = source
            };
        }
    }
}
