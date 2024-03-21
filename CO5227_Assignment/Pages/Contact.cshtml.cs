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

        
        public bool? isSuccessful = null;
        
        
        public ContactModel(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        
        public async Task<IActionResult> OnPostSubmitAsync()
        {
            //Attempt to send email and set isSuccessful to track whether it was successfull or not
            try
            {
                await _emailSender.SendEmailAsync(Email, Subject, Body);
                isSuccessful = true;
                return Page();
            }catch (Exception ex)
            {
                isSuccessful = false;
                return Page();
            }
            
        }
        public void OnGet()
        {
        }
    }
}
