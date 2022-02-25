
using FinalProject.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Application.DTOs
{
    public class ProductDto :BaseDto 
    {

        [Required]
        [MaxLength(100, ErrorMessage = "100 karakterden fazla olamaz!")]
        public string ProductName { get; set; }

        [MaxLength(500, ErrorMessage = "500 karakterden fazla olamaz!")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 1000000.00, ErrorMessage = "Ürün fiyatı 0'dan büyük olmalıdır.")]
        public decimal Price { get; set; }

        [Required]
        public short UnitsInStock { get; set; }

        [Required(ErrorMessage = "Tekliflere açık olup olmadığını belirtmeniz gereklidir!")]
        public bool IsOfferdable { get; set; } = false;

        [Required(ErrorMessage = "Ürüne ait fotoğraf eklenmelidir!")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Ürün tanımı için kategori seçimi yapmanız gereklidir!")]
        
        public int SubCategoryId { get; set; }
        public SubCategoryDto SubCategory { get; set; }

        
        public string AppUserId { get; set; }

        public  AppUserDto AppUser { get; set; }

        
        public int? ColorId { get; set; }

        public ColorDto Color { get; set; }

        
        public int? BrandId { get; set; }

        public BrandDto Brand { get; set; }

        [Required(ErrorMessage = "Ürün kullanım durumu belirtilmelidir!")]
        public UsageStatus UsageStatus { get; set; }
    }
}
