using social_network_platform_server.Application.Contracts.Posts.Dtos;
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
        public string? Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }

        public Post GetNewPost(PostDto post)
        {
            this.Id = post.Id;
            this.Created = post.Created;
            this.CreatedBy = post.CreatedBy;
            this.Modified = post.Modified;
            this.ModifiedBy = post.ModifiedBy;
            this.IsDeleted = post.IsDeleted;
            this.IsActive = post.IsActive;

            this.Title = post.Title;
            this.Content = post.Content;
            this.AuthorID = post.AuthorID.Value;
            this.PublishedDate = post.PublishedDate;
            this.Comments = new();
            this.Likes = new();

            return this;
        }
    }
}
