using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace Common.Utilities
{
    public static class Helper
    {
        public static bool IsEmail(this string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsEmail(this object value)
        {
            try
            {
                return value.ToString().IsEmail();
            }
            catch
            {
                return false;
            }
        }

        public static bool IsEmailList(this IEnumerable value)
        {
            try
            {
                var list = (IList<string>) value;
                return !list.Any() || list.All(x => x.IsEmail());
            }
            catch
            {
                return false;
            }
        }
    }
}