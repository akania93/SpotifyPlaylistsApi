using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpotifyPlaylistsApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyPlaylistsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistCategoriesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PlaylistCategoriesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/PlaylistCategories
        /// <summary>
        /// Get all PlaylistCategories values
        /// </summary>
        /// <remarks>This API will get all values.</remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistCategories>>> GetPlaylistCategories()
        {
            return await _context.PlaylistCategories.ToListAsync();
        }

        // GET api/PlaylistCategories/aslist
        [Route("aslist")]
        [HttpGet]
        public  ActionResult<IEnumerable<string>> GetPlaylistCategoriesAsList()
        {
            var categories = _context.PlaylistCategories;
            return categories.Select(x => x.Value).ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/PlaylistCategories/5
        /// <summary>
        /// Get the PlaylistCategories value
        /// </summary>
        /// <remarks>This API will get the value.</remarks>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistCategories>> GetPlaylistCategories(long id)
        {
            var playlistCategories = await _context.PlaylistCategories.FindAsync(id);

            if (playlistCategories == null)
            {
                return NotFound();
            }

            return playlistCategories;
        }

        // PUT: api/PlaylistCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylistCategories(long id, PlaylistCategories playlistCategories)
        {
            if (id != playlistCategories.Id)
            {
                return BadRequest();
            }

            _context.Entry(playlistCategories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistCategoriesExists(id))
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

        // POST: api/PlaylistCategories
        [HttpPost]
        public async Task<ActionResult<PlaylistCategories>> PostPlaylistCategories(PlaylistCategories playlistCategories)
        {
            _context.PlaylistCategories.Add(playlistCategories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaylistCategories", new { id = playlistCategories.Id }, playlistCategories);
        }

        // DELETE: api/PlaylistCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlaylistCategories>> DeletePlaylistCategories(long id)
        {
            var playlistCategories = await _context.PlaylistCategories.FindAsync(id);
            if (playlistCategories == null)
            {
                return NotFound();
            }

            _context.PlaylistCategories.Remove(playlistCategories);
            await _context.SaveChangesAsync();

            return playlistCategories;
        }

        private bool PlaylistCategoriesExists(long id)
        {
            return _context.PlaylistCategories.Any(e => e.Id == id);
        }
    }
}
