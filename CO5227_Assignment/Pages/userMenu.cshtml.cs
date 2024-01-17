using CO5227_Assignment.wwwroot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CO5227_Assignment.Pages
{
    public class userMenuModel : PageModel
    {
        private readonly CO5227_Assignment.Data.CO5227_AssignmentContext _context;

        public userMenuModel(CO5227_Assignment.Data.CO5227_AssignmentContext context)
        {
            _context = context;
        }

        public IList<MenuItems> MenuItems { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MenuItemss != null)
            {
                MenuItems = await _context.MenuItemss.ToListAsync();
            }
        }
    }
}
