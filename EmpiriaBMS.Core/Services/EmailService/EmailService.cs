using System.Net;
using System.Net.Mail;

namespace EmpiriaBMS.Core.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _smtpServerAddress;
        private readonly string _smtpAuthUsername;
        private readonly string _smtpAuthPassword;
        private readonly string _sender;

        public EmailService()
        {
            _smtpServerAddress = "smtp.gmail.com";
            _smtpAuthUsername = "alexandrosplatanios15@gmail.com";
            _smtpAuthPassword = "-Plat1234Tak1234!!";
            _sender = "alexandrosplatanios15@gmail.com";
            _smtpClient = new SmtpClient(_smtpServerAddress)
            {
                Port = 465,
                Credentials = new NetworkCredential(_smtpAuthUsername, _smtpAuthPassword),
                EnableSsl = true,
            };
        }

        public async Task SendEmailAsync(string subject, string body, string[] recipients)
        {
            var message = new MailMessage
            {
                From = new MailAddress(_sender),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            foreach (var recipient in recipients)
            {
                message.To.Add(recipient);
            }

            await _smtpClient.SendMailAsync(message);
        }
    }
}
