

using System.ComponentModel.DataAnnotations;

namespace FinalProject.WebApi.Models.SubCategory
{
    public class AddSubCategoryModel
    {
        [Required]
        [MaxLength (50, ErrorMessage = "50 karakterden fazla olamaz")]
        public string SubCategoryName { get; set; }

        [MaxLength (250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Description { get; set; }

        [Required (ErrorMessage ="Kategori Id belirtilmelidir!")]
        public int CategoryId { get; set; }
    }
}
