using ArtCast.Data;
using ArtCast.Models.User;
using ArtCast.Styles;
using Xamarin.Forms;

namespace ArtCast.Views.Elements.Profile
{
    public class HeaderProfileView: ContentView
    {
        public HeaderProfileView(UserModel user)
        {
            var photo = new Image
            {
                Source = user.SourcePrimaryPhoto,
                WidthRequest = 120,
                HeightRequest = 120
            };

            var name = new Label
            {
                Text = user.Name,
                Style = AppStyles.LabelProfileStyle
            };

            var spec = new Label
            {
                Text = GetSpecialization(user.Specialization),
                Style = AppStyles.LabelProfileStyle
            };

            var contacts = new ContactsView(user.Contacts);

            var infogrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition{Width = GridLength.Auto},
                    new ColumnDefinition{Width = GridLength.Star}
                },
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{Height = GridLength.Auto},
                    new RowDefinition{Height = GridLength.Auto},
                    new RowDefinition{Height = GridLength.Auto}
                },
                RowSpacing = 15,
                ColumnSpacing = 15,
                Margin = 15
            };

            infogrid.Children.Add(photo);
            Grid.SetRowSpan(photo, 3);
            infogrid.Children.Add(name, 1, 0);
            infogrid.Children.Add(spec, 1, 1);
            infogrid.Children.Add(contacts, 1, 2);

            Content = infogrid;
        }

        private string GetSpecialization(Specializations specialization)
        {
            switch (specialization)
            {
                case Specializations.Model:  return "Модель";
                case Specializations.Photographer: return "Фотограф";
                default: return "Добавить";
            }
        }
    }
}
