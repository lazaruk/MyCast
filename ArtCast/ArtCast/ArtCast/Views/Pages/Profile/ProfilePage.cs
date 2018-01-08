using System.Collections.Generic;
using ArtCast.Data;
using ArtCast.Models.User;
using ArtCast.Styles;
using ArtCast.Views.Elements.Profile;
using ArtCast.Views.Pages.Base;
using Xamarin.Forms;

namespace ArtCast.Views.Pages.Profile
{
    public class ProfilePage: PageWithNavigation
    {
        public ProfilePage():base("Профиль", false)
        {
            var conatctsList = new List<UserContacts> //todo from bd
            {
                new UserContacts {Type = Сommunications.Vk, Link = "https://vk.com/id68543836"},
                new UserContacts {Type = Сommunications.Instagram, Link = "https://www.instagram.com/_lazaruk_/"},
                new UserContacts {Type = Сommunications.Telegram, Link = "https://t.me/lazaruk_karina"}, //tg://resolve?domain=имя
                new UserContacts {Type = Сommunications.Whatsup, Link = "https://api.whatsapp.com/send?phone=375333882442"}, //whatsapp://send?phone=79xxxxxxxxx
                new UserContacts {Type = Сommunications.Site, Link = "https://vk.com/id68543836"},
                new UserContacts {Type = Сommunications.Viber, Link = ""} //viber://chat?number=+375333882442
            };

            var photosList = new List<string>
            {
                "https://pp.userapi.com/c841321/v841321113/46e8d/ggVVLr6cLyw.jpg",
                "https://pp.userapi.com/c837724/v837724665/6a123/Ms-m1qgJUDY.jpg",
                "https://pp.userapi.com/c621706/v621706836/1930/IrtrpDP7yjk.jpg",
                "https://pp.userapi.com/c841321/v841321113/46e8d/ggVVLr6cLyw.jpg",
                "https://pp.userapi.com/c837724/v837724665/6a123/Ms-m1qgJUDY.jpg",
                "https://pp.userapi.com/c621706/v621706836/1930/IrtrpDP7yjk.jpg",
                "https://pp.userapi.com/c841321/v841321113/46e8d/ggVVLr6cLyw.jpg",
                "https://pp.userapi.com/c837724/v837724665/6a123/Ms-m1qgJUDY.jpg",
                "https://pp.userapi.com/c621706/v621706836/1930/IrtrpDP7yjk.jpg",
                "https://pp.userapi.com/c841321/v841321113/46e8d/ggVVLr6cLyw.jpg",
                "https://pp.userapi.com/c837724/v837724665/6a123/Ms-m1qgJUDY.jpg",
                "https://pp.userapi.com/c621706/v621706836/1930/IrtrpDP7yjk.jpg"
            };

            var user = new UserModel
            {
                Login = "lazaruk.kl@gmail.com",
                SourcePrimaryPhoto = "https://pp.userapi.com/c638831/v638831371/5a0f5/e1hsPbSCFG4.jpg",
                SourcePhotos = photosList, Name = "Карина Лазарук",
                Specialization = Specializations.Model,
                UserType = UserTypes.Worker,
                Contacts = conatctsList
            };
            
            var header = new HeaderProfileView(user);
            
            var photos = new PhotoProfileView(user.SourcePhotos);

            var content = new StackLayout
            {
                Children = { header, GetSeparator(), photos, GetSeparator() }
            };
            
            AddContent(content);
        }

        private BoxView GetSeparator()
        {
            return new BoxView { Style = AppStyles.SeparatorStyle };
        }
    }
}
