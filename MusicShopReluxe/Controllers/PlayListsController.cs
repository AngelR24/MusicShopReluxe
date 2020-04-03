using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShopReluxe.Data;
using MusicShopReluxe.Models;

namespace MusicShopReluxe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListsController : ControllerBase
    {
        private readonly DBContext _context;

        public PlayListsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/PlayLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayList>>> GetPlayLists()
        {
            return await _context.PlayLists.ToListAsync();
        }

        // GET: api/PlayLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayList>> GetPlayList(int id)
        {
            var playList = await _context.PlayLists.FindAsync(id);

            if (playList == null)
            {
                return NotFound();
            }

            return playList;
        }

        // PUT: api/PlayLists/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayList(int id, PlayList playList)
        {
            if (id != playList.Id)
            {
                return BadRequest();
            }

            _context.Entry(playList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayListExists(id))
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

        // POST: api/PlayLists
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PlayList>> PostPlayList(PlayList playList)
        {
            _context.PlayLists.Add(playList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayList", new { id = playList.Id }, playList);
        }

        // DELETE: api/PlayLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayList>> DeletePlayList(int id)
        {
            var playList = await _context.PlayLists.FindAsync(id);
            if (playList == null)
            {
                return NotFound();
            }

            _context.PlayLists.Remove(playList);
            await _context.SaveChangesAsync();

            return playList;
        }

        private bool PlayListExists(int id)
        {
            return _context.PlayLists.Any(e => e.Id == id);
        }
    }
}
