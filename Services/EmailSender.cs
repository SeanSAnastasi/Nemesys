using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Nemesys.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace WebPWrecover.Services
{
    public class EmailSender : IMailService
    {

        private IConfiguration _configuration;

        public EmailSender( IConfiguration configuration)
        {
            
            _configuration = configuration;
        }

        

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var apiKey = _configuration["SendGridAPIKey"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("nemesysmt@gmail.com", "Nemesys");

                var to = new EmailAddress(email);

                var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
                var response = await client.SendEmailAsync(msg);
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}