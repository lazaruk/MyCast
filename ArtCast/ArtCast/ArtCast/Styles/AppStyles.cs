using ArtCast.Views.Elements;
using Xamarin.Forms;

namespace ArtCast.Styles
{
    public class AppStyles
    {
        public static Color PrimaryColor = Color.FromRgb(92, 164, 153);
        public static Color MenuTextColor = Color.FromRgb(92, 164, 153); 
        public static Color TopBarTextColor = Color.White;
        public static Color PageBackgroundColor = Color.FromRgb(222, 221, 220);
        public static Color TopBarBackgroundColor = Color.FromRgb(92, 164, 153);
        public static Color MenuButtonColor = Color.FromRgb(92, 164, 153);

        public static double TopNavigationBarFontSize = 25;
        public static double WifiDialogFontSize = 34;

        public static double VeryVerySmallFontSize = 12;
        public static double VerySmallFontSize = 16;
        public static double SmallFontSize = 18;
        public static double MediumFontSize = 20;
        public static double LargeFontSize = 24;
        public static double VeryLargeFontSize = 28;

        public static string LogoImage;
        public static string BackgroundImage;

        public static string FontAwesomeFamily
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS: return "FontAwesome";
                    case Device.Android: return "Fontawesome-webfont.ttf#FontAwesome";
                    case Device.UWP: return "/Assets/Fonts/Fontawesome-webfont.ttf#FontAwesome";
                    default: return "Fontawesome-webfont";
                }
            }
        }

        private static Style _userPictureLabelStyle;
        public static Style UserPictureLabelStyle => _userPictureLabelStyle ?? (_userPictureLabelStyle = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter { Property = Label.FontSizeProperty, Value = 50 },
                new Setter { Property = Label.FontFamilyProperty, Value = FontAwesomeFamily },
                new Setter { Property = Label.TextColorProperty, Value = PrimaryColor },
                new Setter { Property = View.HorizontalOptionsProperty, Value  = LayoutOptions.Center },
                new Setter { Property = View.VerticalOptionsProperty, Value = LayoutOptions.Center }
            }
        });

        private static Style _userInfoLabelStyle;
        public static Style UserInfoLabelStyle => _userInfoLabelStyle ?? (_userInfoLabelStyle = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter { Property = Label.FontSizeProperty, Value = 20 },
                new Setter { Property = Label.TextColorProperty, Value = Color.Black },
                new Setter { Property = View.HorizontalOptionsProperty, Value  = LayoutOptions.Start },
                new Setter { Property = View.VerticalOptionsProperty, Value = LayoutOptions.Start }
            }
        });

        private static Style _separatorStyle;
        public static Style SeparatorStyle => _separatorStyle ?? (_separatorStyle = new Style(typeof(BoxView))
        {
            Setters =
            {
                new Setter { Property = BoxView.ColorProperty, Value = PrimaryColor },
                new Setter { Property = VisualElement.HeightRequestProperty, Value = 2 },
                new Setter { Property = View.HorizontalOptionsProperty, Value  = LayoutOptions.FillAndExpand }
            }
        });

        private static Style _loginAndRegisterButtonStyle;
        public static Style LoginAndRegisterButtonStyle => _loginAndRegisterButtonStyle ?? (_loginAndRegisterButtonStyle = new Style(typeof(ButtonWithoutStyles))
        {
            Setters =
            {
                new Setter { Property = Button.TextColorProperty, Value = Color.White },
                new Setter { Property = Button.FontSizeProperty, Value = 10 },
                new Setter { Property = VisualElement.BackgroundColorProperty, Value = PrimaryColor },
                new Setter { Property = View.VerticalOptionsProperty, Value = LayoutOptions.FillAndExpand },
                new Setter { Property = Button.BorderRadiusProperty, Value = 6 },
                new Setter { Property = VisualElement.WidthRequestProperty, Value = 100},
                new Setter { Property = VisualElement.HeightRequestProperty, Value = 35}
            }
        });

        private static Style _buttonWithFontIconTextStyle;
        public static Style ButtonWithFontIconTextStyle => _buttonWithFontIconTextStyle ?? (_buttonWithFontIconTextStyle = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter { Property = View.HorizontalOptionsProperty, Value = LayoutOptions.Center },
                new Setter { Property = View.VerticalOptionsProperty, Value = LayoutOptions.Start }
            }
        });

        private static Style _backButtonStyle;
        public static Style BackButtonStyle => _backButtonStyle ?? (_backButtonStyle = new Style(typeof(ButtonWithFontIcon))
        {
            Setters =
            {
                new Setter { Property = VisualElement.WidthRequestProperty, Value = 110 },
                new Setter { Property = VisualElement.HeightRequestProperty, Value = 45 },
                new Setter { Property = VisualElement.BackgroundColorProperty, Value = TopBarBackgroundColor}
            }
        });
    }
}
