using ArtCast.Data;
using ArtCast.Styles;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArtCast.Views.Elements
{
    public class ButtonWithFontIconInfo
    {
        public string Icon { get; set; }
        public string IconFontFamily { get; set; }
        public string Text { get; set; }
        public string TextFontFamily { get; set; }
        public FontIconPosition Position { get; set; }
        public double IconPosition { get; set; }
        public double TextPosition { get; set; }
        public int IconSize { get; set; }
        public int TextSize { get; set; }
        public double IconMarginLeft { get; set; }
        public Color TextColor { get; set; }
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
        public Style Style { get; set; }
        public float CornerRadius { get; set; }

        public ButtonWithFontIconInfo() { }

        public ButtonWithFontIconInfo(string text, int textSize, string icon, int iconSize)
        {
            Text = text;
            TextSize = textSize;
            Icon = icon;
            IconSize = iconSize;
            //TextFontFamily = AppStyles.;
            IconFontFamily = AppStyles.FontAwesomeFamily;
        }

        public enum FontIconPosition
        {
            Left,
            Top
        }
    }

    public class BackButtonInfo : ButtonWithFontIconInfo
    {
        public BackButtonInfo(ICommand command) : base("Back", (int)AppStyles.TopNavigationBarFontSize, AwesomeFontIcons.Previous, 20)
        {
            Position = FontIconPosition.Left;
            IconPosition = 0.2;
            TextPosition = 0.4;
            TextColor = AppStyles.TopBarTextColor;
            Command = command;
            Style = AppStyles.BackButtonStyle;
        }
    }
}
