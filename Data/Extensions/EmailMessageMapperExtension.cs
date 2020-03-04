using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Enums;
using Data.Models;

namespace Data.Extensions
{
    public static class EmailMessageMapperExtension
    {
        public static Common.Models.EmailMessage MapToDto(this EmailMessage from)
        {
            return new Common.Models.EmailMessage
            {
                Body = from.Body,
                Id = from.Id,
                Sender = from.Sender,
                Status = (EmailStatus)from.Status,
                Subject = from.Subject,
                ToRecipients = from.ToRecipients.Split(";").ToList()
            };
        }

        public static EmailMessage MapFromNewDto(this Common.Models.NewEmailMessage from)
        {
            return new EmailMessage
            {
                Id = Guid.NewGuid(),
                Body = from.Body,
                Subject = from.Subject,
                Sender = from.Sender,
                Status = (int)EmailStatus.Pending,
                ToRecipients = string.Join(";", from.ToRecipients)
            };
        }
    }
}
