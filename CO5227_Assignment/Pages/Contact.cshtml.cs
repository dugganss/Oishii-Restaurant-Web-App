using CO5227_Assignment.Areas.Email.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CO5227_Assignment.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IEmailSender _emailSender;
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Subject { get; set; }
        [BindProperty]
        public string Body { get; set; }
        
        public ContactModel(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        
        public async Task<IActionResult> OnPostSubmitAsync()
        {
            await _emailSender.SendEmailAsync(Email, Subject, Body);
            return Page();
        }
        public void OnGet()
        {
        }
    }
}
