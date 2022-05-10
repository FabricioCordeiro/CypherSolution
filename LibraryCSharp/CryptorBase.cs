using System.Security.Cryptography;
using System.Text;

namespace LibraryCsharp
{
    public sealed class CryptorBase
    {
        private byte[] Salt { get; init; } = Encoding.UTF8.GetBytes("6c4980a904cc2564ad7f02db67d99cb9"); // 32
        private byte[] ChaveLimpa { get; init; } = Encoding.UTF8.GetBytes("a8ebfff7e54ebc78642cd671d142d18b"); // 32
        private byte[] VI { get; init; } = Encoding.UTF8.GetBytes("qOv/9+VOvHhkLNZx"); // 16
        public Aes Aes { get; init; }

        public CryptorBase(bool fixedKey)
        {
            if (fixedKey == true)
            {
                byte[] key = new Rfc2898DeriveBytes(ChaveLimpa, Salt, 1000, HashAlgorithmName.SHA256).GetBytes(256 / 8);

                using Aes aesAlg = Aes.Create();
                aesAlg.Key = key;
                aesAlg.IV = VI;

                Aes = aesAlg;
            }
            else
            {
                using Aes aesAlg = Aes.Create();
                Aes = aesAlg;
            }
        }
    }
}
