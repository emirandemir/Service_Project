using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CarrierConfigurations
    {
        public int ID { get; set; }
        public int carrierID { get; set; }
        public int carrierMaxDesi { get; set; }
        public int carrierMinDesi { get; set; }
        public decimal carrierCost { get; set; }
    }
}
