using ArtCast.Styles;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArtCast.Views.Templates.Cells
{
    public class ItemCell : ViewCell
    {
        public static BindableProperty IconProperty = BindableProperty.Create("Icon", typeof(string), typeof(ItemCell));
        public static BindableProperty IconSizeProperty = BindableProperty.Create("IconSize", typeof(int), typeof(ItemCell), 25);
        public static BindableProperty IconMarginLeftProperty = BindableProperty.Create("IconMarginLeft", typeof(double), typeof(ItemCell), default(double));
        public static BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(ItemCell));
        public static BindableProperty TextMarginProperty = BindableProperty.Create("TextMargin", typeof(Thickness), typeof(ItemCell), new Thickness(0));
        public static BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(ItemCell));
        public static BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(ItemCell));
        public static BindableProperty IconFontFamilyProperty = BindableProperty.Create(nameof(IconFontFamily), typeof(string), typeof(ItemCell));

        private readonly Label _icon;
        private readonly Label _text;
        private readonly TapGestureRecognizer _recognizer;

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public string IconFontFamily
        {
            get => (string)GetValue(IconFontFamilyProperty);
            set => SetValue(IconFontFamilyProperty, value);
        }

        public int IconSize
        {
            get => (int)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public double IconMarginLeft
        {
            get => (double)GetValue(IconMarginLeftProperty);
            set => SetValue(IconMarginLeftProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Thickness TextMargin
        {
            get => (Thickness)GetValue(TextMarginProperty);
            set => SetValue(TextMarginProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public ItemCell()
        {
            var grid = new Grid { Padding = new Thickness(5)};
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            _icon = new Label
            {
                TextColor = AppStyles.PrimaryColor,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalTextAlignment = TextAlignment.Center
            };

            _text = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                TextColor = AppStyles.MenuTextColor
            };

            grid.Children.Add(_icon, 0, 0);
            grid.Children.Add(_text, 1, 0);

            _recognizer = new TapGestureRecognizer();

            View = grid;
            View.GestureRecognizers.Add(_recognizer);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                _icon.Text = Icon;
                _icon.FontSize = IconSize;
                _icon.Margin = new Thickness(IconMarginLeft, 0, 0, 0);
                _icon.FontFamily = IconFontFamily;
                _text.Text = Text;
                _text.Margin = TextMargin;
                _recognizer.Command = Command;
                _recognizer.CommandParameter = CommandParameter;
            }
        }
    }
}
