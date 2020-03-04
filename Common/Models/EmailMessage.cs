using System;
using Common.Enums;

namespace Common.Models
{
    public class EmailMessage : NewEmailMessage
    {
        public Guid Id { get; set; }
        public EmailStatus Status { get; set; }
    }
}