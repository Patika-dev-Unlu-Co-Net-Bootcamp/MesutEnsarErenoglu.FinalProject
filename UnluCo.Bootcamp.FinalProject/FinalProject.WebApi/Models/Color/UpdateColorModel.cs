using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Models.Color
{
    public class UpdateColorModel
    {
        [Required(ErrorMessage ="İsim girişi gereklidir!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Renk kodu girişi gereklidir!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        [JsonPropertyName("hex")]
        public string Hex { get; set; }
    }
}
