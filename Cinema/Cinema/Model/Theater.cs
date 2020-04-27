using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Theater
    {
        public int theaterId { get; set; }
        public string name { get; set; }
        public int seatings { get; set; }
        public int showtime { get; set; }

        //foreign key
        //theater til room er 1 til m relation
        //public virtual ICollection<Room> room { get; set; }

        //show til order er 1 til m relation
        //public int orderId { get; set; }
        //public Order Order { get; set; }

        //public List<Order> Order { get; set; }

        //theater til show er 1-m
        public ICollection<Show> Show { get; set; }
    }
}
