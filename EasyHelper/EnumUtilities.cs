using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHelper
{
    /// <summary>
    /// It supports for getting value, description from enum type
    /// </summary>
    public sealed class EnumUtilities
    {
        /// <summary>
        /// Get enum value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IEnumerable</returns>
        public static IEnumerable<T> GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// Get enum description
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns>string</returns>
        public static string GetEnumDescription<T>(Enum value)
        {
            Type type = typeof(T);
            string name = Enum.GetNames(type)
                           .Where(f => f.Equals(value.ToString(), StringComparison.CurrentCultureIgnoreCase))
                           .Select(d => d).FirstOrDefault();

            if (name == null)
            {
                return string.Empty;
            }

            var field = type.GetField(name);
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
        }
    }
}
