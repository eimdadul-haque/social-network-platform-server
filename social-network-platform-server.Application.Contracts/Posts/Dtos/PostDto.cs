using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Contracts.Posts.Dtos
{
    public class PostDto : AuditEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }
        public DateTime PublishedDate { get; set; }
        //public List<Comment> Comments { get; set; }
        //public List<Like> Likes { get; set; }
    }
}
