using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Rating
    {
        public int ratingId { get; set; }
        public int rating{ get; set; }

        //foreign key
        //rating til movie er m til 1 relation
        public List<Movie> Movie { get; set; }
    }
}
