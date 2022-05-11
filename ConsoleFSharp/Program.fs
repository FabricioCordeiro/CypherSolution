open System
open System.Text
open System.Security.Cryptography

let salt = Encoding.UTF8.GetBytes("6c4980a904cc2564ad7f02db67d99cb9") //32
let pureKey = Encoding.UTF8.GetBytes("a8ebfff7e54ebc78642cd671d142d18b") //32
let iv = Encoding.UTF8.GetBytes("qOv/9+VOvHhkLNZx") //16

let key = (new Rfc2898DeriveBytes(pureKey, salt, 1000, HashAlgorithmName.SHA256)).GetBytes(256 / 8)

printf " Digite um texto: "
let texto = Console.ReadLine()
Console.Clear()

printfn "------------------------------------------------------------------"
printfn ""

//Criptografado em C# e Descriptografado em VB.NET
let CsharpEncrypt = LibraryCsharp.Cipher.Encrypt(texto, key, iv).Result
let VBDecrypt = LibraryVisualBasic.Cipher.Decrypt(CsharpEncrypt, key, iv).Result

printfn " Criptografado em C# e Descriptografado em VB.NET"
printfn ""
printfn "%s%s" " Texto digitado: " texto
printfn ""
printfn "%s%s" " Texto cifrado: " (Encoding.UTF8.GetString(CsharpEncrypt))
printfn ""
printfn "%s%s" " Texto decifrado: " VBDecrypt
printfn ""

printfn "------------------------------------------------------------------"
printfn ""

let pause = Console.ReadKey()