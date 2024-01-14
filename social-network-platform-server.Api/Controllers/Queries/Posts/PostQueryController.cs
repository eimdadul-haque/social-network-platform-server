using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using social_network_platform_server.Application.Contracts.Posts.Interfaces;

namespace social_network_platform_server.Api.Controllers.Queries.Posts
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostQueryController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostQueryController(
            IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("get-user-posts")]
        public async Task<IActionResult> GetUserPosts([FromQuery] Guid userId)
        {
            var result = await _postService.GetUserPosts(userId);
            return Ok(new {items = result.items, totalCount = result.totalCount});
        }
    }
}
