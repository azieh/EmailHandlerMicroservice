using System;

namespace Data.Models
{
    public class EmailMessage
    {
        public Guid Id { get; set; }
        public string ToRecipients { get; set; }
        public int Status { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public string Sender { get; set; }
    }
}