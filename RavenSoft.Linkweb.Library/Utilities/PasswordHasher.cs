using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Library.Utilities
{
    public static class PasswordHasher
    {
        private static MD5 _md5;

        public static string HashPassword(string desiredPassword)
        {
            using (_md5 = MD5.Create())
            {
                byte[] data = _md5.ComputeHash(Encoding.UTF8.GetBytes(desiredPassword));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static bool IsPasswordSame(string inputtedPassword, string hashedPassword)
        {
            StringComparer sc = StringComparer.CurrentCulture;
            string hashedInputPassword = HashPassword(inputtedPassword);

            return sc.Compare(hashedPassword, hashedInputPassword) == 0;
        }
    }
}
