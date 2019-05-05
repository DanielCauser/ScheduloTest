using System;
using System.Reactive.Linq;
using Prism.Navigation;
using Xamarin.Essentials;
using System.Windows.Input;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System.Reactive;
using System.Diagnostics;

namespace ScheduloTestResolution.ViewModels
{
    public class ViewModelConnectivity : ViewModelBase
    {
        [Reactive] public string ConnectionStatus { get; set; }

        public ICommand ConnectionChangeCommand { get; }

        public ViewModelConnectivity()
        {
            ConnectionChangeCommand = ReactiveCommand.Create<NetworkAccess>(status =>
                {
                    if (status == NetworkAccess.Internet)
                        this.ConnectionStatus = "Connected";
                    else
                        this.ConnectionStatus = "Disconnected";
                });
        }

        void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            ConnectionChangeCommand.Execute(e.NetworkAccess);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
            ConnectionChangeCommand.Execute(Connectivity.NetworkAccess);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        }
    }
}
