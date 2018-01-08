using Xamarin.Forms;

namespace ArtCast.Helpers
{
    public static class ViewsHelper
    {
        public static void UpdateConstraintsBasedOnWidthOrHeight(RelativeLayout layout, View view)
        {
            view.PropertyChanged += (s, e) => { if (e.PropertyName == "Width" || e.PropertyName == "Height") layout.ForceLayout(); };
        }
    }
}
