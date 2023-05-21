using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Agdavletova_beckend.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Agdavletova_bekend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly PlaylistContext _context;



        public SongsController(PlaylistContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSong()
        {

            if (_context.Song == null)
            {
                return NotFound();
            }
            return await _context.Song.ToListAsync();
        }



        private bool SongExists(int id)
        {
            return (_context.Song?.Any(e => e.ID == id)).GetValueOrDefault();
        }
        [HttpPut("{id}")]
public async Task<IActionResult> PutSong(int id, Song song)
{
    if (id != song.ID)
    {
        return BadRequest();
    }

    _context.Entry(song).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!SongExists(id))
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
public async Task<ActionResult<Song>> PostSong(Song song)
{
    if (_context.Song == null)
    {
        return Problem("Entity set 'ExecutorContext.Song' is null.");
    }
    var songs = new Song(song.ID, song.Title, song.executor,  song.Year);
    _context.Song.Add(song);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetSong", new { id = song.ID }, song);
}

        //// DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            if (_context.Song == null)
            {
                return NotFound();
            }
            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Song.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("{executor}")]
public async Task<ActionResult<IEnumerable<Song>>> GetSongByExecutor(string executor)
{
    if (_context.Song == null)
    {
        return NotFound();
    }
    var songs = await _context.Song
    .Where(b => b.executor == executor)
    .ToListAsync();

    if (songs == null)
    {
        return NotFound();
    }

    return songs;
}



}
}


