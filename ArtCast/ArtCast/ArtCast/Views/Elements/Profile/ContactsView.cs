using ArtCast.Data;
using ArtCast.Models.User;
using ArtCast.Styles;
using System;
using System.Collections.Generic;
using ArtCast.Helpers;
using Xamarin.Forms;

namespace ArtCast.Views.Elements.Profile
{
    public class ContactsView: ContentView
    {
        private readonly StackLayout _buttonStack;

        public ContactsView(List<UserContacts> contacts)
        {
            _buttonStack = new StackLayout{Orientation = StackOrientation.Horizontal, Spacing = 15, Margin = new Thickness(2)};

            foreach (var contact in contacts)
                GetButton(contact);

            Content = _buttonStack;
        }

        private void GetButton(UserContacts contact)
        {
            if (contact.Link.HasValue())
            {
                switch (contact.Type)
                {
                    case Сommunications.Vk: _buttonStack.Children.Add(CreateButton(AwesomeFontIcons.Vk, contact.Link)); break;
                    case Сommunications.Instagram: _buttonStack.Children.Add(CreateButton(AwesomeFontIcons.Instagram, contact.Link)); break;
                    case Сommunications.Whatsup: _buttonStack.Children.Add(CreateButton(AwesomeFontIcons.Whatsup, contact.Link)); break;
                    case Сommunications.Telegram: _buttonStack.Children.Add(CreateButton(AwesomeFontIcons.Telegram, contact.Link)); break;
                    default: _buttonStack.Children.Add(CreateButton(AwesomeFontIcons.Link, contact.Link)); break;
                }
            }
        }

        private static Label CreateButton(string icon, string link)
        {
            var label = new Label
            {
                Text = icon,
                FontFamily = AppStyles.FontAwesomeFamily,
                FontSize = 25,
                TextColor = AppStyles.PrimaryColor
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => { Device.OpenUri(new Uri(link)); };
            label.GestureRecognizers.Add(tapGestureRecognizer);

            return label;
        }
    }
}
