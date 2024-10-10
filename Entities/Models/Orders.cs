using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Orders
    {

        [JsonIgnore]
        public int ID { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Order desi cost must be a positive value.")]
        public int orderDesi { get; set; }
        [Required]
        public DateTime orderDate { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Order carrier cost must be a positive value.")]
        public decimal orderCarrierCost { get; set; }
        public int carrierID { get; set; }
    }
}
