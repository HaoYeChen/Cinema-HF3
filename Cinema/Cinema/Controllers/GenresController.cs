using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Model;
using Microsoft.AspNetCore.Cors;

namespace Cinema.Controllers
{
    [EnableCors("MyAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public GenresController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre()
        {
            return await _context.Genre.ToListAsync();

            //var query1 = _context.Genre
            //    .Include(Genre => Genre.MovieGenre)
            //    .ThenInclude(mg => mg.Movie).ToList();
            //foreach (var movie in query1)
            //{
            //    foreach (var mg in movie.MovieGenre)
            //    {
            //        mg.Movie.MovieGenre = null;
            //    }
            //}


            //return query1;
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _context.Genre.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        //Get: api/Genre/genre='Bo'
        [HttpGet("search")]
        public Genre Search(string genre)
        {
            var genre1 = _context.Genre.Where(g => g.genre == genre).FirstOrDefault();

            return genre1;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.genreId)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/Genres
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            //_context.Genre.Add(genre);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetGenre", new { id = genre.genreId }, genre);


            _context.Genre.Add(genre);
            await _context.SaveChangesAsync();

            //return movie; //CreatedAtAction("GetMovie", new { id = movie.movieId }, movie);
            var query2 = _context.Genre.Where(x => x.genreId == genre.genreId)
                .Include(m => m.MovieGenre)
                .ThenInclude(mg => mg.Movie).SingleOrDefault();

            foreach (var mg in query2.MovieGenre)
            {
                mg.Genre.MovieGenre = null;
            }




            return query2;
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> DeleteGenre(int id)
        {
            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();

            return genre;
        }

        private bool GenreExists(int id)
        {
            return _context.Genre.Any(e => e.genreId == id);
        }
    }
}
