using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net.Mail;
using System.Net;

namespace PLASTIC_WARFARE_PROJ.Services
{
    public class EmailSender : IEmailSender
    {

        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;

        public EmailSender(string smtpServer, int smtpPort, string smtpUser, string smtpPass)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUser = smtpUser;
            _smtpPass = smtpPass;
        }


        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var client = new SmtpClient(_smtpServer, _smtpPort)
                {
                    Credentials = new NetworkCredential(_smtpUser, _smtpPass),
                    EnableSsl = true,
                };

                return client.SendMailAsync(
                    new MailMessage(_smtpUser, email, subject, htmlMessage) { IsBodyHtml = true }
                );
            }catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            
        }
    }
}
