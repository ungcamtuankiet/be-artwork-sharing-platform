using be_artwork_sharing_platform.Core.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

namespace be_artwork_sharing_platform.Core.Dtos.Auth
{
    public class CheckPassword
    {
        public static string HashPasswordBcrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


        public static string HashPasswordPBKDF2(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashedPassword}";
        }

        public static bool VerifyPassword(string hashedPassword, string passwordToCheck)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            // Kiểm tra xem mật khẩu có khớp với mật khẩu băm không
            var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, passwordToCheck);

            return result == PasswordVerificationResult.Success;
        }

        public static string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            // Băm mật khẩu
            string hashedPassword = passwordHasher.HashPassword(null, password);

            return hashedPassword;
        }
    }
}
