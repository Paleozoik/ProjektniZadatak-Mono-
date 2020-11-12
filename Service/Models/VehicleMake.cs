using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Models
{
    public class VehicleMake
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name can't be longer than 30 characters")]
        public string Name { get; set; }
        [StringLength(30)]
        public string Abrv { get; set; }


        public ICollection<VehicleModel> Models { get; set; }
    }
}
