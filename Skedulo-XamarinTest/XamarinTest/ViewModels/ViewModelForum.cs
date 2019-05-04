using System;
using System.Collections.Generic;

namespace XamarinTest
{
	public class ViewModelForum : BaseViewModel
	{
		public ViewModelForum()
		{
			Search = string.Empty;
		}

		IEnumerable<ModelPost> _posts;

		public IEnumerable<ModelPost> Posts
		{
			get
			{
				return _posts;
			}

			set
			{
				_posts = value;
				OnPropertyChanged("Posts");
			}
		}

		string _search;

		public string Search
		{
			get
			{
				return _search;
			}

			set
			{
				_search = value;
				OnPropertyChanged("Search");
				Posts = App.Get.Forum.GetMatchingPosts(_search);
			}
		}

		private ModelPost _selectedItem;
		public ModelPost SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				if (_selectedItem != value)
				{
					_selectedItem = value;
					OnPropertyChanged("SelectedItem");
				}
			}
		}
	}
}
