using ArtCast.iOS.Renderers;
using ArtCast.Views.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentViewRoundedCorners), typeof(ContentViewRoundedCornersRenderer))]
namespace ArtCast.iOS.Renderers
{
    public class ContentViewRoundedCornersRenderer : VisualElementRenderer<ContentViewRoundedCorners>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ContentViewRoundedCorners> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
                return;

            Layer.CornerRadius = (float)Element.CornerRadius;
            Layer.MasksToBounds = true;
        }
    }
}