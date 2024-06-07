using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EmpiriaBMS.Core.Services.EmailService;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly string _smtpServerAddress;
    private readonly string _smtpAuthUsername;
    private readonly string _smtpAuthPassword;
    private readonly string _sender;

    public EmailService()
    {
        _smtpServerAddress = "smtp.azurecomm.net";
        _smtpAuthUsername = "<Azure Communication Services Resource name>|<Entra Application Id>|<Entra Application Tenant Id>";
        _smtpAuthPassword = "<Entra Application Client Secret>";
        _sender = "empiriasoft@empiriasoftplat.onmicrosoft.com";
        _smtpClient = new SmtpClient(_smtpServerAddress)
        {
            Port = 587,
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