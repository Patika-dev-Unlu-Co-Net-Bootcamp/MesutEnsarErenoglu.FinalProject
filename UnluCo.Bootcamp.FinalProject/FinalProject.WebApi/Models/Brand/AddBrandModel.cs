
using System.ComponentModel.DataAnnotations;

namespace FinalProject.WebApi.Models.Brand
{
    public class AddBrandModel
    {
        [Required(ErrorMessage ="Marka ismi gereklidir!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Marka Açıklaması gereklidir!")]
        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz!")]
        public string Description { get; set; }
    }
}
