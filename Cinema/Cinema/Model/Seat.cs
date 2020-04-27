using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Seat
    {
        public int seatId { get; set; }
        public bool available { get; set; }
        public int seat { get; set; }
        public int row { get; set; }

        //seat til show er m-1
        public int? showId { get; set; }
        public Show Show { get; set; }

    }
}
