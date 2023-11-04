using social_network_platform_server.Domain.AuditEntitys;
using social_network_platform_server.Domain.Comments;
using social_network_platform_server.Domain.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Domain.Posts
{
    public class Post : AuditEntity<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
