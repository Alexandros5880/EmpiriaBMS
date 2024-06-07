using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Services.EmailService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Front.Horizontal;

public class DailyEmailSender
{
    private readonly IEmailService _emailService;
    private readonly IDataProvider _dataProvider;

    public DailyEmailSender(IEmailService emailService, IDataProvider dataProvider)
    {
        _emailService = emailService;
        _dataProvider = dataProvider;
    }

    public async Task SendDailyEmail()
    {
        try
        {
            // Get all users from the database or any other data source
            string[] allUsersEmails = await GetUsersEmails();

            string subject = "Embiria BMS Message";
            string body = "Please don't forget to stop working!";

            await _emailService.SendEmailAsync(subject, body, allUsersEmails);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception in DailyEmailSender.SendDailyEmail() \n Exception: {ex.Message} \n Inner Exception: {ex.InnerException.Message}");
        }
    }

    private async Task<string[]> GetUsersEmails()
    {
        var usersEmails = await _dataProvider.Users.GetEmails();
        return usersEmails.Select(e => e.Address).ToArray();
    }
}