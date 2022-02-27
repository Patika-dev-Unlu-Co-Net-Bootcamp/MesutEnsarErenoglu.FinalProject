

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.WebApi.Models.Color
{
    public class AddColorModel
    {
        [Required(ErrorMessage = "İsim girişi gereklidir!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Renk kodu girişi gereklidir!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        [JsonPropertyName("hex")]
        public string Hex { get; set; }
    }
}
