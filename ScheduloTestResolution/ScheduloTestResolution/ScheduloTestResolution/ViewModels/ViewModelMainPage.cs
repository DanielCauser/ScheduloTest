using System;
using System.Windows.Input;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ScheduloTestResolution.ViewModels
{
    public class ViewModelMainPage : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand ImageViewViewCommand { get; }
        public ICommand ConnectivityViewCommand { get; }
        public ICommand ForumViewCommand { get; }
        public ICommand SetGreetingsCommand { get; }

        [Reactive] public string Greeting { get; set; }

        public ViewModelMainPage(INavigationService navigationService)
        {
            this._navigationService = navigationService;

            this.ImageViewViewCommand = ReactiveCommand.CreateFromTask(async () =>
                await _navigationService.Navigate("ViewShowImage"));

            this.ConnectivityViewCommand = ReactiveCommand.CreateFromTask(async () =>
                await _navigationService.NavigateAsync("ViewConnectivity"));

            this.ForumViewCommand = ReactiveCommand.CreateFromTask(async () =>
                await _navigationService.NavigateAsync("ViewForum"));

            this.SetGreetingsCommand = ReactiveCommand.Create(() =>
            {
                if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 10)
                    Greeting = "Good morning!";
                else if (DateTime.Now.Hour > 10 && DateTime.Now.Hour <= 14)
                {
                    string[] Titles = { "Hello!", "Hi!", "Hey!" };
                    Greeting = Titles[new Random().Next(0, Titles.Length)];
                }
                else if (DateTime.Now.Hour > 14 && DateTime.Now.Hour <= 16)
                    Greeting = "Good afternoon!";
                else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 23)
                    Greeting = "Good evening!";
            });
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            SetGreetingsCommand.Execute(null);
        }
    }
}
