using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Order
    {
        public int orderId { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
        public DateTime purchasedtime { get; set; }



        //foreign key
        //order til customer er m-1
        public int? customerId { get; set; }
        public Customer Customer { get; set; }
        
        //order til show er m-1
        public int? showId { get; set; }
        public Show Show { get; set; }
    }
}
