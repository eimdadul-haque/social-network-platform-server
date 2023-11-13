using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Contracts.Comments.Dtos
{
    public class CommentDto : AuditEntityDto<Guid>
    {
        public Guid? ParentCommentId { get; set; }
        public Guid AuthorID { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid PostID { get; set; }
    }
}
