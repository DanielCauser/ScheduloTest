using System;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System.Windows.Input;
using System.Reactive.Linq;
using ScheduloTestResolution.Services;

namespace ScheduloTestResolution.ViewModels
{
    public class ViewModelPost : ViewModelBase
    {
        private readonly IServiceForum _serviceForum;
        private readonly IServiceUser _serviceUser;

        public ViewModelPost(IServiceForum serviceForum,
            IServiceUser serviceUser)
        {
            this._serviceForum = serviceForum;
            this._serviceUser = serviceUser;

            this.LoadDataCommand = ReactiveCommand.Create<int>(id =>
            {
                SelectedPost = _serviceForum.GetById(id);
                UserName = _serviceUser.GetUserNameById(SelectedPost.UserId);
            });

            this.WhenAnyValue(x => x.SelectedId)
                .InvokeCommand(LoadDataCommand);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.TryGetValue<int>($"{nameof(ModelPost)}Id", out var selectedPostId))
                SelectedId = selectedPostId;
        }

        [Reactive] public ModelPost SelectedPost { get; set; }
        [Reactive] public int SelectedId { get; set; }
        [Reactive] public string UserName { get; set; }

        public ICommand LoadDataCommand { get; private set; }
    }
}
