using Prism;
using Prism.Ioc;
using ScheduloTestResolution.ViewModels;
using ScheduloTestResolution.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using Xamarin.Essentials;
using ScheduloTestResolution.Infrastructure;
using Unity;
using Unity.Lifetime;
using ReactiveUI;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ScheduloTestResolution
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/ViewMainMenu");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ViewMainMenu, ViewModelMainPage>();
            containerRegistry.RegisterForNavigation<ViewConnectivity, ViewModelConnectivity>();
            containerRegistry.RegisterForNavigation<ViewForum, ViewModelForum>();
            containerRegistry.RegisterForNavigation<ViewPost, ViewModelPost>();
            containerRegistry.RegisterForNavigation<ViewShowImage, ViewModelShowImage>();
        }

        protected override IContainerExtension CreateContainerExtension()
        {
            var builder = new UnityContainer();
            builder.RegisterInstance(UserDialogs.Instance);
            builder.RegisterType<IServiceForum, ServiceForum>();
            RxApp.DefaultExceptionHandler = new GlobalExceptionHandler(builder.Resolve<IUserDialogs>());
            return new Prism.Unity.UnityContainerExtension(builder);
        }
    }
}
