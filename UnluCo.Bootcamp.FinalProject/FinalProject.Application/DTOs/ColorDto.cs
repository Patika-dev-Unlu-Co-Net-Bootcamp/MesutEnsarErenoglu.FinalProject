

using System.ComponentModel.DataAnnotations;

namespace FinalProject.Application.DTOs
{
    public class ColorDto : BaseDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        public string Hex { get; set; }
    }
}
