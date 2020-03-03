using System;
using System.Collections.Generic;
using System.Text;

namespace EmailHandlerRepository.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }

        public List<EmailMessage> EmailMessages { get; set; }
    }
}
