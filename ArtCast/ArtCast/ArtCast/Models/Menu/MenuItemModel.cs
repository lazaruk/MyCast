using System.Windows.Input;
using Xamarin.Forms;

namespace ArtCast.Models.Menu
{
    public class MasterPageItem
    {
        public string Icon { get; set; }
        public string IconFontFamily { get; set; }
        public int IconSize { get; set; }
        public double IconMarginLeft { get; set; }
        public string Text { get; set; }
        public Thickness TextMargin { get; set; }
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
    }
}
