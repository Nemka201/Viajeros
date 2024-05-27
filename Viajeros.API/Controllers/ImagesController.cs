using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Viajeros.Data.DTO;
using Viajeros.Data.Models;
using Viajeros.Services;

namespace Viajeros.API.Controllers
{
    [Route("api/Images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ImageService _imageService;
        public ImagesController(ImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/<PostsImagesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostImage>>> Get()
        {
            return await _imageService.GetAllImagesAsync();
        }

        // GET api/<PostsImagesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostImage>> Get(int id)
        {
            return await _imageService.GetImageAsync(id);
        }

        // POST api/<PostsImagesController>
        [HttpPost]
        public async Task<ActionResult<PostImage>> Post([FromBody] PostImage image)
        {
            await _imageService.AddImageAsync(image);
            return CreatedAtAction("GetVideo", new { id = image.Id }, image);

        }

        // PUT api/<PostsImagesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            PostImage image = await _imageService.GetImageAsync(id);
            if (image == null)
            {
                return BadRequest();
            }
            else
            {
                image.ImageUrl = value;
                try
                {
                    await _imageService.UpdateImageAsync(image);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(id))
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
        }

        // DELETE api/<PostsImagesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _imageService.GetImageAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            await _imageService.RemoveImageAsync(image);
            return NoContent();
        }

        private bool ImageExists(int id)
        {
            return _imageService.GetImages().Any(e => e.Id == id);
        }
    }
}
