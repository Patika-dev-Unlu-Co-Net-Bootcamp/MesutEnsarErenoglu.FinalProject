

using System.ComponentModel.DataAnnotations;

namespace FinalProject.WebApi.Models.Category
{
    public class AddCategoryModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz")]
        public string CategoryName { get; set; }

        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Description { get; set; }

    }
}
