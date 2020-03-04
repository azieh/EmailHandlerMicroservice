using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;
using Common.Utilities;

namespace Services
{
    public class SmtpService : ISmtpService
    {
        private readonly Lazy<SmtpClient> _smtpClientLazy;
        private string DefaultSenderAddress => "default@wasielewskitest.com";

        public SmtpService(SmtpClient smtpClient)
        {
            if (smtpClient is null)
                throw new ArgumentNullException(nameof(smtpClient));

            _smtpClientLazy = new Lazy<SmtpClient>(() => smtpClient);
        }

        public MailMessage GenerateMailMessage(EmailMessage emailMessage)
        {
            var sender = string.IsNullOrEmpty(emailMessage.Sender) ? DefaultSenderAddress : emailMessage.Sender;

            if(!sender.IsEmail())
                throw new ArgumentException($"{nameof(sender)} is not valid format");
            if (!emailMessage.To.IsEmail())
                throw new ArgumentException($"{nameof(emailMessage.To)} is not valid format");

            if (string.IsNullOrEmpty(emailMessage.Subject))
                throw new ArgumentException($"{nameof(emailMessage.Subject)} cannot be empty");

            MailAddress from = new MailAddress(sender);
            MailAddress to = new MailAddress(emailMessage.To);

            MailMessage message = new MailMessage(from, to)
            {
                Subject = emailMessage.Subject,
                Body = emailMessage.Body
            };
            foreach (var recipient in emailMessage.ToRecipients.Where(x => x.IsEmail()))
            {
                MailAddress cc = new MailAddress(recipient);
                message.CC.Add(cc);
            }
            return message;
        }

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            var mailMessage = GenerateMailMessage(emailMessage);
#if !DEBUG
             await _smtpClientLazy.Value.SendMailAsync(mailMessage);
#endif
        }
    }
}
