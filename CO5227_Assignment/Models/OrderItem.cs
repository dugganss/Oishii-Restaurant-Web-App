using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CO5227_Assignment.Models
{
    public class OrderItem
    {
        [Required, Key, Column(Order = 0)]
        public int OrderNo { get; set; }
        
        [Required, Key, Column(Order = 1)]
        public string StockID { get; set; }
        
        [Required]
        public int Quantity { get; set; }
    }
}
