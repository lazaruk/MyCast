using Xamarin.Forms;

namespace ArtCast.Helpers
{
    public static class ViewsHelper
    {
        public static void UpdateConstraintsBasedOnWidthOrHeight(RelativeLayout layout, View view)
        {
            view.PropertyChanged += (s, e) => { if (e.PropertyName == "Width" || e.PropertyName == "Height") layout.ForceLayout(); };
        }

        public static void AddViewToGridAndExpand(Grid grid, View view)
        {
            grid.Children.Add(view);
            if (grid.RowDefinitions.Count > 0) Grid.SetRowSpan(view, grid.RowDefinitions.Count);
            if (grid.ColumnDefinitions.Count > 0) Grid.SetColumnSpan(view, grid.ColumnDefinitions.Count);
        }

        public static void ClearGrid(Grid grid)
        {
            grid.Children.Clear();
            ClearRowsAndColumnsInGrid(grid);
        }

        public static void ClearRowsAndColumnsInGrid(Grid grid)
        {
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
        }

        public static void AddViewToGridOrSetPosition(Grid grid, View view, int left, int top, int? rowSpan = null, int? columnSpan = null)
        {
            if (!grid.Children.Contains(view)) grid.Children.Add(view, left, top);
            else
            {
                Grid.SetRow(view, top);
                Grid.SetColumn(view, left);
            }
            if (rowSpan.HasValue) Grid.SetRowSpan(view, rowSpan.Value);
            if (columnSpan.HasValue) Grid.SetColumnSpan(view, columnSpan.Value);
        }
    }
}
