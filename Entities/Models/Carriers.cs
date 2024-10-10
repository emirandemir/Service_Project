using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Carriers
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Carrier name cannot exceed 100 characters.")]
        public string carrierName { get; set; }
        [Required]
        public bool carrierIsActive { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Carrier plus desi cost must be a positive value.")]
        public int carrierPlusDesiCost { get; set; }
    }
}
