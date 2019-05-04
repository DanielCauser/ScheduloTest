using System;

namespace XamarinTest
{
	public class ViewModelConnectivity : BaseViewModel
	{
		public ViewModelConnectivity()
		{
			ConnectionStatus = "TODO";
		}

		public string ConnectionStatus { get; set; }
	}
}
