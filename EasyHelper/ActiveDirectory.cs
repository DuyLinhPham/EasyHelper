using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows
using System.Windows.Media.Imaging;

namespace EasyHelper
{
    /// <summary>
    /// It supports for working with Active Directory
    /// </summary>
    public sealed class ActiveDirectory
    {
        /// <summary>
        /// Get Current Account Name
        /// </summary>
        /// <returns>string</returns>
        public static string GetCurrentAccountName()
        {
            return Environment.UserName;
        }

        /// <summary>
        /// Get Display Name
        /// </summary>
        /// <returns>string</returns>
        public static string GetDisplayName()
        {
            try
            {
                string accountName;
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + Environment.UserDomainName);
                DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
                directorySearcher.Filter = string.Format("(&(SAMAccountName={0}))", Environment.UserName);
                SearchResult user = directorySearcher.FindOne();

                if (user.Properties.Contains("displayName"))
                {
                    accountName = user.Properties["displayName"][0].ToString();
                }
                else
                {
                    if (user.Properties.Contains("givenName"))
                    {
                        accountName = user.Properties["givenName"][0].ToString();
                    }
                    else
                    {
                        accountName = Environment.UserName;
                    }
                }

                return accountName;
            }
            catch (Exception)
            {
                return Environment.UserName;
            }
        }

        /// <summary>
        /// Get Fisrt Character of Account Name
        /// </summary>
        /// <returns>string</returns>
        public static string GetAccountInitials()
        {
            try
            {
                string firstName;
                string lastName = string.Empty;
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + Environment.UserDomainName);
                DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
                {
                    Filter = string.Format("(&(SAMAccountName={0}))", Environment.UserName)
                };
                SearchResult user = directorySearcher.FindOne();

                if (user.Properties.Contains("givenName"))
                {
                    firstName = user.Properties["givenName"][0].ToString().Substring(0, 1);
                }
                else
                {
                    firstName = Environment.UserName.Substring(0, 1);
                }
                if (user.Properties.Contains("sn"))
                {
                    lastName = string.Format("{0}", user.Properties["sn"][0]).Substring(0, 1);
                }
                string initialName = firstName + lastName;
                return initialName;
            }
            catch (Exception)
            {
                return Environment.UserName.Substring(0, 1);
            }
        }

        /// <summary>
        /// Get display image
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>BitmapImage</returns>
        public static BitmapImage GetAccountPhoto(string userName)
        {
            try
            {
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + Environment.UserDomainName);
                DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
                {
                    Filter = string.Format("(&(SAMAccountName={0}))", userName)
                };
                SearchResult user = directorySearcher.FindOne();

                if (user.Properties.Contains("thumbnailPhoto"))
                {
                    using (MemoryStream ms = new MemoryStream((byte[])user.Properties["thumbnailPhoto"][0]))
                    {
                        BitmapImage imageSource = new BitmapImage();
                        imageSource.BeginInit();
                        imageSource.StreamSource = ms;
                        imageSource.EndInit();

                        return imageSource;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get display name of an account
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>string</returns>
        public static string GetDisplayNameNameByUserName(string userName)
        {
            try
            {
                string accountName;
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + Environment.UserDomainName);
                DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
                {
                    Filter = string.Format("(&(SAMAccountName={0}))", userName)
                };
                SearchResult user = directorySearcher.FindOne();

                if (user.Properties.Contains("displayName"))
                {
                    accountName = user.Properties["displayName"][0].ToString();
                }
                else
                {
                    if (user.Properties.Contains("givenName"))
                    {
                        accountName = user.Properties["givenName"][0].ToString();
                    }
                    else
                    {
                        accountName = userName;
                    }
                }

                return accountName;
            }
            catch (Exception)
            {
                return userName;

            }
        }
    }
}
