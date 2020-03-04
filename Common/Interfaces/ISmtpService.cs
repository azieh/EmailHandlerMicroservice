using System.Net.Mail;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces
{
    public interface ISmtpService
    {
        MailMessage GenerateMailMessage(EmailMessage emailMessage);

        Task SendEmailAsync(EmailMessage emailMessage);
    }
}