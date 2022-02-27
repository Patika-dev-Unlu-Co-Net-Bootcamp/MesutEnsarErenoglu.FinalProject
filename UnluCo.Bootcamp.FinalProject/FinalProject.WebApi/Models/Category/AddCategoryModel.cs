

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.WebApi.Models.Category
{
    public class AddCategoryModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz")]
        [JsonPropertyName("categoryname")]
        public string CategoryName { get; set; }

        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

    }
}
