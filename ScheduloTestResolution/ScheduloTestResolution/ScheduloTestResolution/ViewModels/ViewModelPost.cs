using System;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;

namespace ScheduloTestResolution.ViewModels
{
    public class ViewModelPost : ViewModelBase
    {
        [Reactive] public ModelPost SelectedPost { get; set; }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.TryGetValue<ModelPost>(nameof(ModelPost), out var selectedPost))
                SelectedPost = selectedPost;
        }
    }
}
