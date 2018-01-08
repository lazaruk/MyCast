using Android.Graphics.Drawables;
using ArtCast.Droid.Renderers;
using ArtCast.Views.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ContentViewRoundedCorners), typeof(ContentViewRoundedCornersRenderer))]
namespace ArtCast.Droid.Renderers
{
    public class ContentViewRoundedCornersRenderer : VisualElementRenderer<ContentViewRoundedCorners>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ContentViewRoundedCorners> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
                return;

            var roundedBackground = new GradientDrawable();
            roundedBackground.SetCornerRadius((float)Element.CornerRadius);
            roundedBackground.SetColor(Element.BackgroundColor.ToAndroid());
            Background = roundedBackground;
        }
    }
}