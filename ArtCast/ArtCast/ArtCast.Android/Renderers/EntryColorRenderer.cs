using Android.Content.Res;
using ArtCast.Droid.Renderers;
using ArtCast.Views.Elements;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryColor), typeof(EntryColorRenderer))]
namespace ArtCast.Droid.Renderers
{
    public class EntryColorRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var element = e.NewElement as EntryColor;
                //Control.BackgroundTintList = ColorStateList.ValueOf(element.BorderColor.ToAndroid());
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var element = (EntryColor)Element;

            if (e.PropertyName == EntryColor.BorderColorProperty.PropertyName)
            {
                Control.BackgroundTintList = ColorStateList.ValueOf(element.BorderColor.ToAndroid());
                Control.Background.InvalidateSelf();
            }
        }
    }
}