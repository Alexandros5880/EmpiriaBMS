using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Hellpers;

public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            // Generate a random salt
            byte[] salt;

            rng.GetBytes(salt = new byte[16]);

            // Create a hash using PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combine the salt and hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert the combined bytes to a string
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }
        
    }
}
