using Xamarin.Forms;

namespace ArtCast.Views.Elements
{
    public class ContentViewRoundedCorners : ContentView
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadius", typeof(double), typeof(ContentViewRoundedCorners), 0.0, BindingMode.Default);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
}
