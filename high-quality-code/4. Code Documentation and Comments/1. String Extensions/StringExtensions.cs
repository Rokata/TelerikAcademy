namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Method to return the bool value equivalent to a string.
        /// </summary> 
        /// <param name="input">The string on which the method is called.</param>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <returns>
        /// Returns true if the string is among the array with
        /// meaningful values and false if it isn't.
        /// </returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Method to return the short value equivalent to a string.
        /// </summary> 
        /// <param name="input">The string on which the method is called.</param>
        /// <returns>
        /// Returns a short number if the conversion is successful or
        /// the default short value otherwise.
        /// </returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Method to return the integer value equivalent to a string.
        /// </summary> 
        /// <param name="input">The string on which the method is called.</param>
        /// <returns>
        /// Returns an integer number if the conversion is successful or
        /// the default integer value otherwise.
        /// </returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Method to return the long value equivalent to a string.
        /// </summary> 
        /// <param name="input">The string on which the method is called.</param>
        /// <returns>
        /// Returns a long number if the conversion is successful or
        /// the default long value otherwise.
        /// </returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>Method to return the DateTime value equivalent to a string.</summary> 
        /// <param name="input">The string on which the method is called.</param>
        /// <returns>
        /// Returns DateTime struct if the conversion is successful or
        /// 1/1/0001 date otherwise.
        /// </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Method to return a new string with capitiled first letter
        /// based on the string on which it is called.
        /// </summary> 
        /// <param name="input">The string on which the method is called.</param>
        /// <returns>
        /// Returns a new string based on the original with the first letter capitalized
        /// or empty string if the input is an empty string or is null value.
        /// </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        ///  A method to return a substring which is between certain start and end string from given
        ///  starting index.
        /// </summary>
        /// <param name="input">The string on which the method is called.</param>
        /// <param name="startString">
        /// The string after which the searched substring will start.
        /// </param>
        /// <param name="endString">
        /// The string before which the searched substring will end.
        /// </param>
        /// <param name="startFrom">Optional parameter indicating the index from which to start search.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// System.ArgumentOutOfRangeException exception will be thrown
        /// if startFrom parameter is smaller than 0 or bigger than the length of the string
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// System.ArgumentNullException exception will be thrown if one of the parameters is null.
        /// </exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <returns>Returns the substring meeting the criteria or empty string otherwise.</returns>
        /// <remarks>
        /// The string on which the method is called must contain both startString and endString params
        /// to produce proper result.
        /// </remarks>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString)) /* If the input doesn't contain either of the two strings
                                                                             * an empty string will be returned. */
            {
                return string.Empty;
            }

            /* This line calculates what is the index of the beginning of the substring we seek for. 
             * It's right after the startString param if the latter is valid. */
            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;

            if (startPosition == -1)
            {
                return string.Empty;
            }

            /* The end position is calculated analogically except that the ending index of the searched 
             * substring is before the start index of the endString param.
             * */
            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// A method to convert a string containing Bulgarian letters into a string 
        /// containing English letters with the same meaning.
        /// </summary>
        /// <param name="input">The string on which the method is called.</param>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <returns>Returns a new string based on English letters.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
             
                                                             };

            // This piece of code replaces all occurences of Bulgarian letters with their 
            // English equivalents.
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// A method to convert a string of English letters into a string 
        /// containing Bulgarian letters with the same meaning.
        /// </summary>
        /// <param name="input">The string on which the method is called.</param>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <returns>Returns a new string based on Bulgarian letters.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            // This piece of code replaces all occurences of English letters with their 
            // Bulgarian equivalents.
            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// The method validates a string representing username by removing 
        /// unnecessary letters from it.
        /// </summary>
        /// <param name="input">The username string on which the method is called.</param>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <returns>Returns a new string with valid chars only.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();

            // The replace method removes all chars which are not English letters, numbers, underscore or a dot.
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// The method creates a valid filename string.
        /// </summary>
        /// <param name="input">The filename string on which the method is called.</param>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <returns>Returns a new valid filename.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();

            // The replace method removes all chars which are not English letters, numbers, underscore, dot
            // or hyphen.
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets the first N characters of a string where N is a parameter.
        /// </summary>
        /// <param name="input">The string on which the method is called.</param>
        /// <param name="charsCount">The number of letters to grab.</param>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <returns>Returns the beginning of the string with the specified length.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets the specified file's extension.
        /// </summary>
        /// <param name="input">The string representing filename on which the method is called.</param>
        /// <returns>
        /// Returns the file extension or empty string if the param is not a 
        /// valid filename.
        /// </returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);

            // If the fileName param is valid then the fileParts array will contain 
            // at least the name and the extension of the file.
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Gets the content type of certain file extension.
        /// </summary>
        /// <param name="fileExtension">
        /// The string representing the extension on which
        /// the method is called.
        /// </param>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <returns>Returns the corresponding content type as string.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
            
                                                 };

            // If the extension is in the dictionary the corresponding value is returned. 
            // Otherwise the default content type is returned.
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// The method returns a string as array of bytes.
        /// </summary>
        /// <param name="input">The string on which the method is called.</param>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <returns>The resulting bytes array is returned.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
