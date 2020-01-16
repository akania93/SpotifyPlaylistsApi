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
    public class ArtistsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ArtistsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artists>>> GetArtists()
        {
            return await _context.Artists.ToListAsync();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artists>> GetArtists(long id)
        {
            var artists = await _context.Artists.FindAsync(id);

            if (artists == null)
            {
                return NotFound();
            }

            return artists;
        }

        // PUT: api/Artists/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutArtists(long id, Artists artists)
        //{
        //    if (id != artists.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(artists).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ArtistsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Artists
        //[HttpPost]
        //public async Task<ActionResult<Artists>> PostArtists(Artists artists)
        //{
        //    _context.Artists.Add(artists);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetArtists", new { id = artists.Id }, artists);
        //}

        // DELETE: api/Artists/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Artists>> DeleteArtists(long id)
        //{
        //    var artists = await _context.Artists.FindAsync(id);
        //    if (artists == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Artists.Remove(artists);
        //    await _context.SaveChangesAsync();

        //    return artists;
        //}

        private bool ArtistsExists(long id)
        {
            return _context.Artists.Any(e => e.Id == id);
        }
    }
}
