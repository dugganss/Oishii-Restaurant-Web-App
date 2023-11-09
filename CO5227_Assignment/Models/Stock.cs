using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CO5227_Assignment.wwwroot.Models
{
    public class Stock
    {
        [Required, StringLength(5), Key]
        public string storeID { get; set; }

        [Required, StringLength(5), Key]
        public string itemID { get; set; }

        [Required]
        public bool inStock { get; set; }
        
        public string itemLocation { get; set; }
    }
}
