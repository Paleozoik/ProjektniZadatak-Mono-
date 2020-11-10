using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Models
{
    public class MakeCreateViewModel
    {
        [Required(ErrorMessage ="Name is required")]
        [DisplayName("Maker Name")]
        public string Name { get; set; }
    }
}
