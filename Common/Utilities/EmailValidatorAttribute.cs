using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Utilities
{
    class EmailValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value.IsEmail();
        }
    }
}
