using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Show
    {
        public int showId { get; set; }
        public int showtime { get; set; }



        //foreign key
        

        
        //show til theater er m-1
        public int? theaterId { get; set; }
        public Theater Theater { get; set; }

        //show til seat er 1-m
        public ICollection<Seat> Seat { get; set; }

        //show til order er 1-m
        public ICollection<Order> Order { get; set; }

        //public ICollection<Movie> Movie { get; set; }
        public int? movieId { get; set; }
        public Movie Movie { get; set; }
    }
}
