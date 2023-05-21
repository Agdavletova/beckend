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
    public class ExecutorsController : ControllerBase
    {
        private readonly PlaylistContext _context;

        


        public ExecutorsController(PlaylistContext context)
        {
            _context = context;
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Executor>>> GetExecutor()
        {
            if (_context.Executor == null)
            {
                return NotFound();
            }
            return await _context.Executor.ToListAsync();
        }

        private bool ExecutorExists(int id)
        {
            return (_context.Executor?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExecutor(int id, Executor executor)
        {
            if (id != executor.Id)
            {
                return BadRequest();
            }

            _context.Entry(executor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExecutorExists(id))
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
public async Task<ActionResult<Executor>> PostExecutor (Executor executor)
{
    if (_context.Executor == null)
    {
        return Problem("Entity set 'PlaylistContext.Executor' is null.");
    }
    var authorss = new Executor(executor.Id, executor.Name, executor.Age);
    _context.Executor.Add(executor);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetExecutor", new { id = executor.Id }, executor);
}


[HttpDelete("{id}")]
public async Task<IActionResult> DeleteExecutor(int id)
{
    if (_context.Executor == null)
    {
        return NotFound();
    }
    var executors = await _context.Executor.FindAsync(id);
    if (executors == null)
    {
        return NotFound();
    }

    _context.Executor.Remove(executors);
    await _context.SaveChangesAsync();

    return NoContent();
}




[HttpGet("{Age}")]
public async Task<ActionResult<IEnumerable<Executor>>> GetSongByExecutor(int Age)
{
    if (_context.Executor == null)
    {
        return NotFound();
    }
    var executors = await _context.Executor
    .Where(a => a.Age == Age)
    .ToListAsync();

    if (executors == null)
       {
        return NotFound();
        }

    return executors;
    }
    }
}

