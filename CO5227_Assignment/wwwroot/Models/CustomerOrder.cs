namespace CO5227_Assignment.wwwroot.Models
{
    public class CustomerOrder
    {
        [Required, StringLength(3), Key]
        public string orderNo { get; set; }

        [Key, Required, StringLength(5)]
        public string storeID { get; set; }
    }
}
