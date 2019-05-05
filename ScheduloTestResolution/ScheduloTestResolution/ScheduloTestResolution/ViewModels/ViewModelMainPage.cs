﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Reactive.Linq;

namespace ScheduloTestResolution.ViewModels
{
    public class ViewModelMainPage : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand ImageViewViewCommand { get; }
        public ICommand ConnectivityViewCommand { get; }
        public ICommand ForumViewCommand { get; }

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
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            SetGreetingText();
        }

        private void SetGreetingText()
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
        }
    }
}
