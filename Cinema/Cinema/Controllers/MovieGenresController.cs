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
    public class MovieGenresController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MovieGenresController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MovieGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieGenre>>> GetMovieGenre()
        {
            return await _context.MovieGenre.ToListAsync();
        }

        // GET: api/MovieGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieGenre>> GetMovieGenre(int id)
        {
            var movieGenre = await _context.MovieGenre.FindAsync(id);

            if (movieGenre == null)
            {
                return NotFound();
            }

            return movieGenre;
        }

        // PUT: api/MovieGenres/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieGenre(int id, MovieGenre movieGenre)
        {
            if (id != movieGenre.movieId)
            {
                return BadRequest();
            }

            _context.Entry(movieGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieGenreExists(id))
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

        // POST: api/MovieGenres
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MovieGenre>> PostMovieGenre(MovieGenre movieGenre)
        {
            _context.MovieGenre.Add(movieGenre);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieGenreExists(movieGenre.movieId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovieGenre", new { id = movieGenre.movieId }, movieGenre);
        }

        // DELETE: api/MovieGenres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieGenre>> DeleteMovieGenre(int id)
        {
            var movieGenre = await _context.MovieGenre.FindAsync(id);
            if (movieGenre == null)
            {
                return NotFound();
            }

            _context.MovieGenre.Remove(movieGenre);
            await _context.SaveChangesAsync();

            return movieGenre;
        }

        private bool MovieGenreExists(int id)
        {
            return _context.MovieGenre.Any(e => e.movieId == id);
        }
    }
}
