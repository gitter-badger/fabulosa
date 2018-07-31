namespace Fabulosa.Docs.Domain

module Page =

    open Fable.Helpers.React.Props
    open Fabulosa
    open ReactElementStringExtensions
    open Fabulosa.Docs.JavascriptMapping
    module R = Fable.Helpers.React
    
    let page header subheader body = 
        [
            ofString Typography.h1 header
            ofString Typography.p subheader
            body
        ] 
        |>   R.div [] 
        
    let block title stringfiedCode pageBlock =
        R.div [] 
            [
                ofString Typography.h4 title
                [pageBlock] |> R.div [ClassName "component-view-container"] 
                    
                R.div [ClassName "code-container"]
                    [
                        [
                            R.code [ClassName "prism-code-reset"; DangerouslySetInnerHTML <| Prism.highlight stringfiedCode] []
                        ]
                        |> R.pre [ClassName "language-fsharp"] 
                    ]
            ]