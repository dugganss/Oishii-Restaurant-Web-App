using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CO5227_Assignment.Data;
using CO5227_Assignment.wwwroot.Models;
using Microsoft.AspNetCore.Authorization;

namespace CO5227_Assignment.Pages.AdminMenu
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly CO5227_Assignment.Data.CO5227_AssignmentContext _context;

        public IndexModel(CO5227_Assignment.Data.CO5227_AssignmentContext context)
        {
            _context = context;
        }

        public IList<MenuItems> MenuItems { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MenuItemss != null)
            {
                MenuItems = await _context.MenuItemss.ToListAsync();
            }
        }
    }
}
