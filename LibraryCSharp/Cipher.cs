using System.Security.Cryptography;
using System.Text;

namespace LibraryCsharp;

public static class Cipher
{
    public static async Task<byte[]> Encrypt(string texto, byte[] key, byte[] iv)
    {
        var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        // Criação de um criptografador para realizar a transformação de fluxo.
        var encryptor = aes.CreateEncryptor();

        // Criação dos fluxos usados ​​para a criptografia.
        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        using (var streamWriter = new StreamWriter(cryptoStream))
        {
            //Gravação de todos os dados no stream.
            await streamWriter.WriteAsync(texto);
        }

        // Retorno dos bytes criptografados do fluxo de memória.
        return memoryStream.ToArray();
    }
}
