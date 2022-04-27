using System.Security.Cryptography;
using LibraryVisualBasic;

namespace LibraryCsharp;

public static class Cypher
{
    public static async Task<byte[]> Encrypt(string texto, byte[] chave, byte[] vetor)
    {
        // Checagem de argumentos.
        if (string.IsNullOrEmpty(texto))
            throw new ArgumentNullException(nameof(texto));
        if (string.IsNullOrEmpty(chave.ToString()))
            throw new ArgumentNullException(nameof(chave));
        if (string.IsNullOrEmpty(vetor.ToString()))
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
        if (string.IsNullOrEmpty(cipherText.ToString()))
            throw new ArgumentNullException(nameof(cipherText));
        if (string.IsNullOrEmpty(chave.ToString()))
            throw new ArgumentNullException(nameof(chave));
        if (string.IsNullOrEmpty(vetor.ToString()))
            throw new ArgumentNullException(nameof(vetor));

        // Criação do objeto AES.
        using Aes aesAlg = Aes.Create();

        // Criação de um criptografador para realizar a transformação de fluxo.
        ICryptoTransform decryptor = aesAlg.CreateDecryptor(chave, vetor);

        // Criação dos streams usados ​​para a descriptografia
        using MemoryStream memoryStream = new(cipherText);
        using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
        using StreamReader streamReader = new(cryptoStream);

        //retorno dos bytes descriptografados do fluxo de descriptografia.
        return await streamReader.ReadToEndAsync();
    }
}
