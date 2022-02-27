

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.WebApi.Models.Category
{
    public class UpdateCategoryModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz")]
        [JsonPropertyName("categoryname")]
        public string CategoryName { get; set; }

        [JsonPropertyName("description")]
        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Description { get; set; }

        [JsonPropertyName("subcategories")]
        public int[] SubCategories { get; set; }

    }
}
