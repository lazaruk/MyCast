using ArtCast.Data;

namespace ArtCast.Models.LoginAndRegister
{
    public class AnswerUserRegisterModel //todo rename
    {
        public UserTypes User { get; set; }
        public string Text { get; set; }
    }

    public class AnswerSpecspecializationRegisterModel //todo rename
    {
        public TypeBusiness Specspecialization { get; set; }
        public string Text { get; set; }
    }
}
