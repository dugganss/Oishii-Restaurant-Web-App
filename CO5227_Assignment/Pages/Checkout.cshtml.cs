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
        public OrderHistory Order = new OrderHistory();
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
            if (user != null)
            {
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

        public async Task<IActionResult> OnPostBuyAsync()
        {
            var currentOrder = _db.OrderHistories.FromSqlRaw("SELECT * FROM OrderHistories").OrderByDescending(b=> b.OrderNo).FirstOrDefault();

            if(currentOrder == null)
            {
                Order.OrderNo = 1;
            }
            else
            {
                Order.OrderNo = currentOrder.OrderNo+ 1;
            }

            var user = await _userManager.GetUserAsync(User);
            Order.Email = user.Email;
            _db.OrderHistories.Add(Order);

            CheckoutCustomer customer = await _db.CheckoutCustomers.FindAsync(user.Email);

            var basketItems = _db.BasketItems.FromSqlRaw("SELECT * FROM BasketItems WHERE BasketID = {0}", customer.BasketID).ToList();

            foreach(var item in basketItems)
            {
                OrderItem oi = new OrderItem
                {
                    OrderNo = Order.OrderNo,
                    StockID = item.StockID,
                    Quantity = item.Quantity
                };

                _db.OrderItems.Add(oi);
                _db.BasketItems.Remove(item);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("/Index");
        }
    }
}
