using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Domain.Entities.Abstract;

namespace FinalProject.Domain.Entities
{
    public class Bid:BaseEntity
    {

        public string BidderUserId { get; set; }
        [ForeignKey("BidderUserId")]
        public virtual AppUser BidderAppUser { get; set; }


        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        [Range(0.01, 1000000.00, ErrorMessage = "Ürün fiyatı 0'dan büyük olmalıdır!")]
        [Column(TypeName = "decimal(18,4)")]
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
