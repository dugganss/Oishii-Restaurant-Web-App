using CO5227_Assignment.wwwroot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CO5227_Assignment.Data;
using CO5227_Assignment.Models;

namespace CO5227_Assignment.Pages.AdminMenu
{
    public class userMenuModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CO5227_AssignmentContext _db;

        [BindProperty]
        public string Search {  get; set; }

        public IList<MenuItems> MenuItems { get; set; } = default!;

        public userMenuModel(CO5227_AssignmentContext db,UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult OnPostSearch()
        {
            MenuItems = _db.MenuItemss.FromSqlRaw("SELECT * FROM MenuItems Where itemName LIKE '" + Search +"%'").ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostBuyAsync(string itemID)
        {
            var user = await _userManager.GetUserAsync(User);
            CheckoutCustomer customer = await _db.CheckoutCustomers.FindAsync(user.Email);

            var item = _db.BasketItems.FromSqlRaw("SELECT * FROM BasketItems WHERE StockID = {0}" +
                " AND BasketID = {1}", itemID, customer.BasketID).ToList().FirstOrDefault();

            if (item == null) {
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
                catch (DbUpdateConcurrencyException ex) {
                    throw new Exception($"Basket not found!", ex);
                }
            }
            return RedirectToPage();

        }

        //private readonly CO5227_Assignment.Data.CO5227_AssignmentContext _context;

        //public userMenuModel(CO5227_Assignment.Data.CO5227_AssignmentContext context)
        //{
        //    _context = context;
        //}

        

        public async Task OnGetAsync()
        {
            if (_db.MenuItemss != null)
            {
                MenuItems = await _db.MenuItemss.ToListAsync();
            }
        }
    }
}
