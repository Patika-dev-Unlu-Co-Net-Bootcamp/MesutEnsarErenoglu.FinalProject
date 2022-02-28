using FinalProject.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Models.Product
{
    public class AddProductClientModel
    {
        [Required(ErrorMessage = "Ürün adı gereklidir!")]
        [MaxLength(100, ErrorMessage = "100 karakterden fazla olamaz!")]
        [JsonPropertyName("productname")]
        public string ProductName { get; set; }

        [JsonPropertyName("description")]
        [MaxLength(500, ErrorMessage = "500 karakterden fazla olamaz!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Ürün fiyatı gereklidir!")]
        [Range(0.01, 1000000.00, ErrorMessage = "Ürün fiyatı 0'dan büyük olmalıdır.")]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Ürün stok adedi belirtilmelidir!")]
        [JsonPropertyName("unitsinstock")]
        public short UnitsInStock { get; set; }

        [Required(ErrorMessage = "Tekliflere açık olup olmadığını belirtmeniz gereklidir!")]
        [JsonPropertyName("isofferdable")]
        public bool IsOfferdable { get; set; }


        [Required(ErrorMessage = "Ürün tanımı için kategori seçimi yapmanız gereklidir!")]
        [JsonPropertyName("subcategoryid")]
        public int SubCategoryId { get; set; }

        [Required]
        [JsonPropertyName("appuserid")]
        public string AppUserId { get; set; }

        [JsonPropertyName("colorid")]
        public int? ColorId { get; set; }

        [JsonPropertyName("brandid")]
        public int? BrandId { get; set; }

        [JsonPropertyName("usagestatus")]
        [Required(ErrorMessage = "Ürün kullanım durumu belirtilmelidir!")]
        public UsageStatus UsageStatus { get; set; }

        [MaxLength(409600,ErrorMessage ="400kb'den büyük olamaz!")]
        public IFormFile ImageFile { get; set; }
    }
}
