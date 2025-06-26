using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Orbital_Africa_Backend_Recon.Modal.Email;
using Orbital_Africa_Backend_Recon.Service;
using AutoMapper.Internal;

namespace Orbital_Africa_Backend_Recon.Container
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        public EmailService(IOptions<EmailSettings>options)
        {
            this._settings=options.Value;
        }

        public async Task SendEmail(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_settings.Email);
            email.To.Add(MailboxAddress.Parse(mailRequest.Email));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.EmailBody;
            email.Body = builder.ToMessageBody();

            using var smptp = new SmtpClient();
            smptp.Connect(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
            smptp.Authenticate(_settings.Email, _settings.Password);
            await smptp.SendAsync(email);
            smptp.Disconnect(true);
        }

    }
}
