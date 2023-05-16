using System.Security.Cryptography;

namespace SocialConnect.Services
{
    public interface IHashingService
    {
        public Task<byte[]> GenerateHash(string key, byte[] salt);
        public Task<byte[]> GenerateSalt();
    }
}
