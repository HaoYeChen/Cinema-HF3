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
    public class MoviesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MoviesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        //{
        //    return await _context.Movie.ToListAsync();
        //}
        public ActionResult<IEnumerable<Movie>> GetMovie()
        {
            //var test = _context.Movie.Select(p => p.releasedate);
            //var test = _context.Movie.Select(p => p.movieId);

            //Uden newtonsoftJson kan det ikke blive displayed
            //services.AddControllers()
            //    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //var test = _context.Movie.Include(movie => movie.MovieGenre);
            //return Ok(test);

            //var query1 = _context.Movie
            //    .Include(movie => movie.MovieGenre).ToList();

            var query2 = _context.Movie
                .Include(movie => movie.MovieGenre)
                .ThenInclude(mg => mg.Genre).ToList();
            


            return query2;
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.movieId)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.movieId }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.movieId == id);
        }
    }
}
