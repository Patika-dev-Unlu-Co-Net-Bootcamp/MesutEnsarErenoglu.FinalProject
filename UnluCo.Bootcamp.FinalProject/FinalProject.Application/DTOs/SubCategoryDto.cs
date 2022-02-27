using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.Application.DTOs
{
    public class SubCategoryDto : BaseDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz")]
        [JsonPropertyName("subcategoryname")]
        public string SubCategoryName { get; set; }

        [JsonPropertyName("description")]
        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Description { get; set; }

        [JsonPropertyName("categoryid")]
        public int CategoryId { get; set; }

        [JsonPropertyName("category")]
        public CategoryDto Category { get; set; }

        [JsonPropertyName("products")]
        public List<ProductDto> Products { get; set; }
    }
}
