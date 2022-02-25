

using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Application.DTOs
{
    public class BidDto : BaseDto
    {

        
        public Guid BidderUserId { get; set; }
        public AppUserDto BidderAppUser { get; set; }

  
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

        [Required]
        [Range(0.01, 1000000.00, ErrorMessage = "Teklif fiyatı 0'dan büyük olmalıdır.")]
        public decimal BidPrice { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BidDate { get; set; }

        public short Quantity { get; set; } = 1;

        private decimal _totalPrice;

        public decimal TotalPrice
        {
            get
            {
                _totalPrice = BidPrice * Quantity;
                return _totalPrice;
            }
        }

        public bool IsSold { get; set; } = false;

        [DataType(DataType.DateTime)]
        public DateTime? SoldDate { get; set; }
    }
}
