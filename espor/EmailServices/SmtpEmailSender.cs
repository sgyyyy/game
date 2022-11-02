using EntityLayer;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace espor.EmailServices
{
    public class SmtpEmailSender : IEmailSender
    {
        private string _host;
        private int _port;
        private bool _enableSSL;
        private string _username;
        private string _password;
        private string _displayName;
        public SmtpEmailSender(string host, int port, bool enableSSL, string username, string password, string displayName)
        {
            this._host = host;
            this._port = port;
            this._enableSSL = enableSSL;
            this._username = username;
            this._password = password;
            this._displayName = displayName;
        }

        public async Task ResetPasswordSendEmailAsync(string email, string url)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_displayName, _username));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = "Reset Password";

            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = string.Format(@"Sayın kullanıcı, şifrenizi yenileyebilmek için <a href='https://localhost:44324{0}'>tıklayınız.</a>", url);

            message.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_host, _port, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(_username, _password);

                await smtp.SendAsync(message);
                smtp.Disconnect(true);
            }
        }

        public async Task SendEmailContactAsync(string email, string name, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_displayName, _username));
            message.To.Add(new MailboxAddress(_displayName, _username));
            message.Subject = "espor.com/contact sayfasından mesajınız var.";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "Sayın yetkili, " + name + " kişisinden gelen mesajın içeriği aşağıdaki gibidir. <br />" +
                "Ad Soyad: " + name + " <br /> " +
                "Mail Adresi: " + email + " <br /> " +
                "Konu: " + subject + " <br /> " +
                "Mesaj: " + htmlMessage + " <br /> ";

            message.Body = bodyBuilder.ToMessageBody();


            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_host, _port, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(_username, _password);

                await smtp.SendAsync(message);
                smtp.Disconnect(true);
            }
        }
    }
}
