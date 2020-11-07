using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        [ForeignKey("VehicleMake")]
        public int MakeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }

        public VehicleMake VehicleMake { get; set; }
    }
}
