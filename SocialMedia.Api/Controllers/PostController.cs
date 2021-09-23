using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository PostRepository)
        {
            _postRepository = PostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPots()
        {
            var posts = await _postRepository.GetPosts();

            return Ok(posts);
        }


    }
}
