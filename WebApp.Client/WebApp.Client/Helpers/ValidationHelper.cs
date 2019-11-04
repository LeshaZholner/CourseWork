using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WebApp.Client.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsEmailvalidation(string email)
        {
            if (email == null)
            {
                return false;
            }

            string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            return (Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
        }

        public static bool IsPasswordValidation(string password)
        {
            if (password == null)
            {
                return false;
            }

            string passwordRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
            return (Regex.IsMatch(password, passwordRegex));
        }

        public static bool IsCompareValidation(string strA, string strB)
        {
            if (strA == null || strB == null)
            {
                return false;
            }
            return strA == strB;
        }

        public static bool IsPhonenumberValidation(string phonenumber)
        {
            if (phonenumber == null)
            {
                return false;
            }

            string phonenumberRegex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            return (Regex.IsMatch(phonenumber, phonenumberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
        }

        public static bool IsRequiredValidation(string text)
        {
            if (text == null)
            {
                return false;
            }
            return text.Length != 0;
        }

        public static bool IsRegisterPageValidation(string email, string pass, string confPass, string phonenumber, string firstname, string lastname)
        {
            return IsEmailvalidation(email) & IsPasswordValidation(pass) & IsCompareValidation(pass, confPass) & IsPhonenumberValidation(phonenumber) & IsRequiredValidation(firstname) & IsRequiredValidation(lastname);
        }

    }
}
