using System;
using ArtCast.Views;

namespace ArtCast.Helpers
{
    public class NavigationHelper
    {
        public static Type GetSectionRootPageTypeForPage(Type pageType)
        {
            if (pageType == typeof(StartPage)) return typeof(StartPage);
            return null;
        }

        public static string GetPageName(Type type)
        {
            var index = type.Name.IndexOf("Page");
            return index > 0 ? type.Name.Substring(0, index) : type.Name;
        }
    }
}
