using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viajeros.Data.Models;
using Viajeros.Services;

namespace Viajeros.API.Controllers
{
    [Route("api/Images")]
    [ApiController]
    public class ImagesController(ImageService imageService) : ControllerBase
    {
        // GET: api/<PostsImagesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostImage>>> Get()
        {
            return await imageService.GetAllImagesAsync();
        }

        // GET api/<PostsImagesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostImage>> Get(int id)
        {
            return await imageService.GetImageAsync(id);
        }

        // POST api/<PostsImagesController>
        [HttpPost]
        public async Task<ActionResult<PostImage>> Post([FromBody] PostImage image)
        {
            await imageService.AddImageAsync(image);
            return CreatedAtAction("GetVideo", new { id = image.Id }, image);

        }

        // PUT api/<PostsImagesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            PostImage image = await imageService.GetImageAsync(id);
            if (image == null)
            {
                return BadRequest();
            }
            else
            {
                image.ImageUrl = value;
                try
                {
                    await imageService.UpdateImageAsync(image);

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
            var image = await imageService.GetImageAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            await imageService.RemoveImageAsync(image);
            return NoContent();
        }

        private bool ImageExists(int id)
        {
            return imageService.GetImages().Any(e => e.Id == id);
        }
    }
}
