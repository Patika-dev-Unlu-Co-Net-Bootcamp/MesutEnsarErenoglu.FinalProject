using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Common.Enums;
using FinalProject.Domain.Entities.Abstract;

namespace FinalProject.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(100, ErrorMessage = "100 karakterden fazla olamaz!")]
        public string ProductName { get; set; }

        [MaxLength(500, ErrorMessage = "500 karakterden fazla olamaz!")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 1000000.00,ErrorMessage ="Ürün fiyatı 0'dan büyük olmalıdır!")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required]
        public short UnitsInStock { get; set; }

        [Required(ErrorMessage = "Tekliflere açık olup olmadığını belirtmeniz gereklidir!")]
        public bool IsOfferdable { get; set; } = false;

        [Required(ErrorMessage ="Ürüne ait fotoğraf eklenmelidir!")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage ="Ürün için kategori seçimi yapmanız gereklidir!")]
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }

        
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AppUser AppUser { get; set; }

        
        public int? ColorId { get; set; }
        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }

        
        public int? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [Required(ErrorMessage ="Ürün kullanım durumu belirtilmelidir!")]
        public UsageStatus UsageStatus { get; set; }


    }
}
