using System;
using System.Collections.Generic;

namespace XamarinTest
{
	public interface IServiceForum
	{
		IEnumerable<ModelPost> GetMatchingPosts(string search);
	}
}
