using Microsoft.AspNetCore.Mvc.RazorPages;
using CO5227_Assignment.Data;

namespace CO5227_Assignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private readonly CO5227_AssignmentContext _db;
        public void OnGet()
        {

        }
    }
}