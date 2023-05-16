using SocialConnect.Services.Dtos;
using System.Security.Cryptography;

namespace SocialConnect.Services
{
    public class Sha1HashingService : IHashingService
    {
        public  async Task<byte[]> GenerateHash(string key, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(key, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            return hash;
        }

        public async Task<byte[]> GenerateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            return salt;
        }
    }
}
