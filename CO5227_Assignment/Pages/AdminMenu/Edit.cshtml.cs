using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CO5227_Assignment.Data;
using CO5227_Assignment.wwwroot.Models;

namespace CO5227_Assignment.Pages.AdminMenu
{
    public class EditModel : PageModel
    {
        private readonly CO5227_Assignment.Data.CO5227_AssignmentContext _context;

        public EditModel(CO5227_Assignment.Data.CO5227_AssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MenuItems MenuItems { get; set; } = default!;

        [BindProperty]
        public IFormFile Image { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.MenuItemss == null)
            {
                return NotFound();
            }

            var menuitems =  await _context.MenuItemss.FirstOrDefaultAsync(m => m.itemID == id);
            if (menuitems == null)
            {
                return NotFound();
            }
            MenuItems = menuitems;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MenuItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemsExists(MenuItems.itemID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MenuItemsExists(string id)
        {
          return _context.MenuItemss.Any(e => e.itemID == id);
        }
    }
}
