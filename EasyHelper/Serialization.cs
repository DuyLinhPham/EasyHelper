using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EasyHelper
{
    /// <summary>
    /// It supports for working with object and xml file
    /// </summary>
    public sealed class Serialization
    {
        /// <summary>
        /// Get data from xml file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public static bool GetDataFromXmlFile<T>(string filePath, out T obj)
        {
            obj = default(T);
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    obj = (T)serializer.Deserialize(stream);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Save data to xaml file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <returns>bool</returns>
        public static bool SaveToXmlFile<T>(T obj, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, obj);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
