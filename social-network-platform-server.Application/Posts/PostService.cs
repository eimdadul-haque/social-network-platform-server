using AutoMapper;
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
        private readonly IMapper _mapper;
        public PostService(
            IRepository<Post> postRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<bool> CreatePost(PostDto input)
        {
            //var entity = _mapper.Map<PostDto, Post>(input);
            var entity = new Post();
            entity.Id = Guid.NewGuid();
            return await _postRepository
                .AddAsync(entity) is not null;
        }

        public Task<bool> AddCommentToPost(PostDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePost(Guid Id)
        {
            return await _postRepository.DeleteAsync(Id);
        }

        public async Task<bool> EditPost(PostDto input)
        {
            return await _postRepository
                .UpdateAsync(_mapper.Map<Post>(input)) is not null;
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
