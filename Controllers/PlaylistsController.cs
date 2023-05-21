using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agdavletova_beckend.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;
//using Agdavletova_bekend.Interfaces;

namespace Agdavletova_bekend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistisController : ControllerBase
    {
        private readonly PlaylistContext _context;

        public PlaylistisController(PlaylistContext context)
        {
            _context = context;
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
{
if (_context.Playlist == null)
{
                return NotFound();
    }
    var playlist = await _context.Playlist.FindAsync(id);

if (playlist == null)
{
return NotFound();
}

return playlist;
}

       
        private bool PlaylistExists(int id)
        {
            return (_context.Playlist?.Any(e => e.id == id)).GetValueOrDefault();
        }
        [HttpPut("{id}")]
public async Task<IActionResult> PutLibrary(int id, Playlist playlist)
{
    if (id != playlist.id)
    {
        return BadRequest();
    }

    _context.Entry(playlist).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!PlaylistExists(id))
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


[HttpPost]
public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
{
    if (_context.Playlist == null)
    {
        return Problem("Entity set 'PlaylistContext.Playlist' is null.");
    }
    var playlists = new Playlist(playlist.executor, playlist.song);
    _context.Playlist.Add(playlists);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetPlaylist", new { id = playlist.id }, playlist);
}


[HttpDelete("{id}")]
public async Task<IActionResult> DeletePlaylist(int id)
{
    if (_context.Playlist == null)
    {
        return NotFound();
    }
    var playlist = await _context.Playlist.FindAsync(id);
    if (playlist == null)
    {
        return NotFound();
    }

    _context.Playlist.Remove(playlist);
    await _context.SaveChangesAsync();

    return NoContent();
}





        [HttpPut()]
        [Route("AddExecutor")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> AddExecutor(int dayId, int ExecutorId)
        {
            var executors = _context.Executor.Where(a => a.Id == ExecutorId).FirstOrDefault();

            var playlist = _context.Executor.Where(lib => lib.Id == dayId).FirstOrDefault();

            playlist.AddExecutor(executors);
            _context.Entry(playlist).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }




}

}

