using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CO5227_Assignment.Data;
using CO5227_Assignment.wwwroot.Models;

namespace CO5227_Assignment.Pages.MenuFolder
{
    public class DetailsModel : PageModel
    {
        private readonly CO5227_Assignment.Data.CO5227_AssignmentContext _context;

        public DetailsModel(CO5227_Assignment.Data.CO5227_AssignmentContext context)
        {
            _context = context;
        }

      public MenuItems MenuItems { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.MenuItemss == null)
            {
                return NotFound();
            }

            var menuitems = await _context.MenuItemss.FirstOrDefaultAsync(m => m.itemID == id);
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
    }
}
