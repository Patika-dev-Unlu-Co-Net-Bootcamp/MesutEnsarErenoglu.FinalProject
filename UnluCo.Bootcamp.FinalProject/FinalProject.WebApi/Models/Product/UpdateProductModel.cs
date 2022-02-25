
using FinalProject.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.WebApi.Models.Product
{
    public class UpdateProductModel
    {
        [Required(ErrorMessage = "Ürün adı gereklidir!")]
        [MaxLength(100, ErrorMessage = "100 karakterden fazla olamaz!")]
        public string ProductName { get; set; }

        [MaxLength(500, ErrorMessage = "500 karakterden fazla olamaz!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Ürün fiyatı gereklidir!")]
        [Range(0.01, 1000000.00, ErrorMessage = "Ürün fiyatı 0'dan büyük olmalıdır.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Ürün stok adedi belirtilmelidir!")]
        public short UnitsInStock { get; set; }

        [Required(ErrorMessage = "Tekliflere açık olup olmadığını belirtmeniz gereklidir!")]
        public bool IsOfferdable { get; set; } 

        [Required(ErrorMessage = "Ürün tanımı için kategori seçimi yapmanız gereklidir!")]
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "Ürün kullanım durumu belirtilmelidir!")]
        public UsageStatus UsageStatus { get; set; }
    }
}
