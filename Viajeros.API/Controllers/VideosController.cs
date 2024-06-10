using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viajeros.Data.Models;
using Viajeros.Services;

namespace Viajeros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController(VideoService videoService) : ControllerBase
    {
        // GET: api/Videos/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideos()
        {
            return await videoService.GetAllVideosAsync();
        }
        // GET: api/Videos/GetLasts
        [HttpGet("GetLasts")]
        public async Task<ActionResult<IEnumerable<Video>>> GetLastsVideos()
        {
            return await videoService.GetLastsVideosAsync();
        }
        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(int id)
        {
            var video = await videoService.GetVideoAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // PUT: api/Videos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(int id, Video video)
        {
            if (id != video.Id)
            {
                return BadRequest();
            }

            //_context.Entry(video).State = EntityState.Modified;

            try
            {
                await videoService.UpdateVideoAsync(video);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
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

        // POST: api/Videos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Video>> PostVideo(Video video)
        {
            await videoService.AddVideoAsync(video);

            return CreatedAtAction("GetVideo", new { id = video.Id }, video);
        }

        // DELETE: api/Videos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var video = await videoService.GetVideoAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            await videoService.RemoveVideoAsync(video);

            return NoContent();
        }

        private bool VideoExists(int id)
        {
            return videoService.GetAllVideos().Any(e => e.Id == id);
        }
    }
}
