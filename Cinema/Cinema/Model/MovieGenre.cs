using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class MovieGenre
    {
        //public int moviegenreId { get; set; }
        //m to m 
        public int movieId { get; set; }
        public Movie Movie { get; set; }

        public int genreId { get; set; }
        public Genre Genre { get; set; }
    }
}
