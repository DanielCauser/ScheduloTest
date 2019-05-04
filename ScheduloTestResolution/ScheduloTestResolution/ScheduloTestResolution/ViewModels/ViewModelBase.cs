using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace ScheduloTestResolution.ViewModels
{
    public class ViewModelBase : ReactiveObject,
                                  INavigatingAware,
                                  INavigatedAware,
                                  IDestructible,
                                  IPageLifecycleAware,
                                  IConfirmNavigationAsync

    {
        CompositeDisposable deactivateWith;
        protected CompositeDisposable DeactivateWith
        {
            get
            {
                if (this.deactivateWith == null)
                    this.deactivateWith = new CompositeDisposable();

                return this.deactivateWith;
            }
        }

        protected CompositeDisposable DestroyWith { get; } = new CompositeDisposable();

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }


        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }


        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }


        public virtual void OnAppearing()
        {
        }


        public virtual void OnDisappearing()
        {
            this.deactivateWith?.Dispose();
            this.deactivateWith = null;
        }


        public virtual void Destroy()
        {
            this.DestroyWith?.Dispose();
        }


        public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters) => Task.FromResult(true);


        [Reactive] public bool IsBusy { get; protected set; }

        protected virtual void RegisterBusyCommand<T, U>(ReactiveCommand<T, U> command) => command
            .IsExecuting
            .Subscribe(x => this.IsBusy = x);
    }
}
