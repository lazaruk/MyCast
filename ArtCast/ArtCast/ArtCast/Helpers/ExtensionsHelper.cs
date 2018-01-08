using System.Collections.Generic;
using System.Linq;

namespace ArtCast.Helpers
{
    public static class ExtensionsHelper
    {
        public static bool HasItems<T>(this IEnumerable<T> items)
        {
            return items != null && items.Any();
        }

        public static bool HasValue(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
