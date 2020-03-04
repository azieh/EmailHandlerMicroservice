using System.Collections;

namespace Common.Utilities
{
    internal class EmailListValidatorAttribute : EmailValidatorAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IEnumerable;
            if (list == null) return true;

            return list.IsEmailList();
        }
    }
}