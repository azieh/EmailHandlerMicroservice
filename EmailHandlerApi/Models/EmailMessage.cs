﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmailHandlerApi.Models
{
    public class EmailMessage
    {
        public Guid Id { get; set; }
        [Required]
        public string Sender { get; set; }
        public IEnumerable<string> ToRecipients { get; set; }
        public IEnumerable<string> CcRecipients { get; set; }
        public string Status { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
