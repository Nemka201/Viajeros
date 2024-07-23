using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viajeros.Data.DTO;
using Viajeros.Data.Models;
using Viajeros.Services;

namespace Viajeros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController(PostService postService, ImageService imageService) : ControllerBase
    {
        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = await postService.GetAllPostsAsync();

            foreach (var post in posts)
            {
                var images = await imageService.GetPostImagesAsync(post.Id);
                post.Images = [.. images];
            }

            return posts;
        }

        // GET: api/Posts
        [HttpGet("Index/{index}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetIndexedPosts(int index)
        {
            try
            {
                var posts = await postService.GetIndexedPostsAsync(index);

                foreach (var post in posts)
                {
                    var images = await imageService.GetPostImagesAsync(post.Id);
                    post.Images = [.. images];
                }

                var orderedPosts = posts.OrderByDescending(post => post.Created);
                return new OkObjectResult(orderedPosts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los posts: {ex.Message}");
                return new StatusCodeResult(500);
            }
        }
        // GET: api/Videos/GetLasts
        [HttpGet("GetByIndex/{pageIndex}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetByIndex(int pageIndex, int pageSize)
        {
            return await postService.GetPostByIndexAsync(pageIndex, pageSize);
        }
        [HttpGet("VideoCount")]
        public async Task<IActionResult> GetVideoCount()
        {
            var count = await postService.GetCountAsync();
            return Ok(new { Count = count });
        }
        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await postService.GetPostAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, PostDTO postDto)
        {
            var post = postDto.Post;
            if (id != post.Id)
            {
                return BadRequest();
            }
            try
            {
                await postService.UpdatePostAsync(postDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(post.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost([FromBody] PostDTO post)
        {
            await postService.AddPostAsync(post);
            return CreatedAtAction("GetPost", new { id = post.Post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await postService.GetPostAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            await postService.RemovePostAsync(post);

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return postService.GetAllPosts().Any(e => e.Id == id);
        }
    }
}
