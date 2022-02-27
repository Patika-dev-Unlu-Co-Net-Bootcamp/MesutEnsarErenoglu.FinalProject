

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.Application.DTOs
{
    public class BrandDto : BaseDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        [Required]
        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz!")]
        public string Description { get; set; }
    }
}
