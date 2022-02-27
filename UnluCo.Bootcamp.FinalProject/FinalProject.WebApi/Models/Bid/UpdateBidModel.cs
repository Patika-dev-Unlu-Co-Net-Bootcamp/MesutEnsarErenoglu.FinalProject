

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.WebApi.Models.Bid
{
    public class UpdateBidModel
    {
        [Required(ErrorMessage = "Ürün için teklif edilecek fiyat belirtilmelidir!")]
        [Range(0.01, 1000000.00, ErrorMessage = "Teklif fiyatı 0'dan büyük olmalıdır.")]
        [JsonPropertyName("bidprice")]
        public decimal BidPrice { get; set; }
        [JsonPropertyName("quantity")]
        public short Quantity { get; set; } = 1;
    }
}
