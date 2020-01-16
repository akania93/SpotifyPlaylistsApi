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
    public class TracksController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TracksController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Tracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tracks>>> GetTracks()
        {
            return await _context.Tracks.ToListAsync();
        }

        // GET: api/Tracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tracks>> GetTracks(long id)
        {
            var tracks = await _context.Tracks.FindAsync(id);

            if (tracks == null)
            {
                return NotFound();
            }

            return tracks;
        }

        // PUT: api/Tracks/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTracks(long id, Tracks tracks)
        //{
        //    if (id != tracks.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tracks).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TracksExists(id))
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

        // POST: api/Tracks
        //[HttpPost]
        //public async Task<ActionResult<Tracks>> PostTracks(Tracks tracks)
        //{
        //    _context.Tracks.Add(tracks);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTracks", new { id = tracks.Id }, tracks);
        //}

        // DELETE: api/Tracks/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Tracks>> DeleteTracks(long id)
        //{
        //    var tracks = await _context.Tracks.FindAsync(id);
        //    if (tracks == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Tracks.Remove(tracks);
        //    await _context.SaveChangesAsync();

        //    return tracks;
        //}

        private bool TracksExists(long id)
        {
            return _context.Tracks.Any(e => e.Id == id);
        }
    }
}
