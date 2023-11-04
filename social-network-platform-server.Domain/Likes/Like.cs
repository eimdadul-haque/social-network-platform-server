using social_network_platform_server.Domain.AuditEntitys;
using social_network_platform_server.Domain.Comments;
using social_network_platform_server.Domain.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Domain.Likes
{
    public class Like : AuditEntity<Guid>
    {
        public Guid PostID { get; set; }
        [ForeignKey("PostID")] public Post Post { get; set; }
        public Guid CommentID { get; set; }
        [ForeignKey("CommentID")] public Comment Comment { get; set; }
        public Guid UserID { get; set; }
    }
}
