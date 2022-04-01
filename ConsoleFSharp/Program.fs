open System
open LibraryCSharp
open LibraryVisualBasic

printf " Digite um texto: "
let texto = Console.ReadLine()
Console.Clear()

let CSharpEncrypt = Encrypt.Entrada(texto)
let VisualBasicDecrypt = Decrypt.Saida(CSharpEncrypt).ToString()

printfn "%s%s" " Texto obtido com F#: " texto
printfn ""
printfn "%s%s" " Texto cifrado com C#: " CSharpEncrypt
printfn ""
printfn "%s%s" " Texto decifrado com VB.NET: " VisualBasicDecrypt
printfn ""

let pause = Console.ReadKey()