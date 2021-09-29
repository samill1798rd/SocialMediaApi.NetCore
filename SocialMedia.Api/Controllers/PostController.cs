using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostController(IPostRepository PostRepository, IMapper mapper)
        {
            _postRepository = PostRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPots()
        {
            var posts = await _postRepository.GetPosts();
            var postDto = _mapper.Map<IEnumerable<PostDto>>(posts);

            return Ok(postDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPots(int id)
        {
            var post = await _postRepository.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);

            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.InsertPost(post);

            return Ok(post);
        }



    }
}
