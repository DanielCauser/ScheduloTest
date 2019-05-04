using System;
namespace XamarinTest
{
	public class ViewModelPost : BaseViewModel
	{
		ModelPost post;

		public ModelPost Post
		{
			get
			{
				return post;
			}

			set
			{
				post = value;
				OnPropertyChanged("Post");
			}
		}

		public ViewModelPost()
		{
		}
	}
}
