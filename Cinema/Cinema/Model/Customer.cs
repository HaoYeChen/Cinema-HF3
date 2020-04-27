using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Customer
    {
        public int customerId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int phonenumber { get; set; }

        //foreign key
        //customer til zipcode er 1 til 1 relation
        public int zipcodeId { get; set; }
        public Zipcode Zipcode { get; set; }

        //customer til order er 1-m
        public ICollection<Order> Order { get; set; }

    }
}
