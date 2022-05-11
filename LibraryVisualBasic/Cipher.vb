Imports System.Security.Cryptography
Imports System.IO
Imports LibraryCsharp

Public Class Cipher
    Public Shared Async Function Decrypt(cipherText As Byte(), key As Byte(), iv As Byte()) As Task(Of String)

        Dim aesObj = Aes.Create()
        aesObj.Key = key
        aesObj.IV = iv

        ' Criação de um criptografador para realizar a transformação de fluxo.
        Dim decryptor = aesObj.CreateDecryptor()

        ' Criação dos streams usados ​​para a descriptografia
        Using memoryStreamObj As New MemoryStream(cipherText)
            Using cryptoStream As New CryptoStream(memoryStreamObj, decryptor, CryptoStreamMode.Read)
                Using streamReaderObj As New StreamReader(cryptoStream)
                    'retorno dos bytes descriptografados do fluxo dse descriptografia.
                    Return Await streamReaderObj.ReadToEndAsync()
                End Using
            End Using
        End Using

    End Function
End Class