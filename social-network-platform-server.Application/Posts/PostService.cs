using social_network_platform_server.Application.Contracts.Posts.Dtos;
using social_network_platform_server.Application.Contracts.Posts.Interfaces;
using social_network_platform_server.Application.Contracts.Repository.Interfaces;
using social_network_platform_server.Domain.Likes;
using social_network_platform_server.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Posts
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;
        public PostService(
            IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }
        public Task<bool> AddCommentToPost(PostDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> CreatePost(PostDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePost(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> EditPost(PostDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostDto>> GetFriendPosts(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetPost(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostDto>> GetUserPosts(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LikePost(PostDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
