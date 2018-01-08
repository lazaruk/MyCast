using Rg.Plugins.Popup.Pages;
using System;

namespace ArtCast.Views.Pages.Base
{
    public class BasePopup : PopupPage
    {
        public bool IsClosed { get; private set; }

        public event EventHandler Closing;

        protected override void OnDisappearing()
        {
            Closing?.Invoke(this, EventArgs.Empty);
            base.OnDisappearing();
            IsClosed = true;
        }
    }
}
