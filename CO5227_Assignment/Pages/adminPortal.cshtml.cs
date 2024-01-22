using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace CO5227_Assignment.Pages
{
    [Authorize (Roles = "Admin")]
    public class adminPortalModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
