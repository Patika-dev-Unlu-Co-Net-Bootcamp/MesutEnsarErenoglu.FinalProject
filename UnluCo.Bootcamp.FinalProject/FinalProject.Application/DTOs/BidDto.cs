

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.Application.DTOs
{
    public class BidDto : BaseDto
    {

        [JsonPropertyName("bidderuserid")]
        public string BidderUserId { get; set; }

        [JsonPropertyName("bidderuserid")]
        public AppUserDto BidderAppUser { get; set; }

        [JsonPropertyName("productid")]
        public int ProductId { get; set; }

        [JsonPropertyName("product")]
        public ProductDto Product { get; set; }

        [JsonPropertyName("bidprice")]
        [Required]
        [Range(0.01, 1000000.00, ErrorMessage = "Teklif fiyatı 0'dan büyük olmalıdır.")]
        public decimal BidPrice { get; set; }

        [JsonPropertyName("biddate")]
        [DataType(DataType.DateTime)]
        public DateTime BidDate { get; set; }

        [JsonPropertyName("quantity")]
        public short Quantity { get; set; } = 1;

        private decimal _totalPrice;

        [JsonPropertyName("totalprice")]
        public decimal TotalPrice
        {
            get
            {
                _totalPrice = BidPrice * Quantity;
                return _totalPrice;
            }
        }

        [JsonPropertyName("issold")]
        public bool IsSold { get; set; } = false;

        [JsonPropertyName("isaccepted")]
        public bool IsAccepted { get; set; } = false;

        [JsonPropertyName("solddate")]
        [DataType(DataType.DateTime)]
        public DateTime? SoldDate { get; set; }
    }
}
