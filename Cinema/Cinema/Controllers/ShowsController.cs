using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Model;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ShowsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Shows
        [HttpGet]
        public ActionResult<IEnumerable<Show>> GetShow()
        {
            //return await _context.Show.ToListAsync();
            var query = _context.Show
                .Include(m => m.Movie).ToList();
            return query;
        }

        // GET: api/Shows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShow(int id)
        {
            var show = await _context.Show.FindAsync(id);

            if (show == null)
            {
                return NotFound();
            }

            return show;
        }

        

        // PUT: api/Shows/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShow(int id, Show show)
        {
            if (id != show.showId)
            {
                return BadRequest();
            }

            _context.Entry(show).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(id))
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

        // POST: api/Shows
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Show>> PostShow(Show show)
        {
            _context.Show.Add(show);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShow", new { id = show.showId }, show);
        }

        // DELETE: api/Shows/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Show>> DeleteShow(int id)
        {
            var show = await _context.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            _context.Show.Remove(show);
            await _context.SaveChangesAsync();

            return show;
        }

        private bool ShowExists(int id)
        {
            return _context.Show.Any(e => e.showId == id);
        }
    }
}
