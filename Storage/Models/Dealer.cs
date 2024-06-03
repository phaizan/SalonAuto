using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    public class Dealer
    {
        public Guid DealerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Car> Cars { get; set; }
    }

}
