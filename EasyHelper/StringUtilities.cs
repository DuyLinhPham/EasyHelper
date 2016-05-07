using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyHelper
{
    /// <summary>
    /// It supports for working with string when coding
    /// </summary>
    public sealed class StringUtilities
    {
        /// <summary>
        /// Remove html tag in string
        /// </summary>
        /// <param name="value"></param>
        /// <returns>string</returns>
        public static string RemoveHtml(string value)
        {
            try
            {
                return Regex.Replace(value, @"<[^>]*>|&nbsp;", string.Empty);
            }
            catch
            {
                return value;
            }
        }

        /// <summary>
        /// Get the first character every word in string
        /// Ex: Linh Pham =>LP
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetFirstCharacters(string value)
        {
            string firstCharacters = string.Empty;
            if (string.IsNullOrWhiteSpace(value))
            {
                return firstCharacters;
            }   
                     
            string[] stringArray = value.Split(' ');
            firstCharacters = stringArray.Aggregate(firstCharacters, (current, item) => current + item[0]);

            return firstCharacters;
        }

        /// <summary>
        /// Get first character in string
        /// Ex: Linh => L
        /// </summary>
        /// <param name="value"></param>
        /// <returns>string</returns>
        public static string GetFirstCharacter(string value)
        {
            string firstCharacter = string.Empty;
            if (string.IsNullOrWhiteSpace(value))
            {
                return firstCharacter;
            }

            return value[0].ToString();
        }

        /// <summary>
        /// Get some first words string string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static string GetWords(string value, int limit)
        {
            string words = string.Empty;

            if (value != null)
            {
                string[] stringArray = value.Split(' ');

                if (limit > stringArray.Length)
                    throw new Exception("limit can not bigger amout word in string");

                if (limit == 0 || limit == stringArray.Length)
                    return value;

                for (int i = 0; i < limit; i++)
                {
                    words += stringArray[i] + " ";
                }

                return words.Remove(words.Length - 1);
            }
            return words;
        }

        /// <summary>
        /// Find word in string
        /// return startIndex,endIndex if the word exists in string otherwise it returns to -1
        /// Example: value is "Linh Pham", wordToFind is "Linh" => 0,3
        /// </summary>
        /// <param name="value"></param>
        /// <param name="wordToFind"></param>
        /// <returns>startIndex,endIndex / -1</returns>
        public static string FindWord(string value, string wordToFind)
        {
            if (value == null)
            {
                throw new Exception("Value cannot null");
            }
            if (wordToFind == null)
            {
                throw new Exception("Word to find cannot null");
            }

            int startIndex = value.IndexOf(wordToFind, StringComparison.Ordinal);

            if (startIndex >= 0)
            {
                return startIndex + "," + (wordToFind.Length - 1);
            }

            return "-1";
        }
    }
}
