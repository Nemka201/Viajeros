using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
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

        // GET: api/Videos/GetLasts
        [HttpGet("GetByIndex/{pageIndex}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<Video>>> GetByIndex(int pageIndex, int pageSize)
        {
            return await videoService.GetVideoByIndexAsync(pageIndex, pageSize);
        }
        [HttpGet("VideoCount")]
        public async Task<IActionResult> GetVideoCount()
        {
            var count = await videoService.GetCountAsync();
            return Ok(new { Count = count });
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
            try
            {
                // Aquí configuramos las opciones de serialización
                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    // Configura las opciones según tus necesidades
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true, // Para que el JSON sea legible
                    ReferenceHandler = ReferenceHandler.Preserve // Para evitar referencias circulares
                };

                await videoService.AddVideoAsync(video);

                // Devolvemos el objeto serializado con las opciones configuradas
                return new JsonResult(video, jsonSerializerOptions)
                {
                    StatusCode = 201 // Código de estado Created
                };
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return BadRequest($"Error al agregar el video: {ex.Message}");
            }
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
