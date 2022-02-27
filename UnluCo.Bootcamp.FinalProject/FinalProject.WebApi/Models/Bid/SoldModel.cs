
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.WebApi.Models.Bid
{
    public class SoldModel
    {
        [Required(ErrorMessage = "Satın alacak kullanıcı id belirtilmelidir!")]
        [JsonPropertyName("bidderuserid")]
        public string BidderUserId { get; set; }
        [JsonPropertyName("quantity")]
        public short Quantity { get; set; } = 1;
    }
}
