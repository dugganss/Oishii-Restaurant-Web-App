namespace CO5227_Assignment.wwwroot.Models
{
    public class Restaurant
    {
        [Key, Required, StringLength(5)]
        public string storeID { get; set; }
        
        [Required, StringLength(200)]
        public string address { get; set; }
        
        [Required, StringLength(11)]
        public string contactNo { get; set; }
    }
}
