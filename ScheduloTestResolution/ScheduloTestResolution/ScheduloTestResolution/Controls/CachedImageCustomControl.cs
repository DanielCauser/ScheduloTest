using System;
using Xamarin.Forms;
using FFImageLoading.Forms;
using System.Runtime.CompilerServices;

namespace ScheduloTestResolution.Controls
{
    public class CachedImageCustomControl : CachedImage
    {
        public static readonly BindableProperty IsFailedProperty =
            BindableProperty.Create(nameof(IsFailed),
                                    typeof(bool),
                                    typeof(CachedImageCustomControl),
                                    false);

        public new static readonly BindableProperty IsLoadingProperty =
            BindableProperty.Create(nameof(IsLoading),
                                    typeof(bool),
                                    typeof(CachedImageCustomControl),
                                    false);

        public bool IsFailed
        {
            get => (bool)GetValue(IsFailedProperty);
            set => SetValue(IsFailedProperty, value);
        }

        public new bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }

        protected override void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            if (propertyName == nameof(Source))
            {
                Error += OnImageLoadFailed;
                Success += OnImageLoadSucceeded;
                DownloadStarted += OnImageDownloadStarted;
            }
            base.OnPropertyChanging(propertyName);
        }

        private void OnImageDownloadStarted(object sender, EventArgs e)
        {
            IsLoading = true;
            IsFailed = false;
            IsVisible = false;
            DownloadStarted -= OnImageDownloadStarted;
        }

        private void OnImageLoadFailed(object sender, EventArgs args)
        {
            IsLoading = false;
            IsFailed = true;
            IsVisible = false;
            Error -= OnImageLoadFailed;
            Success -= OnImageLoadSucceeded;
            DownloadStarted -= OnImageDownloadStarted;
        }

        private void OnImageLoadSucceeded(object sender, EventArgs args)
        {
            IsLoading = false;
            IsFailed = false;
            IsVisible = true;
            Success -= OnImageLoadSucceeded;
            Error -= OnImageLoadFailed;
            DownloadStarted -= OnImageDownloadStarted;
        }
    }
}
