

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.WebApi.Models.SubCategory
{
    public class AddSubCategoryModel
    {
        [Required]
        [MaxLength (50, ErrorMessage = "50 karakterden fazla olamaz")]
        [JsonPropertyName("subcategoryname")]
        public string SubCategoryName { get; set; }

        [MaxLength (250, ErrorMessage = "250 karakterden fazla olamaz")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required (ErrorMessage ="Kategori Id belirtilmelidir!")]
        [JsonPropertyName("categoryid")]
        public int CategoryId { get; set; }
    }
}
