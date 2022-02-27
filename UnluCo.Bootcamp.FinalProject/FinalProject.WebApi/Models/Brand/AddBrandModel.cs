
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.WebApi.Models.Brand
{
    public class AddBrandModel
    {
        [Required(ErrorMessage ="Marka ismi gereklidir!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Marka Açıklaması gereklidir!")]
        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz!")]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
