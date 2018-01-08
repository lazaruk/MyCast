using ArtCast.Helpers;
using ArtCast.Styles;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArtCast.Views.Elements
{
    public class ButtonWithFontIcon: ContentViewRoundedCorners
    {
        private readonly TapGestureRecognizer _tap;
        private readonly Label _iconLabel, _textLabel;

        public ButtonWithFontIcon(ButtonWithFontIconInfo info, bool withScaling = true)
        {
            var layout = new RelativeLayout();
            _iconLabel = new Label
            {
                Text = info.Icon,
                TextColor = info.TextColor,
                FontFamily = info.IconFontFamily,
                FontSize = withScaling ? 25 : info.IconSize,
                Margin = new Thickness(10, 0, 0, 0)
            };
            _textLabel = new Label
            {
                Text = info.Text,
                TextColor = info.TextColor,
                Style = AppStyles.ButtonWithFontIconTextStyle,
                FontFamily = info.TextFontFamily,
                FontSize = withScaling ? 25 : info.TextSize,
                HorizontalTextAlignment = TextAlignment.Center
            };
            if (info.Position == ButtonWithFontIconInfo.FontIconPosition.Top)
            {
                layout.Children.Add(_iconLabel,
                    Constraint.RelativeToParent(p => Math.Round((p.Width - _iconLabel.Width) / 2)),
                    Constraint.RelativeToParent(p => Math.Round(p.Height * info.IconPosition - _iconLabel.Height / 2)));
                ViewsHelper.UpdateConstraintsBasedOnWidthOrHeight(layout, _iconLabel);

                layout.Children.Add(_textLabel,
                    Constraint.RelativeToParent(p => Math.Round((p.Width - _textLabel.Width) / 2)),
                    Constraint.RelativeToParent(p => Math.Round(p.Height * info.TextPosition)));
                ViewsHelper.UpdateConstraintsBasedOnWidthOrHeight(layout, _textLabel);
            }
            else if (info.Position == ButtonWithFontIconInfo.FontIconPosition.Left)
            {

                layout.Children.Add(_iconLabel,
                    Constraint.RelativeToParent(p => Math.Round(p.Width * info.IconPosition - _iconLabel.Width / 2)),
                    Constraint.RelativeToParent(p => Math.Round((p.Height - _iconLabel.Height) / 2)));
                ViewsHelper.UpdateConstraintsBasedOnWidthOrHeight(layout, _iconLabel);

                layout.Children.Add(_textLabel,
                    Constraint.RelativeToParent(p => Math.Round(p.Width * info.TextPosition)),
                    Constraint.RelativeToParent(p => Math.Round((p.Height - _textLabel.Height) / 2)));
                ViewsHelper.UpdateConstraintsBasedOnWidthOrHeight(layout, _textLabel);
            }

            _tap = new TapGestureRecognizer { Command = info.Command, CommandParameter = info.CommandParameter };
            GestureRecognizers.Add(_tap);
            Style = info.Style;
            CornerRadius = info.CornerRadius;
            Content = layout;
        }

        public ICommand Command
        {
            get => _tap.Command;
            set => _tap.Command = value;
        }

        public Color TextColor
        {
            get => _textLabel.TextColor;
            set => _textLabel.TextColor = _iconLabel.TextColor = value;
        }
    }
}
