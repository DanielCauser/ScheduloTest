using System;
using System.Windows.Input;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Xamarin.Forms;

namespace ScheduloTestResolution.ViewModels
{
    public class ViewModelShowImage : ViewModelBase
    {
        private string FileName => $"{new Random().Next(100000)}.jpg";

        [Reactive] public string ImageUrl { get; set; }
        public ICommand CommandNewImage { get; }

        public ViewModelShowImage()
        {
            this.CommandNewImage = ReactiveCommand.Create(() =>
            {
                ImageUrl = $"http://loremflickr.com/600/600/nature?filename={FileName}";
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            CommandNewImage.Execute(null);
        }
    }
}
