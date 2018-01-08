using Android.OS;
using ArtCast.Droid.Renderers;
using ArtCast.Views.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ButtonWithoutStyles), typeof(ButtonWithoutStylesRenderer))]
namespace ArtCast.Droid.Renderers
{
    public class ButtonWithoutStylesRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetPadding(0, 0, 0, 0);
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) Control.StateListAnimator = null;
                Control.SoundEffectsEnabled = false;
            }
        }
    }
}