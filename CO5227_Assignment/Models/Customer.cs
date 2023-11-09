using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CO5227_Assignment.wwwroot.Models
{
    public class Customer
    {
        [Required, StringLength(200)]
        public string address { get; set; }

        [Required, StringLength(80)]
        public string email { get; set; }

        [Required, StringLength(11)]
        public string phone { get; set; }

        [Required, StringLength(5), Key]
        public string customerID { get; set; }
    }
}
