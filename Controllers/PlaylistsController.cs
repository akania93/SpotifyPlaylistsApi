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
    public class PlaylistsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PlaylistsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Playlists
        /// <summary>
        /// Get all Playlists
        /// </summary>
        /// <remarks>This API will get all the values.</remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlists>>> GetPlaylists()
        {
            var playlist = await _context.Playlists
                .Include(x => x.Tracks)
                .ThenInclude(x => x.Artists)
                .ToListAsync();

            return playlist;
        }

        // GET: api/Playlists/5
        /// <summary>
        /// Get the Playlist
        /// </summary>
        /// <remarks>This API will get the playlist by id.</remarks>
        /// <param name="id">playlist id</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlists>> GetPlaylists(long id)
        {
            var playlists = await _context.Playlists
                .Include(x => x.Tracks)
                .ThenInclude(x => x.Artists)
                .Where(x => x.Id == id)
                .FirstAsync();

            if (playlists == null)
            {
                return NotFound();
            }

            return playlists;
        }

        // PUT: api/Playlists/5
        /// <summary>
        /// Update Playlist
        /// </summary>
        /// <remarks>This API will update the playlist by id.</remarks>
        /// <param name="id">playlist id</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylists(long id, Playlists playlists)
        {
            if (id != playlists.Id)
            {
                return BadRequest();
            }

            //_context.Entry(playlists).State = EntityState.Modified;

            var existingParent = await _context.Playlists
                .Include(x => x.Tracks)
                .ThenInclude(x => x.Artists)
                .Where(x => x.Id == id)
                .FirstAsync();

            if (existingParent != null)
            {
                // Update parent
                _context.Entry(existingParent).CurrentValues.SetValues(playlists);

                // Delete children
                foreach (var existingChild in existingParent.Tracks.ToList())
                {
                    if (playlists.Tracks.All(c => c.Id != existingChild.Id))
                    {
                        _context.Tracks.Remove(existingChild);
                        _context.Artists.RemoveRange(existingChild.Artists);
                    }
                }

                // Update and Insert children
                foreach (var childModel in playlists.Tracks)
                {
                    var existingChild = existingParent.Tracks
                        .SingleOrDefault(c => c.Id == childModel.Id);

                    if (existingChild != null)
                        // Update child
                        _context.Entry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        // Insert child
                        // Clean artists Ids
                        var artists = childModel.Artists;
                        foreach (var a in artists)
                            a.Id = 0;
                        
                        var newChild = new Tracks
                        {
                            Name = childModel.Name,
                            DurationMs = childModel.DurationMs,
                            ExternalUrlSpotify = childModel.ExternalUrlSpotify,
                            PreviewUrl = childModel.PreviewUrl,
                            Artists = artists,
                            ExternalId = childModel.ExternalId
                        };
                        existingParent.Tracks.Add(newChild);
                    }
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistsExists(id))
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

        // POST: api/Playlists
        /// <summary>
        /// Add Playlist
        /// </summary>
        /// <remarks>This API will add the playlist.</remarks>
        /// <param name="playlists">new playlist (json)</param>
        [HttpPost]
        public async Task<ActionResult<Playlists>> PostPlaylists(Playlists playlists)
        {
            _context.Playlists.Add(playlists);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaylists", new { id = playlists.Id }, playlists);
        }

        // DELETE: api/Playlists/5
        /// <summary>
        /// Delete Playlist
        /// </summary>
        /// <remarks>This API will delete the playlist by id.</remarks>
        /// <param name="id">playlist id</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Playlists>> DeletePlaylists(long id)
        {
            var playlists = await _context.Playlists
                .Include(x => x.Tracks)
                .ThenInclude(x => x.Artists)
                .Where(x => x.Id == id)
                .FirstAsync();

            if (playlists == null)
            {
                return NotFound();
            }


            foreach (var track in playlists.Tracks)
            {
                foreach (var artist in track.Artists)
                {
                    _context.Artists.Remove(artist);
                }
                _context.Tracks.Remove(track);
            }
            _context.Playlists.Remove(playlists);

            await _context.SaveChangesAsync();

            return playlists;
        }

        private bool PlaylistsExists(long id)
        {
            return _context.Playlists.Any(e => e.Id == id);
        }
    }
}
