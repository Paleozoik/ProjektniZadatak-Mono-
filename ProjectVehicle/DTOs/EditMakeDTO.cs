using System.ComponentModel.DataAnnotations;

namespace ProjectVehicle.DTOs
{
    public class EditMakeDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name can't be longer than 30 characters")]
        public string Name { get; set; }
    }
}
