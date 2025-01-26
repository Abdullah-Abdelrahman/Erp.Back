using Name.Service.Abstracts;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Name.Service.Implementations
{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> SendEmailAsync(string email, string Message, string? reason)
        {
            try
            {
                //sending the Message of passwordResetLink
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587);
                    client.Authenticate(_configuration.GetSection("Email")["FromEmail"], _configuration.GetSection("Email")["Password"]);

                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{Message}",
                        TextBody = "wellcome",
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("Tcno Team", _configuration.GetSection("Email")["FromEmail"]));
                    message.To.Add(new MailboxAddress("testing", email));
                    message.Subject = reason == null ? "Default Subject" : reason;
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                //end of sending email
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }
    }
}
