using System;
using System.Collections.Generic;
using ArtCast.Data;

namespace ArtCast.Models.User
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Citizenship { get; set; }
        public bool Intpassport { get; set; }
        public string Experience { get; set; }
        public List<UserContacts> Contacts { get; set; }
        public Specializations Specialization { get; set; }
        public UserTypes UserType { get; set; }
        public string SourcePrimaryPhoto { get; set; }
        public List<string> SourcePhotos { get; set; }
    }

    public class UserContacts
    {
        public Сommunications Type { get; set; }
        public string Link { get; set; }
    } 
}
