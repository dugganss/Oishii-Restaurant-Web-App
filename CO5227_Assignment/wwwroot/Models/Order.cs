namespace CO5227_Assignment.wwwroot.Models
{
    public class Order
    {
        [Required, StringLength(3), Key]
        public string orderNo { get; set; }

        [Required]
        public string foodOrder {  get; set; }

        [Required, StringLength(5), Key]
        public string customerID { get; set; }
    }
}
