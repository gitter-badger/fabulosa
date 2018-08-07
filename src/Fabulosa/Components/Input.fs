namespace Fabulosa

[<RequireQualifiedAccess>]
module Input =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    type Size =
    | Small
    | Large
    | Unset

    type Props = {
        HTMLProps: IHTMLProp list
        Size: Size
    }

    let defaults = {
        HTMLProps = []
        Size = Size.Unset
    }

    let size =
        function
        | Size.Small -> "input-sm"
        | Size.Large -> "input-lg"
        | Size.Unset -> ""

    let ƒ props =
        let containerProps =
            props.HTMLProps
            |> combineProps ["form-input";
                size props.Size]
        R.input containerProps

    let input = ƒ

[<RequireQualifiedAccess>]
module IconInput =

    open ClassNames
    open ReactAPIExtensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Position =
    | Left
    | Right

    type Props = {
        IconLeft: Icon.Props option
        Input: Input.Props
        Position: Position
    }

    let defaults input = {
        IconLeft = None
        Input = input
        Position = Position.Left
    }

    let position =
        function
        | Position.Left -> "has-icon-left"
        | Position.Right -> "has-icon-right"

    let icon =
        function
        | _ -> "form-icon"

    //let makeIcon =
        //transform (fun _ -> "form-icon") [""]

    let iconInput props htmlProps (children: ReactElement list) =
        let t = extractProps <| R.div [] [R.p [] []]
        Fable.Import.Browser.console.log t
        R.div [] [
            children.[0]
            children.[1]
        ]
   
    let iconLeftClass = 
        function
        | Some s -> "has-icon-left"
        | None -> ""
    
    let iconLeft =
        function 
        | Some e -> Icon.ƒ { e with HTMLProps = [ClassName "form-icon"]}
        | None -> null
    
    let ƒ (props : Props) = 
        
        R.div [ClassName (iconLeftClass props.IconLeft)] [
            Input.ƒ props.Input
            (iconLeft props.IconLeft)
        ]
        
//<div class="has-icon-left">
//  <input type="text" class="form-input" placeholder="...">
//  <i class="form-icon icon icon-check"></i>
//</div>

