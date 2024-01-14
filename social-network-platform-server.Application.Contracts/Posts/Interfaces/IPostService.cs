using social_network_platform_server.Application.Contracts.Common;
using social_network_platform_server.Application.Contracts.Posts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Contracts.Posts.Interfaces
{
    public interface IPostService
    {
        //Enables users to create new posts.
        Task<bool> CreatePost(PostDto entity);

        //Retrieves details of a specific post.
        Task<PostDto> GetPost(Guid Id);

        //Allows users to edit their own posts.
        Task<bool> EditPost(PostDto entity);

        //Deletes a user's own post.
        Task<bool> DeletePost(Guid Id);

        //Retrieves posts created by a specific user.
        Task<PageResultDto<PostDto>> GetUserPosts(Guid userId);

        //Displays posts from friends in the user's network.
        Task<List<PostDto>> GetFriendPosts(Guid userId);

        //Lets users like or react to a post.
        Task<bool> LikePost(PostDto entity);

        //Allows users to add comments to a post.
        Task<bool> AddCommentToPost(PostDto entity);
    }
}