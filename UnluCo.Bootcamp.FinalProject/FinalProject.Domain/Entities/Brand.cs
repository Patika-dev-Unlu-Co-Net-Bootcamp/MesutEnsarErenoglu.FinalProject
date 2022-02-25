

using System.ComponentModel.DataAnnotations;
using FinalProject.Domain.Entities.Abstract;

namespace FinalProject.Domain.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla olamaz!")]
        public string Name { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz!")]
        public string Description { get; set; }
    }
}
