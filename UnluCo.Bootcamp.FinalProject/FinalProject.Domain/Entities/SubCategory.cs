using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Domain.Entities.Abstract;

namespace FinalProject.Domain.Entities
{
    public class SubCategory : BaseEntity
    {
        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz")]
        public string SubCategoryName { get; set; }

        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
