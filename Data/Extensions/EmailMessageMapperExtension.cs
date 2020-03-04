using System;
using System.Linq;
using Common.Enums;
using Common.Models;

namespace Data.Extensions
{
    public static class EmailMessageMapperExtension
    {
        public static EmailMessage MapToDto(this Models.EmailMessage from)
        {
            return new EmailMessage
            {
                Body = from.Body,
                Id = from.Id,
                Sender = from.Sender,
                Status = (EmailStatus)from.Status,
                Subject = from.Subject,
                ToRecipients = from.ToRecipients.Split(";").ToList(),
                To = from.To,
                Priority = from.Priority
            };
        }

        public static Models.EmailMessage MapFromNewDto(this NewEmailMessage from)
        {
            return new Models.EmailMessage
            {
                Id = Guid.NewGuid(),
                Body = from.Body,
                Subject = from.Subject,
                Sender = from.Sender,
                Status = (int) EmailStatus.Pending,
                ToRecipients = string.Join(";", from.ToRecipients),
                To = from.To,
                Priority = from.Priority
            };
        }
    }
}