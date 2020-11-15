using System.ComponentModel.DataAnnotations;

namespace Service.DTOs
{
    public class CreateModelDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name can't be longer than 30 characters")]
        public string Name { get; set; }
        [Required]
        public int MakeId { get; set; }
    }
}
