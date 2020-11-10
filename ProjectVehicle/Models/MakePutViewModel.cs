using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Models
{
    public class MakePutViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Maker name")]
        public string Name { get; set; }
    }
}
