using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Movie
    {
        public int movieId { get; set; }
        public string title { get; set; }
        public int runtime { get; set; }
        public string description { get; set; }
        public DateTime releasedate { get; set; }

        //foreign key
        //Movie til Genre er 1 til m relation
        //public int GenreId { get; set; }
        //public Genre Genre { get; set; }

        //movie til order er 1 til m relation
        //public int orderId { get; set; }
        //public Order Order { get; set; }


        //1 til m eller m til m???
        public IList<MovieGenre> MovieGenre { get; set; }

        //public int? showId { get; set; }
        //public Show Show { get; set; }

        public ICollection<Show> Show { get; set; }
    }
}
