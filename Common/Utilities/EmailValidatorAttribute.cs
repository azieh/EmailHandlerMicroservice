using System.ComponentModel.DataAnnotations;

namespace Common.Utilities
{
    internal class EmailValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return string.IsNullOrEmpty(value.ToString()) || value.IsEmail();
        }
    }
}