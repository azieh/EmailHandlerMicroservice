﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmailHandlerRepository.Models
{
    public class EmailMessage
    {
        public Guid Id { get; set; }
        public List<User> ToRecipients { get; set; }
        public List<User> CcRecipients { get; set; }
        public int Status { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public int UserId { get; set; }
        public User Sender { get; set; }
    }
}
