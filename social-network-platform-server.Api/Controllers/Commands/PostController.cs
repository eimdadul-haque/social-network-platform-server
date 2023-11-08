using Microsoft.AspNetCore.Mvc;
using social_network_platform_server.Application.Contracts.Posts.Dtos;
using social_network_platform_server.Application.Contracts.Posts.Interfaces;

namespace social_network_platform_server.Api.Controllers.Commands
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(
            IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost(PostDto input)
        {
            var a = await _postService.CreatePost(input);
            return Ok();
        }
    }
}
