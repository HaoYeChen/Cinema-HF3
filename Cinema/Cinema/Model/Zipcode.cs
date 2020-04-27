using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Zipcode
    {
        public int zipcodeId { get; set; }
        public int zipcode { get; set; }
        public string city { get; set; }

        //foreign key
        //zipcode til customer er 1 til 1 relation

        public List<Customer> Customer { get; set; }
    }
}
