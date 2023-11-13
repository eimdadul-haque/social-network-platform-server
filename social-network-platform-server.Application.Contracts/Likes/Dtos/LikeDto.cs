using social_network_platform_server.Application.Contracts.Comments.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Contracts.Likes.Dtos
{
    public class LikeDto : AuditEntityDto<Guid>
    {
        public Guid PostID { get; set; }
        public Guid CommentID { get; set; }
        public CommentDto Comment { get; set; }
        public Guid UserID { get; set; }
    }
}
