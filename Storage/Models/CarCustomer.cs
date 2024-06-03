using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    

    public class CarCustomer
    {
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
