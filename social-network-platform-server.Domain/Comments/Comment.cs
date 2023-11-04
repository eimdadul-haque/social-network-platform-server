using social_network_platform_server.Domain.Accounts;
using social_network_platform_server.Domain.AuditEntitys;
using social_network_platform_server.Domain.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Domain.Comments
{
    public class Comment : AuditEntity<Guid>
    {
        public Guid? ParentCommentId { get; set; }
        public Guid AuthorID { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid PostID { get; set; }
        [ForeignKey("PostID")] public Post Post { get; set; }
    }
}