using CO5227_Assignment.wwwroot.Models;
using System.ComponentModel.DataAnnotations;

namespace CO5227_Assignment.Data
{
    public class DbInit
    {
        public static void Initialise(CO5227_AssignmentContext context)
        {
            if (context.MenuItemss.Any())
            {
                return;
            }

            var menuItem = new MenuItems[]
            {
                new MenuItems
                {
                    //item1 (sig img 2)
                    itemID="00001",
                    itemName="Oishii Rolls",
                    description="Special Salmon, Kewpie Mayo and Panko crumb rolls. Definition of Oishii!",
                    price = 5.99F,
                    category= Category.Uramaki,
                    allergens=Allergens.Fish,
                    dietryRequirements=Diet.Meat,
                    storeID = "001",
                    special = true 
                },
                new MenuItems
                {
                    //item2 (sig img 5)
                    itemID="00002",
                    itemName="Mixture sushi with seasonings",
                    description="Temaki cone, maki and nigiri with a side of additions to enhance the sushi flavours",
                    price = 3.99F,
                    category= Category.Maki,
                    allergens=Allergens.Sesame,
                    dietryRequirements=Diet.Meat,
                    storeID = "001",
                    special = false
                },
                new MenuItems
                {
                    //item3 (sig img 3)
                    itemID="00003",
                    itemName="Oishii Bento",
                    description="Special Bento with Salmon Sashimi and a selection of Uramaki",
                    price = 8.99F,
                    category= Category.Bento,
                    allergens=Allergens.Fish,
                    dietryRequirements=Diet.Meat,
                    storeID = "001",
                    special = true
                },
                new MenuItems
                {
                    //item4 ()
                    itemID="00004",
                    itemName="Vegan Maki and Nigiri Platter",
                    description="Cucumber and Avocado Maki, and selection of Pepper Nigiri",
                    price = 5.99F,
                    category= Category.Platter,
                    allergens=Allergens.None,
                    dietryRequirements=Diet.Vegan,
                    storeID = "001",
                    special = false
                },
                new MenuItems
                {
                    //item4 (sig img 6)
                    itemID="00005",
                    itemName="Uramaki and Nigiri Platter",
                    description="Selection of Uramaki with Salmon and Tuna Nigiri",
                    price = 7.99F,
                    category= Category.Platter,
                    allergens=Allergens.Gluten,
                    dietryRequirements=Diet.Meat,
                    storeID = "001",
                    special = true
                }
            };

            context.MenuItemss.AddRange(menuItem);
            context.SaveChanges();
        }
    }
}
    
