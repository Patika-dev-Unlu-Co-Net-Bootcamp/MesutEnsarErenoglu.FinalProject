

using System.ComponentModel.DataAnnotations;

namespace FinalProject.WebApi.Models.Color
{
    public class AddColorModel
    {
        [Required(ErrorMessage = "İsim girişi gereklidir!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Renk kodu girişi gereklidir!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        public string Hex { get; set; }
    }
}
