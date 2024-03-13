using System.ComponentModel.DataAnnotations;

namespace CO5227_Assignment.Models
{
    public class CheckoutCustomer
    {
        [Key]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int BasketID { get; set; }
    }
}
