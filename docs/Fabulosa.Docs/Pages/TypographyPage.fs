module TypographyPage
open Fable.Helpers
open Fable.PowerPack.Keyboard
open Fable.Helpers.React.Props
open ReactElementStringExtensions
open System

module R = Fable.Helpers.React

let page header subheader body = 
    R.div [] [
        R.h1 [] [R.str header]
        R.p [] [R.str subheader]
        body
    ]
    
let block title stringfiedCode pageBlock =
    R.div [] 
        [
            ofString Typography.h4 title
            R.div [ClassName "component-view-container"] 
                [
                    pageBlock
                ]
            R.div [ClassName "code-container"]
                [
                    R.pre [] [R.str stringfiedCode]
                ]
        ]
        
        
let headingsBlock =  
    block 
       "Headings" 
       """
           ofString Typography.h1 "H1 Heading"
           ofString Typography.h2 "H2 Heading"
           ofString Typography.h3 "H3 Heading"
           ofString Typography.h4 "H4 Heading"
           ofString Typography.h5 "H5 Heading"
           ofString Typography.h6 "H6 Heading"
       """ 
       <| R.div [] 
           [
               ofString Typography.h1 "H1 Heading"
               ofString Typography.h2 "H2 Heading"
               ofString Typography.h3 "H3 Heading"
               ofString Typography.h4 "H4 Heading"
               ofString Typography.h5 "H5 Heading"
               ofString Typography.h6 "H6 Heading"
           ]       

let paragraphsBlock = 
    block 
           "Paragraphs" 
           """
               Typography.p []
                   [
                       R.str "Lorem ipsum dolor sit amet, consectetur "
                       R.a [] [R.str "adipiscing elit"]
                       R.str ". Praesent risus leo, dictum in vehicula sit amet, feugiat tempus tellus. Duis quis sodales risus. Etiam euismod ornare consequat"
                   ]
               ofString Typography.p "limb leg rub face on everything give attitude nap all day for under the bed. Chase mice attack feet but rub face on everything hopped up on goofballs."
           """ 
           <| R.div [] 
               [
                   Typography.p []
                        [
                            R.str "Lorem ipsum dolor sit amet, consectetur "
                            R.a [] [R.str "adipiscing elit"]
                            R.str ". Praesent risus leo, dictum in vehicula sit amet, feugiat tempus tellus. Duis quis sodales risus. Etiam euismod ornare consequat"
                        ]
                   ofString Typography.p "limb leg rub face on everything give attitude nap all day for under the bed. Chase mice attack feet but rub face on everything hopped up on goofballs."
               ]       
        
let columnOfElement element = 
    Grid.column [ Grid.Column.Size 6 ] [] [ element ]
    
let space = R.span [Style [PaddingRight "0.5rem"]] []

let semancticTextDisplay displayText element codeText = 
    R.span []
        [
            ofString element displayText
            space
            ofString Typography.code codeText
        ] 
    

let abbr = 
    R.span []
        [
            Typography.abbr [Title "Abbreviation"] [R.str "abbr"]
            space
            ofString Typography.code "abbr"
            space
            ofString Typography.code "abbreviation"
        ]
let bold =
     R.span []
        [
            ofString Typography.b "Bold"
            space
            ofString Typography.code "strong"
            space
            ofString Typography.code "b"
        ]      

let cite = semancticTextDisplay "Citation" Typography.cite "cite"
let code = semancticTextDisplay "Hello World!" Typography.code "code"
let del = semancticTextDisplay "Delete" Typography.del "del"
let i = semancticTextDisplay "Italic" Typography.i "i"
let ins = semancticTextDisplay "Inserted" Typography.ins "ins"
let kbd = semancticTextDisplay "Ctrl + S" Typography.kbd "kbd"
let highlighted = semancticTextDisplay "Highlighted" Typography.mark "mark"
let ruby = R.span []
               [
                   Typography.ruby [] 
                        [
                            R.str "漢"
                            R.rt [] [R.str "kan"]
                            R.str "字"
                            R.rt [] [R.str "ji"] 
                                              
                        ]
                   space
                   ofString Typography.code "ruby"
               ]  
let s = semancticTextDisplay "Strikethrough" Typography.s "s"
let samp = semancticTextDisplay "Sample" Typography.samp "samp"
let sub = semancticTextDisplay "Subscripted" Typography.sub "sub"
let sup = semancticTextDisplay "Superscripted" Typography.sup "sup"
let time = semancticTextDisplay "20:00" Typography.time "time"
let u = semancticTextDisplay "Underline" Typography.u "u"
let var = semancticTextDisplay "x = y + 2" Typography.var "var"
          
        
let semanticTextElementsBlock = 
    block 
        "Semantic text elements" 
        """""" 
        <| Grid.row [] []
                [
                    abbr |> columnOfElement
                    bold |> columnOfElement
                    cite |> columnOfElement
                    code |> columnOfElement
                    del |> columnOfElement
                    i |> columnOfElement
                    ins |> columnOfElement
                    kbd |> columnOfElement
                    highlighted |> columnOfElement
                    ruby |> columnOfElement
                    s |> columnOfElement
                    samp |> columnOfElement
                    sub |> columnOfElement
                    sup |> columnOfElement
                    time |> columnOfElement
                    u |> columnOfElement
                    var |> columnOfElement
                    
                ]
    
let typographyPage = 
    R.div []
        [
            headingsBlock
            paragraphsBlock
            semanticTextElementsBlock
        ]
    

let view () = typographyPage |> page "Typography" "Typography sets default styles for headings, paragraphs, semantic text, blockquote and lists elements." 
