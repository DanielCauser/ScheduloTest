using System;
using System.Collections.Generic;
using System.Linq;
using ScheduloTestResolution;

namespace ScheduloTestResolution
{
    public class ServiceForum : IServiceForum
    {
        List<ModelPost> _posts = new List<ModelPost>();

        public ServiceForum()
        {
            _posts.Add(new ModelPost("Sunt aut facere repellat provident occaecati excepturi optio reprehenderit", "Quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto", 1, 1));
            _posts.Add(new ModelPost("Qui est esse", "est rerum tempore vitae\nSequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla", 1, 2));
            _posts.Add(new ModelPost("ut numquam possimus omnis eius suscipit laudantium iure", "est natus reiciendis nihil possimus aut provident\nex et dolor\nrepellat pariatur est\nnobis rerum repellendus dolorem autem", 2, 3));
            _posts.Add(new ModelPost("Aut quo modi neque nostrum ducimus", "Voluptatem quisquam iste\nvoluptatibus natus officiis facilis dolorem\nquis quas ipsam\nvel et voluptatum in aliquid", 1, 4));
            _posts.Add(new ModelPost("sit asperiores ipsam eveniet odio non quia", "totam corporis dignissimos\nvitae dolorem ut occaecati accusamus\nex velit deserunt\net exercitationem vero incidunt corrupti mollitia", 1, 4));
            _posts.Add(new ModelPost("sed ab est est", "At pariatur consequuntur earum quidem\nquo est laudantium soluta voluptatem\nqui ullam et est\net cum voluptas voluptatum repellat est", 1, 4));
        }

        public IEnumerable<ModelPost> GetMatchingPosts(string search)
        {
            // TODO: Return those matching the search, but all if the search is empty
            if (string.IsNullOrWhiteSpace(search))
                return _posts;

            return _posts.Where(x => x.Title
                                      .ToLower()
                                      .Contains(search.ToLower())
                                      ||
                                     x.Body
                                      .ToLower()
                                      .Contains(search.ToLower()));
        }
    }
}
