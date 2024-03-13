using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
namespace CO5227_Assignment.Models
{
    public class BasketItem
    {
        [Required, StringLength(5)]
        public string StockID { get; set; }
        [Required]
        public int BasketID { get; set;}
        [Required]
        public int Quantity { get; set; }
    }
}
