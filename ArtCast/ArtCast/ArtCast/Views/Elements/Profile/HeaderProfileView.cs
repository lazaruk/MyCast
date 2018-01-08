using System.Collections.Generic;
using ArtCast.Data;
using ArtCast.Models.User;
using ArtCast.Styles;
using Xamarin.Forms;

namespace ArtCast.Views.Elements.Profile
{
    public class HeaderProfileView: ContentView
    {
        public HeaderProfileView()
        {
            var conatctsList = new List<UserContacts> //todo from bd
            {
                new UserContacts {Type = Сommunications.Vk, Link = "https://vk.com/id68543836"},
                new UserContacts {Type = Сommunications.Instagram, Link = "https://www.instagram.com/_lazaruk_/"},
                new UserContacts {Type = Сommunications.Telegram, Link = "https://t.me/lazaruk_karina"}, //tg://resolve?domain=имя
                new UserContacts {Type = Сommunications.Whatsup, Link = "https://api.whatsapp.com/send?phone=375333882442"}, //whatsapp://send?phone=79xxxxxxxxx
                new UserContacts {Type = Сommunications.Site, Link = ""},
                new UserContacts {Type = Сommunications.Viber, Link = ""} //viber://chat?number=+375333882442
            };

            var photo = new Image
            {
                Source = "noava.jpg", //todo BD
                WidthRequest = 120,
                HeightRequest = 120
            };

            var name = new Label
            {
                Text = "Имя Фамилия",
                Style = AppStyles.LabelProfileStyle
            };

            var spec = new Label
            {
                Text = "Специализация",
                Style = AppStyles.LabelProfileStyle
            };

            var contacts = new ContactsView(conatctsList);

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
    }
}
