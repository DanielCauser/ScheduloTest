using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using ReactiveUI;

namespace ScheduloTestResolution
{
    public static class Extensions
    {
        public static ICommand GoBackCommand(this INavigationService nav, bool toRoot = false, Func<(string, object)[]> getArgs = null)
            => ReactiveCommand.CreateFromTask(async _ => await nav.GoBack(toRoot, getArgs?.Invoke()));


        public static ICommand NavigateCommand(this INavigationService nav, string uri, Func<(string, object)[]> getArgs = null)
            => ReactiveCommand.CreateFromTask(async _ =>
            {
                var args = getArgs?.Invoke();
                await nav.Navigate(uri, args);
            });

        public static ICommand NavigateModalCommand(this INavigationService nav, string uri, Func<(string, object)[]> getArgs = null)
            => ReactiveCommand.CreateFromTask(async _ =>
            {
                var args = getArgs?.Invoke();
                await nav.NavigateModal(uri, args);
            });


        public static async Task Navigate(this INavigationService nav, string uri, params (string, object)[] args)
        {
            var result = await nav.NavigateAsync(uri, ToParameters(args));
            result.Assert();
        }

        public static async Task NavigateModal(this INavigationService nav, string uri, params (string, object)[] args)
        {
            var result = await nav.NavigateAsync(uri, ToParameters(args), useModalNavigation: true);
            result.Assert();
        }


        public static void Assert(this INavigationResult result)
        {
            if (!result.Success)
                Console.WriteLine(result.Exception);
            //throw new ArgumentException("Navigation Error", result.Exception);
        }


        public static async Task GoBack(this INavigationService nav, bool toRoot = false, params (string, object)[] args)
        {
            var parms = ToParameters(args);
            var task = toRoot ? nav.GoBackToRootAsync(parms) : nav.GoBackAsync(parms);
            var result = await task;
            result.Assert();
        }


        public static INavigationParameters ToParameters(params (string, object)[] args)
        {
            var parms = new NavigationParameters();
            if (args != null)
                foreach (var arg in args)
                    parms.Add(arg.Item1, arg.Item2);

            return parms;
        }


        public static IDisposable SubOnMainThread<T>(this IObservable<T> obs, Action<T> onNext)
            => obs
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(onNext);


        public static IDisposable SubOnMainThread<T>(this IObservable<T> obs, Action<T> onNext, Action<Exception> onError)
            => obs
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(onNext, onError);


        public static IDisposable SubOnMainThread<T>(this IObservable<T> obs, Action<T> onNext, Action<Exception> onError, Action onComplete)
            => obs
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(onNext, onError, onComplete);
    }
}
