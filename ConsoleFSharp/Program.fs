open System
open System.Text
open System.Security.Cryptography

let salt = Encoding.UTF8.GetBytes("6c4980a904cc2564ad7f02db67d99cb9")
let pureKey = Encoding.UTF8.GetBytes("a8ebfff7e54ebc78642cd671d142d18b")
let iv = Encoding.UTF8.GetBytes("qOv/9+VOvHhkLNZx")

let key = (new Rfc2898DeriveBytes(pureKey, salt, 1000)).GetBytes(256 / 8)

printf " Digite um texto: "
let texto = Console.ReadLine()
Console.Clear()

printfn "------------------------------------------------------------------"
printfn ""

//C#
let CSharpEncrypt = LibraryCsharp.Cypher.Encrypt(texto, key, iv).Result
let CSharpDecrypt = LibraryCsharp.Cypher.Decrypt(CSharpEncrypt, key, iv).Result

printfn " Com CSHARP"
printfn ""
printfn "%s%s" " Texto digitado: " texto
printfn ""
printfn "%s%s" " Texto cifrado: " (Encoding.UTF8.GetString(CSharpEncrypt))
printfn ""
printfn "%s%s" " Texto decifrado: " CSharpDecrypt
printfn ""

printfn "------------------------------------------------------------------"
printfn ""

//VB.NET
let VBEncrypt = LibraryVisualBasic.Cypher.Encrypt(texto, key, iv).Result
let VBDecrypt = LibraryVisualBasic.Cypher.Decrypt(VBEncrypt, key, iv).Result

printfn " Com VB.NET"
printfn ""
printfn "%s%s" " Texto digitado: " texto
printfn ""
printfn "%s%s" " Texto cifrado: " (Encoding.UTF8.GetString(VBEncrypt))
printfn ""
printfn "%s%s" " Texto decifrado: " VBDecrypt
printfn ""

printfn "------------------------------------------------------------------"
printfn ""

//Criptografado em C# e Descriptografado em VB.NET
let CsharpEncryptToVB = LibraryCsharp.Cypher.Encrypt(texto, key, iv).Result
let VBDecryptCsharp = LibraryVisualBasic.Cypher.Decrypt(CsharpEncryptToVB, key, iv).Result

printfn " Criptografado em C# e Descriptografado em VB.NET"
printfn ""
printfn "%s%s" " Texto digitado: " texto
printfn ""
printfn "%s%s" " Texto cifrado: " (Encoding.UTF8.GetString(CsharpEncryptToVB))
printfn ""
printfn "%s%s" " Texto decifrado: " VBDecryptCsharp
printfn ""

printfn "------------------------------------------------------------------"
printfn ""

//Criptografado em VB.NET e Descriptografado em C#
let VBEncryptToCsharp = LibraryVisualBasic.Cypher.Encrypt(texto, key, iv).Result
let CsharpDecryptVb = LibraryCsharp.Cypher.Decrypt(VBEncryptToCsharp, key, iv).Result

printfn " Criptografado em VB.NET e Descriptografado em C#"
printfn ""
printfn "%s%s" " Texto digitado: " texto
printfn ""
printfn "%s%s" " Texto cifrado: " (Encoding.UTF8.GetString(VBEncryptToCsharp))
printfn ""
printfn "%s%s" " Texto decifrado: " CsharpDecryptVb
printfn ""

printfn "------------------------------------------------------------------"
printfn ""

let pause = Console.ReadKey()