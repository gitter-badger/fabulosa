namespace Fabulosa

module Index =

    open Fable.Import.React
    module R = Fable.Helpers.React


    let Fi (props : obj) c = 
         match props with 
         | :? Button.Props as p -> Button.ƒ p c
         | :? Pacoquinha.Props as p -> R.span [] c
         | _ -> R.span [] c
         
    let ƒ = Fi
    
    let button = Button.defaults
    
    let pacoquinha = Pacoquinha.defaults
         
    let ø = R.div [] [R.str "hey yo"] 