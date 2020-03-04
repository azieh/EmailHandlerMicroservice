using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Utilities;

namespace Common.Models
{
    public class NewEmailMessage
    {
        [Required] [EmailValidator] public string Sender { get; set; }

        [EmailListValidator] public IEnumerable<string> ToRecipients { get; set; }

        [Required(ErrorMessage = "Email subject is required")]
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}