using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Application.DTOs
{
    public class SubCategoryDto : BaseDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz")]
        public string SubCategoryName { get; set; }

        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
