using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Models
{
    public class ModelCreateViewModel
    {
        public SelectList VehicleMakes { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Maker")]
        public int MakeId { get; set; }
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        public ModelCreateViewModel()
        {
        }

        public ModelCreateViewModel(IEnumerable<VehicleMake> Makes)
        {
            VehicleMakes = new SelectList(Makes, "Id", "Name"); ;
        }
    }
}
