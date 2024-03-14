using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity;
using CO5227_Assignment.Data;
using CO5227_Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Features;

namespace CO5227_Assignment.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly CO5227_AssignmentContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public IList<CheckoutItem> Items { get; private set; }
        //public int size;

        public decimal Total;
        public long AmountPayable;

        public CheckoutModel(CO5227_AssignmentContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            CheckoutCustomer customer = await _db.CheckoutCustomers.FindAsync(user.Email);

            Items = _db.CheckoutItems.FromSqlRaw(
                "SELECT MenuItems.itemID, MenuItems.price, MenuItems.itemName, BasketItems.BasketID, BasketItems.Quantity " +
                "FROM MenuItems INNER JOIN BasketItems ON MenuItems.itemID = BasketItems.StockID WHERE BasketID = {0}",
                customer.BasketID).ToList();

            Total = 0;

            //size = Items.Count;

            foreach (var item in Items)
            {
                //item.quantity
                
                Total += (item.quantity * (decimal)item.price);
            }
            AmountPayable = (long)Total;  
        }
    }
}
