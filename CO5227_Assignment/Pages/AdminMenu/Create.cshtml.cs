using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CO5227_Assignment.Data;
using CO5227_Assignment.wwwroot.Models;



namespace CO5227_Assignment.Pages.AdminMenu
{
    public class CreateModel : PageModel
    {
        private readonly CO5227_Assignment.Data.CO5227_AssignmentContext _context;

        public CreateModel(CO5227_Assignment.Data.CO5227_AssignmentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MenuItems MenuItems { get; set; }




        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                MenuItems.imgData = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            _context.MenuItemss.Add(MenuItems);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
