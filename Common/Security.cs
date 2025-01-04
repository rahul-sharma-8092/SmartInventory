using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Security
    {
        public static string BCryptEncryption(string password)
        {
            password = password.Trim();
            if (string.IsNullOrEmpty(password)) { return password; }

            string salt = BCrypt.Net.BCrypt.GenerateSalt(10, 'b');
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }

        public static bool BCryptVerify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
