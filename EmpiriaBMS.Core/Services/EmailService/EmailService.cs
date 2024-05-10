using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Services.EmailService;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly string _mySmtpServerAddress;
    private readonly string _myEmailAddress;
    private readonly string _myEmailAddressPassword;

    public EmailService()
    {
        _mySmtpServerAddress = "your_smtp_server_address";
        _myEmailAddress = "your_email_address";
        _myEmailAddressPassword = "your_email_password";
        _smtpClient = new SmtpClient(_mySmtpServerAddress)
        {
            Port = 587,
            Credentials = new NetworkCredential(_myEmailAddress, _myEmailAddressPassword),
            EnableSsl = true,
        };
    }

    public async Task SendEmailAsync(string subject, string body, string[] recipients)
    {
        var message = new MailMessage
        {
            From = new MailAddress(_myEmailAddress),
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