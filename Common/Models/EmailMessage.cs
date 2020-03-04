using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Enums;
using Common.Interfaces;

namespace Common.Models
{
    public class EmailMessage : NewEmailMessage
    {
        public Guid Id { get; set; }
        public EmailStatus Status { get; set; }
    }
}
