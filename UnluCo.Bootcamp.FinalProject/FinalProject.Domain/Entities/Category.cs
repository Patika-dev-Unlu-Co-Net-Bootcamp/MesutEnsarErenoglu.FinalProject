using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FinalProject.Domain.Entities.Abstract;

namespace FinalProject.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz")]
        public string CategoryName { get; set; }

        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Description { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
