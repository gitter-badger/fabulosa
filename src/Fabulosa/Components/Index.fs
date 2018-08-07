namespace Fabulosa

//Expiment Only

module Index =

    open Fable.Import.React
    module R = Fable.Helpers.React

    let Fi (props : obj) = 
         match props with 
         | :? Button.Props as p -> Button.ƒ p
         | :? IconInput.Props as p -> IconInput.ƒ p
         | :? Icon.Props as p -> Icon.ƒ p
         | :? Input.Props as p -> Input.ƒ p
         | _ -> R.span [] []
         
    let ƒ = Fi
    
    let button = Button.button
    let iconInput = IconInput.defaults
    let icon = Icon.defaults
    let input = Input.defaults
      