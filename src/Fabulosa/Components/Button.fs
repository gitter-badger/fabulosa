namespace Fabulosa

[<RequireQualifiedAccess>]
module Button =

    open ClassNames
    open Fable.Import.React
    module R = Fable.Helpers.React
    open Fable.PowerPack.Keyboard
    open Fable.PowerPack.Keyboard
    open R.Props

    [<RequireQualifiedAccess>]
    type Kind =
    | Default
    | Primary
    | Link
    | Unset

    [<RequireQualifiedAccess>]
    type Color =
    | Success
    | Error
    | Unset

    [<RequireQualifiedAccess>]
    type Size =
    | Small
    | Large
    | Unset

    [<RequireQualifiedAccess>]
    type State =
    | Disabled
    | Active
    | Loading
    | Unset

    [<RequireQualifiedAccess>]
    type Format =
    | SquaredAction
    | RoundAction
    | Unset

    [<RequireQualifiedAccess>]
    type Props = {
        Kind: Kind
        Color: Color
        Size: Size
        State: State
        Format: Format
        Children: ReactElement list
        HTMLProps: IHTMLProp list
    }

    let kind =
        function
        | Kind.Default -> "btn-default"
        | Kind.Primary -> "btn-primary"
        | Kind.Link -> "btn-link"
        | Kind.Unset -> ""

    let color =
        function
        | Color.Success -> "btn-success"
        | Color.Error -> "btn-error"
        | Color.Unset -> ""

    let size =
        function
        | Size.Small -> "btn-sm"
        | Size.Large -> "btn-lg"
        | Size.Unset -> ""

    let state =
        function
        | State.Disabled -> "disabled"
        | State.Loading -> "loading"
        | State.Active -> "active"
        | State.Unset -> ""

    let format =
        function
        | Format.SquaredAction -> "btn-action"
        | Format.RoundAction -> "btn-action circle"
        | Format.Unset -> ""

    let button children = {
        Props.Kind = Kind.Unset
        Props.Color = Color.Unset
        Props.Size = Size.Unset
        Props.State = State.Unset
        Props.Format = Format.Unset
        Props.Children = children
        Props.HTMLProps = []
    }
    
//    let buttonText text = button [R.str text]

    let ƒ (props: Props) =
        let buttonProps = [ "btn";
            kind props.Kind;
            color props.Color;
            size props.Size;
            state props.State;
            format props.Format ]
        combineProps buttonProps props.HTMLProps
        R.button
            (combineProps buttonProps props.HTMLProps)
            props.Children
    
    let render = ƒ

[<RequireQualifiedAccess>]
module Pacoquinha =
    open ClassNames
    module R = Fable.Helpers.React
    open R.Props
    
    type Sabor =
    | Doce
    | Salgada
    
    type Props = {
        Sabor: Sabor
    }
        
    let defaults = {
        Sabor = Sabor.Doce
    }


    let pacoquinha (props: Props) = R.span []

[<RequireQualifiedAccess>]
module Anchor =

    open ClassNames
    module R = Fable.Helpers.React
    open Fable.Import.React
    open R.Props

    type Props = {
        props: Button.Props list
        HTMLProps: IHTMLProp list
    }

    let defaults = Button.button

    let ƒ (props: Button.Props) : ReactElement = 
        let combinedProps =  
            combineProps [
                "btn";
                Button.kind props.Kind;
                Button.color props.Color;
                Button.size props.Size;
                Button.state props.State;
                Button.format props.Format 
            ]    
            props.HTMLProps
        R.a combinedProps props.Children
    
    let anchor = ƒ