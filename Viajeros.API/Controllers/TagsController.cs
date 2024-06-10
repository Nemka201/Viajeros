using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viajeros.Data.Models;
using Viajeros.Services;

namespace Viajeros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController(TagService tagService) : ControllerBase
    {
        // GET: api/Tags
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
        {
            return await tagService.GetAllTagsAsync();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(int id)
        {
            var tag = await tagService.GetTagAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            return tag;
        }

        // PUT: api/Tags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag(int id, Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }

            //_context.Entry(tag).State = EntityState.Modified;

            try
            {
                await tagService.UpdateTagAsync(tag);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(id))
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

        // POST: api/Tags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<Tag>> PostTag(Tag tag)
        {
            await tagService.AddTagAsync(tag);
            return CreatedAtAction("GetTag", new { id = tag.Id }, tag);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await tagService.GetTagAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            await tagService.RemoveTagAsync(tag);

            return NoContent();
        }

        private bool TagExists(int id)
        {
            return tagService.GetAllTags().Any(e => e.Id == id);
        }
    }
}
