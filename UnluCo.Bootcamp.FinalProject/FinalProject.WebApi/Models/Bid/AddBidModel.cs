﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.WebApi.Models.Bid
{
    public class AddBidModel
    {
        [Required(ErrorMessage = "Teklif yapan kullanıcı id belirtilmelidir!")]
        public string BidderUserId { get; set; }

        [Required(ErrorMessage = "Ürün id belirtilmelidir!")]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Ürün için teklif edilecek fiyat belirtilmelidir!")]
        [Range(0.01, 1000000.00, ErrorMessage = "Teklif fiyatı 0'dan büyük olmalıdır.")]
        public decimal BidPrice { get; set; }
        public short Quantity { get; set; } = 1;
    }
}
