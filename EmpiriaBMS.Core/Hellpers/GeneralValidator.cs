using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Hellpers;

public static class GeneralValidator
{
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        return Regex.IsMatch(email, pattern);
    }

    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber)) return false;
        string pattern = @"^\+?[0-9\s-()]{7,}$";
        return Regex.IsMatch(phoneNumber, pattern);
    }

    public static bool IsValidWebsite(string website)
    {
        if (string.IsNullOrEmpty(website)) return false;
        string pattern = @"^(https?://)?(www\.)?[a-zA-Z0-9-]+(\.[a-zA-Z]{2,})(/\S*)?$";
        return Regex.IsMatch(website, pattern);
    }

    public static bool IsValidAFM(string afm)
    {
        if (string.IsNullOrEmpty(afm)) return false;
        string pattern = @"^\d{9}$";
        return Regex.IsMatch(afm, pattern);
    }

    public static bool IsValidAMKA(string amka) => AMKAValidator.IsValidAMKA(amka);
    protected static class AMKAValidator
    {
        public static bool IsValidAMKA(string amka)
        {
            if (string.IsNullOrEmpty(amka)) return false;
            string pattern = @"^\d{11}$";
            return Regex.IsMatch(amka, pattern) && IsValidAMKACheckDigit(amka);
        }

        private static bool IsValidAMKACheckDigit(string amka)
        {
            int[] weights = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 };
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += (amka[i] - '0') * weights[i];
            }

            int remainder = sum % 11;
            int checkDigit = remainder == 10 ? 0 : remainder;

            return (amka[10] - '0') == checkDigit;
        }
    }


}
