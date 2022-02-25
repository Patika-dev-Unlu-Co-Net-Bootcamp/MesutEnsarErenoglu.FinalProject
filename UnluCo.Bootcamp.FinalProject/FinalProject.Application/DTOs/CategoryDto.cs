

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Application.DTOs
{
    public class CategoryDto : BaseDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz")]
        public string CategoryName { get; set; }

        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Description { get; set; }

        public List<SubCategoryDto> SubCategories { get; set; }
    }
}
