using Xamarin.Forms;

namespace XamarinTest
{
	public partial class App : Application
	{
		static public App Get { get; private set; }

		public IServiceForum Forum { get; private set; }

		public App()
		{
			InitializeComponent();

			Get = this;

			Forum = DependencyService.Get<IServiceForum>();

			var navigationPage = new NavigationPage(new ViewMainMenu());
			MainPage = navigationPage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
