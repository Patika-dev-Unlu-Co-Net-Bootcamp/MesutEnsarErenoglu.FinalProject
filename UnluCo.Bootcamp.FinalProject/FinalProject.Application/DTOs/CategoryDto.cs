

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.Application.DTOs
{
    public class CategoryDto : BaseDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz")]
        [JsonPropertyName("categoryname")]
        public string CategoryName { get; set; }

       

        [JsonPropertyName("description")]
        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Description { get; set; }

        
        [JsonPropertyName("subcategories")]
        public List<SubCategoryDto> SubCategories { get; set; }
    }
}
