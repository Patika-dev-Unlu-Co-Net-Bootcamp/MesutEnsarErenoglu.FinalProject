

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.Application.DTOs
{
    public class ColorDto : BaseDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        [JsonPropertyName("hex")]
        public string Hex { get; set; }
    }
}
