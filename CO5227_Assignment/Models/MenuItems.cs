using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CO5227_Assignment.wwwroot.Models
{

    public enum Category
    {
        Maki, Nigiri, Sashimi, Uramaki, Platter, Bento
    }

    public enum Allergens
    {
        Gluten, Milk, Nuts, Fish, Egg, Sesame, None
    }

    public enum Diet
    {
        Vegan, Vegetarian, Meat
    }

    public class MenuItems
    {

        [Required, StringLength(5), Key]
        public string itemID { get; set; }
        
        [Required, StringLength(20)]
        public string itemName { get; set; }
        
        [StringLength(200)]
        public string description { get; set; }
        
        [Required, DataType(DataType.Currency) ]
        public float price { get; set; }
        
        [Required]
        public Category category { get; set; }
        
        //todo: change from enum so items can have multiple allergens
        [Required]
        public Allergens allergens { get; set; }
        
        [Required]
        public Diet dietryRequirements { get; set; }
        
        [Required, StringLength(3)]
        public string storeID { get; set; }

        public bool special { get; set; }

        public string imgDescription { get; set; }

        public byte[] imgData { get; set; }



    }
}
