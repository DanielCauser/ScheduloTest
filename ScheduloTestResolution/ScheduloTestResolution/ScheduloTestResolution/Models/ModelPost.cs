using System;
namespace ScheduloTestResolution
{
	public class ModelPost
	{
        private static int LastPostId;

		public ModelPost(string title, string body, int userId)
		{
			Title = title;
			Body = body;
			UserId = userId;
            Id = LastPostId++;
        }

		public string Title { get; set; }
		public string Body { get; set; }
		public int UserId { get; set; }
		public int Id { get; set; }
	}
}
