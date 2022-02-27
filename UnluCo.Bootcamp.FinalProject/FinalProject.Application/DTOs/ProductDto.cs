
using FinalProject.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinalProject.Application.DTOs
{
    public class ProductDto :BaseDto 
    {

        [Required]
        [MaxLength(100, ErrorMessage = "100 karakterden fazla olamaz!")]
        [JsonPropertyName("productname")]
        public string ProductName { get; set; }

        [MaxLength(500, ErrorMessage = "500 karakterden fazla olamaz!")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 1000000.00, ErrorMessage = "Ürün fiyatı 0'dan büyük olmalıdır.")]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [Required]
        [JsonPropertyName("unitsinstock")]
        public short UnitsInStock { get; set; }

        [Required(ErrorMessage = "Tekliflere açık olup olmadığını belirtmeniz gereklidir!")]
        [JsonPropertyName("isofferdable")]
        public bool IsOfferdable { get; set; } = false;

        [Required(ErrorMessage = "Ürüne ait fotoğraf eklenmelidir!")]
        [JsonPropertyName("imagepath")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Ürün tanımı için kategori seçimi yapmanız gereklidir!")]
        [JsonPropertyName("subcategoryid")]

        public int SubCategoryId { get; set; }

        [JsonPropertyName("subcategory")]
        public SubCategoryDto SubCategory { get; set; }

        [JsonPropertyName("appuserid")]
        public string AppUserId { get; set; }
        [JsonPropertyName("appuser")]
        public  AppUserDto AppUser { get; set; }

        [JsonPropertyName("colorid")]
        public int? ColorId { get; set; }
        [JsonPropertyName("color")]
        public ColorDto Color { get; set; }

        [JsonPropertyName("brandid")]
        public int? BrandId { get; set; }

        [JsonPropertyName("brand")]
        public BrandDto Brand { get; set; }

        [JsonPropertyName("usagestatus")]
        [Required(ErrorMessage = "Ürün kullanım durumu belirtilmelidir!")]
        public UsageStatus UsageStatus { get; set; }
    }
}
