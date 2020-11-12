using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Service.Models
{
    public class VehicleModel
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(VehicleMake))]
        public Guid MakeId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name can't be longer than 30 characters")]
        public string Name { get; set; }
        public string Abrv { get; set; }


        public VehicleMake Make { get; set; }
    }
}
