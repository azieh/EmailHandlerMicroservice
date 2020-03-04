using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Common.Utilities
{
    class EmailListValidatorAttribute : EmailValidatorAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IEnumerable;
            if (list == null) return true;

            return list.IsEmailList();
        }
    }
}
