using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace slnMumu_MidtermProject.Services
{
    public class Authenticator
    {
        public static byte[] GetSaltBytes(string saltString)
        {
            return Encoding.UTF8.GetBytes(saltString);
        }

        public static string HashPasswordWithSalt(string password, string saltString)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] saltBytes = GetSaltBytes(saltString);

                byte[] saltedPassword = Encoding.UTF8.GetBytes(password).Concat(saltBytes).ToArray();

                byte[] hash = sha256.ComputeHash(saltedPassword);

                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string saltString)
        {

            string hashOfEnteredPassword = HashPasswordWithSalt(enteredPassword, saltString);

            return hashOfEnteredPassword == storedHash;
        }
    }
}
