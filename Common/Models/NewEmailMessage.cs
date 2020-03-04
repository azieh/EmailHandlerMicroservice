using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Utilities;

namespace Common.Models
{
    public class NewEmailMessage
    {
        [EmailValidator] public string Sender { get; set; }

        [Required] [EmailValidator] public string To { get; set; }

        [EmailListValidator] public IEnumerable<string> ToRecipients { get; set; }

        [Required(ErrorMessage = "Email subject is required")]
        public string Subject { get; set; }

        public string Body { get; set; }

        public int Priority { get; set; }
    }
}