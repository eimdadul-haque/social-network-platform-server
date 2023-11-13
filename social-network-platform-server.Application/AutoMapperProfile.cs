using AutoMapper;
using social_network_platform_server.Application.Contracts.Comments.Dtos;
using social_network_platform_server.Application.Contracts.Likes.Dtos;
using social_network_platform_server.Application.Contracts.Posts.Dtos;
using social_network_platform_server.Domain.Comments;
using social_network_platform_server.Domain.Likes;
using social_network_platform_server.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap <Post, PostDto>().ReverseMap();
            CreateMap <Comment, CommentDto>().ReverseMap();
            CreateMap <Like, LikeDto>().ReverseMap();
        }
    }
}
