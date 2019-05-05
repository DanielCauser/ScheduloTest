using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using DynamicData;
using System.Linq;
using Prism.Navigation;
using System.Reactive.Linq;

namespace ScheduloTestResolution.ViewModels
{
    public class ViewModelForum : ViewModelBase
    {
        private readonly IServiceForum _serviceForum;
        private readonly INavigationService _navigationService;

        public ViewModelForum(IServiceForum serviceForum,
            INavigationService navigationService)
        {
            this._serviceForum = serviceForum;
            this._navigationService = navigationService;
            this.Posts = new ObservableCollection<ModelPost>();

            this.LoadDataCommand = ReactiveCommand.Create<string>(filter =>
            {
                Posts.Clear();
                Posts.AddRange(_serviceForum.GetMatchingPosts(filter));
            });

            this.ItemTappedCommand = ReactiveCommand.CreateFromTask<ModelPost>(async selectedItem =>
            {
                var navigationParams = new NavigationParameters();
                navigationParams.Add(nameof(ModelPost), selectedItem);
                await _navigationService.NavigateAsync("ViewPost", navigationParams);
            });

            this.WhenAnyValue(x => x.SearchText)
                .InvokeCommand(LoadDataCommand);
        }

        [Reactive] public string SearchText { get; set; }
        [Reactive] public ObservableCollection<ModelPost> Posts { get; set; }

        public ICommand ItemTappedCommand { get; }
        public ICommand LoadDataCommand { get; }
    }
}
