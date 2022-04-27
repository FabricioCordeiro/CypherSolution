open System
open System.Text
open System.Security.Cryptography

let salt = Encoding.UTF8.GetBytes(")(!@&#)&!)@&$)!&@#)!*&@)*(#")
let pureKey = Encoding.UTF8.GetBytes("(!*@(#*@&!*@(#*@&!**@(#)@(#*@&##")
let iv = Encoding.UTF8.GetBytes("DasJ12H4$pPP0XC1");

let key = (new Rfc2898DeriveBytes(pureKey, salt, 1000)).GetBytes(256 / 8)

printf " Digite um texto: "
let texto = Console.ReadLine()
Console.Clear()

//C#
let CSharpEncrypt = LibraryCSharp.Cypher.Encrypt(texto, key, iv).Result
let CSharpDecrypt = LibraryCSharp.Cypher.Decrypt(CSharpEncrypt, key, iv).Result

printf ""
printfn "%s%s" " Texto digitado: " texto
printfn ""
printfn "%s%s" " Texto cifrado: " (Encoding.UTF8.GetString(CSharpEncrypt))
printfn ""
printfn "%s%s" " Texto decifrado: " CSharpDecrypt
printfn ""

let pause = Console.ReadKey()