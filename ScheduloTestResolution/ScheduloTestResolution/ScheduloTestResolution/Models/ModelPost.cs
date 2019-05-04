using System;
namespace ScheduloTestResolution
{
	public class ModelPost
	{
		public ModelPost(string title, string body, int userId, int id)
		{
			Title = title;
			Body = body;
			UserId = userId;
			Id = id;
		}

		public string Title { get; set; }
		public string Body { get; set; }
		public int UserId { get; set; }
		public int Id { get; set; }
	}
}
