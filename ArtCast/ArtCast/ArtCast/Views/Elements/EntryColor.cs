using ArtCast.Styles;
using Xamarin.Forms;

namespace ArtCast.Views.Elements
{
    public class EntryColor: Entry
    {
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(EntryColor), AppStyles.PrimaryColor);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
    }
}
