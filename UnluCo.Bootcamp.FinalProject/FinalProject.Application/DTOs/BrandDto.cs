

using System.ComponentModel.DataAnnotations;

namespace FinalProject.Application.DTOs
{
    public class BrandDto : BaseDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        public string Name { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz!")]
        public string Description { get; set; }
    }
}
