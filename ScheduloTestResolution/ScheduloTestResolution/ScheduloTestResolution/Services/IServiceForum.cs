using System;
using System.Collections.Generic;

namespace ScheduloTestResolution
{
	public interface IServiceForum
	{
		IEnumerable<ModelPost> GetMatchingPosts(string search);
	}
}
