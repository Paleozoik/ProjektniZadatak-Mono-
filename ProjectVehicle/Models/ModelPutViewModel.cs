using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Models
{
    public class ModelPutViewModel
    {

        public SelectList VehicleMakes { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Maker name")]
        public int MakeId { get; set; }
        [Required(ErrorMessage = "Name required")]
        [DisplayName("Model Name")]
        public string Name { get; set; }
        public ModelPutViewModel()
        {
            //used only for retrieving new Name and Make id from view
        }

        public ModelPutViewModel(IEnumerable<VehicleMake> Makes)
        {
            VehicleMakes = new SelectList(Makes, "Id", "Name"); ;
        }
    }
}
