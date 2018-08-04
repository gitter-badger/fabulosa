namespace Fabulosa.Docs.Extensions

module List = 
    let flatMap list = List.collect (fun x -> x) list