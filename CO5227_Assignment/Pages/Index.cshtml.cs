using Microsoft.AspNetCore.Mvc.RazorPages;
using CO5227_Assignment.Data;
using CO5227_Assignment.wwwroot.Models;
using Microsoft.EntityFrameworkCore;

namespace CO5227_Assignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CO5227_AssignmentContext _context;

        public IndexModel(ILogger<IndexModel> logger, CO5227_AssignmentContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<MenuItems> signatures { get; set; } = default!;
        public IList<MenuItems> allMenuItems { get; set; } = default!;
        public void OnGet()
        {
            //retrieves all special items from menuItems and saves it to signatures
            signatures = _context.MenuItemss.FromSqlRaw("Select * From MenuItems WHERE special = 1").ToList();
            //retrieves all menuItems and saves it to allMenuItems
            allMenuItems = _context.MenuItemss.FromSqlRaw("Select * From MenuItems").ToList();
        }
    }
}