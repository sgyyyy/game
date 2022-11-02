using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace espor.EmailServices
{
    public interface IEmailSender
    {
        // smtp => gmail, hotmail
        // api => sendgrid

        Task ResetPasswordSendEmailAsync(string email, string url);
        Task SendEmailContactAsync(string email, string name, string subject, string htmlMessage);
    }
}
