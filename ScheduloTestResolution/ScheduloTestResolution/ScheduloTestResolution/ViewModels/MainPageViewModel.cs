using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ScheduloTestResolution.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
        {
            this.ThrowExceptionCommand = ReactiveCommand.Create(() => throw new Exception());
        }

        public ICommand ThrowExceptionCommand { get; }
    }
}
