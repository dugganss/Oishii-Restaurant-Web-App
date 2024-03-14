using System.ComponentModel.DataAnnotations;

namespace CO5227_Assignment.Models
{
    public class CheckoutItem
    {
        [Key, Required]
        public string itemID { get; set; }
        [Required, DataType(DataType.Currency)]
        public float price { get; set; }
        [Required, StringLength(60)]
        public string itemName { get; set; }
        [Required]
        public int quantity { get; set;}
    }
}
