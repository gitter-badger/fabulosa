namespace Fabulosa

[<RequireQualifiedAccess>]
module Checkbox =

    module R = Fable.Helpers.React
    open R.Props

    let input htmlProps label =
        let inputProps: IHTMLProp list = [Type "checkbox"]
        let props = htmlProps @ inputProps
        R.label [ClassName "form-checkbox"] [
            R.input props
            R.i [ClassName "form-icon"] []
            R.str label
        ]