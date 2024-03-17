using CO5227_Assignment.Areas.Email.Interfaces;
using System.Net;
using System.Net.Mail;

namespace CO5227_Assignment.Areas.Email
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string body) {
            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("oishiisushi123@outlook.com", "Oishii4life!")
            };

            subject = email + ": " + subject;

            return client.SendMailAsync(
                new MailMessage(from: "oishiisushi123@outlook.com",
                to: "oishiisushi123@outlook.com",
                subject,
                body
                ));
        }
    }
}
