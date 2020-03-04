using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Common.Enums;
using Common.Interfaces;

namespace Common.Models
{
    public class NewEmailMessage
    {
        [Required]
        public string Sender { get; set; }
        public IEnumerable<string> ToRecipients { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
