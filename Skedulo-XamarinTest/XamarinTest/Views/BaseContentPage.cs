using System;
using Xamarin.Forms;

namespace XamarinTest
{
	public class BaseContentPage<TViewModel> : ContentPage where TViewModel : BaseViewModel, new()
	{
		readonly TViewModel _viewModel;
		public TViewModel ViewModel { get { return _viewModel; } }

		public BaseContentPage()
		{
			_viewModel = new TViewModel();
			BindingContext = _viewModel;
		}
	}
}
