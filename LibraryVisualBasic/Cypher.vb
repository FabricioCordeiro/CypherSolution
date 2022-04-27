Imports System.Security.Cryptography
Imports System.IO

Public Class Cypher
    Public Shared Async Function Encrypt(texto As String, chave As Byte(), vetor As Byte()) As Task(Of Byte())

        ' Checagem de argumentos.
        If (String.IsNullOrEmpty(texto)) Then
            Throw New ArgumentNullException(NameOf(texto))
        End If
        If (String.IsNullOrEmpty(chave.ToString())) Then
            Throw New ArgumentNullException(NameOf(texto))
        End If
        If (String.IsNullOrEmpty(vetor.ToString())) Then
            Throw New ArgumentNullException(NameOf(texto))
        End If

        ' Criação do objeto AES.
        Dim aesObj = Aes.Create()

        ' Criação de um criptografador para realizar a transformação de fluxo.
        Dim encryptor = aesObj.CreateEncryptor(chave, vetor)

        ' Criação dos fluxos usados ​​para a criptografia.
        Using memoryStreamObj As New MemoryStream

            Using cryptoStream As New CryptoStream(memoryStreamObj, encryptor, CryptoStreamMode.Write)
                Using streamWriterObj As New StreamWriter(cryptoStream)

                    ' Gravação de todos os dados no stream.
                    streamWriterObj.Write(texto)

                End Using
            End Using

            ' Retorno dos bytes criptografados do fluxo de memória.
            Return memoryStreamObj.ToArray()

        End Using
    End Function

    Public Shared Async Function Decrypt(texto As String, chave As Byte(), vetor As Byte()) As Task(Of String)

        ' Checagem de argumentos.
        If (String.IsNullOrEmpty(texto)) Then
            Throw New ArgumentNullException(NameOf(texto))
        End If
        If (String.IsNullOrEmpty(chave.ToString())) Then
            Throw New ArgumentNullException(NameOf(texto))
        End If
        If (String.IsNullOrEmpty(vetor.ToString())) Then
            Throw New ArgumentNullException(NameOf(texto))
        End If

        ' Criação do objeto AES.
        Dim aesObj = Aes.Create()

        ' Criação de um criptografador para realizar a transformação de fluxo.
        Dim encryptor = aesObj.CreateEncryptor(chave, vetor)

        ' Create the streams used for decryption.
        Using memoryStreamObj As New MemoryStream
            Using cryptoStreamObj As New CryptoStream(memoryStreamObj, encryptor, CryptoStreamMode.Read)
                Using streamReaderObj As New StreamReader(cryptoStreamObj)

                    'retorno dos bytes descriptografados do fluxo de descriptografia.
                    Return Await streamReaderObj.ReadToEndAsync()

                End Using
            End Using
        End Using

    End Function
End Class