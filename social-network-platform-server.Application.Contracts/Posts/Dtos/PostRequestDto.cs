using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Contracts.Posts.Dtos
{
    public class PostRequestDto
    {
        public Guid? UserId { get; set; }
        public Guid? Id { get; set; }
        public DateTime? Created{ get; set; }
        public DateTime? Modified { get; set; }
        public int MaxCount { get; set; }
        public int SkipCount { get; set; }
        public int Page { get; set; }
        public int LoadCount { get; set; }
    }
}
