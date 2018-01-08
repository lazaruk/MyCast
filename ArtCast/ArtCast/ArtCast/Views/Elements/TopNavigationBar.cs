using ArtCast.Styles;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArtCast.Views.Elements
{
    public class TopNavigationBar: ToolBar
    {
        private readonly ButtonWithFontIcon _backButton;
        private readonly Label _titleLabel;

        public TopNavigationBar(string title, bool hasBackButton = true)
        {
            if (hasBackButton)
            {
                var backButtonCommand = App.Current.Navigation.NavigateBackCommand;
                _backButton = new ButtonWithFontIcon(new BackButtonInfo(backButtonCommand))
                {
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center
                };
                LeftItems = new List<View> { _backButton };
            }
            else LeftItems = new List<View>();

            CenterItem = _titleLabel = new Label
            {
                Text = title,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20,
                TextColor = AppStyles.TopBarTextColor
            };

            HeightRequest = 45;
            Padding = new Thickness(50, 0);
            BackgroundColor = AppStyles.TopBarBackgroundColor;
            Margin = new Thickness(0, 0, 0, -1);
        }

        public void SetTitle(string title)
        {
            _titleLabel.Text = title;
        }

        public ICommand BackButtonCommand
        {
            get => _backButton?.Command;
            set { if (_backButton != null) _backButton.Command = value; }
        }
    }
}
