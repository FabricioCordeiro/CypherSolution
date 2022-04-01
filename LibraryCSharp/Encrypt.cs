using System.Security.Cryptography;
using System.Text;

namespace LibraryCSharp
{
    public static class Encrypt
    {
        public static string Entrada(string texto)
        {
            byte[] PlainTextBytes = Encoding.UTF8.GetBytes(texto);
            const string Key = "3c75dd500c740df4a2e81f1e8dbc418f9eaf183d1b3714a1bf11bbd7c69c1e6f2a29fe76607d49b12096ef54a14c4cbaad3fc39ae2ec108d5a3777e6d5c2265f";

            byte[] InitialVectorBytes = Encoding.UTF8.GetBytes("OFRna73m*aze01xY");

            byte[] SaltBytes = Encoding.UTF8.GetBytes("43a7c01223db11653ce15c035cf05a454053be9669ce32f4af5aeee1f113058eb29dc816cbab67540d4da0566b495a71fa3cc932ef6c5d1f27dc7a4f165dcf2c");

            PasswordDeriveBytes DerivedKey = new(Key, SaltBytes, "SHA256", 1);
            byte[] KeyBytes = DerivedKey.GetBytes(32);

            Aes SymmetricKey = Aes.Create();

            byte[] CipherTextBytes = null;

            using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes))
            {
                using MemoryStream MemStream = new();
                using CryptoStream CryptoStream = new(MemStream, Encryptor, CryptoStreamMode.Write);

                CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
                CryptoStream.FlushFinalBlock();
                CipherTextBytes = MemStream.ToArray();

                MemStream.Close();
                CryptoStream.Close();
            }

            SymmetricKey.Clear();
            return Convert.ToBase64String(CipherTextBytes);
        }
    }
}