using ArtCast.Data;

namespace ArtCast.Models.LoginAndRegister
{
    public class RequestRegisterModel
    {
        public UserTypes UserTypes { get; set; }
        public SpecTypes Specialisation { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
