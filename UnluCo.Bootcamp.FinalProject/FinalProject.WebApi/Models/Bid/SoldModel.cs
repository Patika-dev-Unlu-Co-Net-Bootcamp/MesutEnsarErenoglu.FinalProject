
using System.ComponentModel.DataAnnotations;

namespace FinalProject.WebApi.Models.Bid
{
    public class SoldModel
    {
        [Required(ErrorMessage = "Satın alacak kullanıcı id belirtilmelidir!")]
        public string BidderUserId { get; set; }

        public short Quantity { get; set; } = 1;
    }
}
