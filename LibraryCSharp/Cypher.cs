using System.Security.Cryptography;

namespace LibraryCSharp;

public static class Cypher
{
    public static async Task<byte[]> Encrypt(string texto, byte[] chave, byte[] vetor)
    {
        // Checagem de argumentos.
        if (string.IsNullOrEmpty(texto))
            throw new ArgumentNullException(nameof(texto));
        if (chave == null || chave.Length <= 0)
            throw new ArgumentNullException(nameof(chave));
        if (vetor == null || vetor.Length <= 0)
            throw new ArgumentNullException(nameof(vetor));

        // Criação do objeto AES.
        using Aes aes = Aes.Create();

        // Criação de um criptografador para realizar a transformação de fluxo.
        ICryptoTransform encryptor = aes.CreateEncryptor(chave, vetor);

        // Criação dos fluxos usados ​​para a criptografia.
        using MemoryStream memoryStream = new();

        using CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write);
        using (StreamWriter streamWriter = new(cryptoStream))
        {
            //Gravação de todos os dados no stream.
            await streamWriter.WriteAsync(texto);
        }

        // Retorno dos bytes criptografados do fluxo de memória.
        return memoryStream.ToArray();
    }

    public static async Task<string> Decrypt(byte[] cipherText, byte[] chave, byte[] vetor)
    {
        // Checagem de argumentos.
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException(nameof(cipherText));
        if (chave == null || chave.Length <= 0)
            throw new ArgumentNullException(nameof(chave));
        if (vetor == null || vetor.Length <= 0)
            throw new ArgumentNullException(nameof(vetor));

        // Criação do objeto AES.
        using Aes aesAlg = Aes.Create();

        // Criação dos fluxos usados ​​para a descriptografia.
        ICryptoTransform decryptor = aesAlg.CreateDecryptor(chave, vetor);

        // Create the streams used for decryption.
        using MemoryStream memoryStream = new(cipherText);

        using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
        using StreamReader streamReader = new(cryptoStream);

        //retorno dos bytes descriptografados do fluxo de descriptografia.
        return await streamReader.ReadToEndAsync();
    }
}
