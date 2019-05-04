using System;
using Xamarin.Forms;

namespace XamarinTest
{
	public class ViewModelShowImage : BaseViewModel
	{
		public ViewModelShowImage()
		{
			Filename = "simple.jpg";
		}

		string _filename;
		public string Filename
		{
			get
			{
				return _filename;
			}

			set
			{
				_filename = value;
				OnPropertyChanged("Filename");
				OnPropertyChanged("ImageUrl");
			}
		}

		public string ImageUrl
		{
			get
			{
				return "http://loremflickr.com/600/600/nature?filename=" + Filename;
			}
		}

		public Command CommandNewImage { get; private set; }
	}
}
