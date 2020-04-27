using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Genre
    {
        public int genreId { get; set; }
        public string genre { get; set; }

        //Genre til Movie er M til 1 relation
        //public ICollection<Movie> Movie { get; set; }

        //1 til m eller m til m???
        public IList<MovieGenre> MovieGenre { get; set; }
    }
}
