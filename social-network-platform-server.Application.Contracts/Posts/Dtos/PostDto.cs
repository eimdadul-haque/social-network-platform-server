using social_network_platform_server.Application.Contracts.Comments.Dtos;
using social_network_platform_server.Application.Contracts.Likes.Dtos;
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
        public Guid? AuthorID { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<LikeDto> Likes { get; set; }
    }
}
