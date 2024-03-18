using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CO5227_Assignment.Data;
using CO5227_Assignment.wwwroot.Models;
using CO5227_Assignment.Models;
using Microsoft.AspNetCore.Identity;

namespace CO5227_Assignment.Pages.AdminMenu
{
    public class DetailsModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CO5227_AssignmentContext _db;

        public DetailsModel(UserManager<IdentityUser> userManager, CO5227_AssignmentContext db )
        {
            _db = db;
            _userManager = userManager;
        }

        public MenuItems MenuItems { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            
            if (id == null || _db.MenuItemss == null)
            {
                    return NotFound();
            }

            var menuitems = await _db.MenuItemss.FirstOrDefaultAsync(m => m.itemID == id);
            if (menuitems == null)
            {
                return NotFound();
            }
            else 
            {
                MenuItems = menuitems;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostBuyAsync(string itemID)
        {
            var user = await _userManager.GetUserAsync(User);
            CheckoutCustomer customer = await _db.CheckoutCustomers.FindAsync(user.Email);

            var item = _db.BasketItems.FromSqlRaw("SELECT * FROM BasketItems WHERE StockID = {0}" +
                " AND BasketID = {1}", itemID, customer.BasketID).ToList().FirstOrDefault();

            if (item == null)
            {
                BasketItem newItem = new BasketItem
                {
                    BasketID = customer.BasketID,
                    StockID = itemID,
                    Quantity = 1
                };
                _db.BasketItems.Add(newItem);
                await _db.SaveChangesAsync();
            }
            else
            {
                item.Quantity = item.Quantity + 1;
                _db.Attach(item).State = EntityState.Modified;
                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception($"Basket not found!", ex);
                }
            }
            return RedirectToAction("OnGetAsync", new {id = itemID});

        }

    }
}
