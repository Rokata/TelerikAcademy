using System;
using System.Text;

namespace PhonebookApp
{
    public static class PhonebookUtils
    {
        private const string BulgariaCode = "+359";

        public static string ConvertPhoneNumber(string phoneNumber)
        {
            StringBuilder convertedNumber = new StringBuilder();

            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    convertedNumber.Append(ch);
                }
            }

            if (convertedNumber.Length >= 2 && convertedNumber[0] == '0' && convertedNumber[1] == '0')
            {
                convertedNumber.Remove(0, 1);
                convertedNumber[0] = '+';
            }

            while (convertedNumber.Length > 0 && convertedNumber[0] == '0')
            {
                convertedNumber.Remove(0, 1);
            }

            if (convertedNumber.Length > 0 && convertedNumber[0] != '+')
            {
                convertedNumber.Insert(0, PhonebookUtils.BulgariaCode);
            }

            return convertedNumber.ToString();
        }
    }
}
