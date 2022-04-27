Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class Cypher
    Public Shared Function Saida(cipherText As String)
        Dim CipherTextBytes = Convert.FromBase64String(cipherText)

        Dim Key = "3c75dd500c740df4a2e81f1e8dbc418f9eaf183d1b3714a1bf11bbd7c69c1e6f2a29fe76607d49b12096ef54a14c4cbaad3fc39ae2ec108d5a3777e6d5c2265f"
        Dim InitialVectorBytes = Encoding.UTF8.GetBytes("OFRna73m*aze01xY")
        Dim SaltBytes = Encoding.UTF8.GetBytes("43a7c01223db11653ce15c035cf05a454053be9669ce32f4af5aeee1f113058eb29dc816cbab67540d4da0566b495a71fa3cc932ef6c5d1f27dc7a4f165dcf2c")

        Dim DerivedKey As New PasswordDeriveBytes(Key, SaltBytes, "SHA256", 1)
        Dim KeyBytes = DerivedKey.GetBytes(32)
        Dim SymmetricKey = Aes.Create()

        Dim PlainTextBytes(CipherTextBytes.Length) As Byte

        Dim Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes)

        Dim MemStream As New MemoryStream(CipherTextBytes)
        Dim CryptoStream As New CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read)

        Dim ByteCount
        ByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length)

        MemStream.Close()
        CryptoStream.Close()
        SymmetricKey.Clear()

        Return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount)
    End Function
End Class