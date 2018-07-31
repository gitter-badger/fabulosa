module TypographyPage
open Fable.Helpers
open Fable.Helpers.React.Props
open Fabulosa
open System
open Fable.Core.JsInterop
open Fable.Core
open Fable.Import.React
open Fabulosa.Docs.ListFlatMapExtension
open ReactElementStringExtensions
open Fabulosa.Docs.JavascriptMapping
open Fabulosa.Docs.JavascriptMapping
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
                    [
                        R.code [ClassName "prism-code-reset"; DangerouslySetInnerHTML <| Prism.highlight stringfiedCode] []
                    ]
                    |> R.pre [ClassName "language-fsharp"] 
                ]
        ]
        
let headingsCode = """ofString Typography.h1 "H1 Heading"
ofString Typography.h2 "H2 Heading"
ofString Typography.h3 "H3 Heading"
ofString Typography.h4 "H4 Heading"
ofString Typography.h5 "H5 Heading"
ofString Typography.h6 "H6 Heading"
"""        
let headingsBlock =  
    block 
       "Headings" 
       headingsCode 
       <| R.div [] 
           [
               ofString Typography.h1 "H1 Heading"
               ofString Typography.h2 "H2 Heading"
               ofString Typography.h3 "H3 Heading"
               ofString Typography.h4 "H4 Heading"
               ofString Typography.h5 "H5 Heading"
               ofString Typography.h6 "H6 Heading"
           ]       

let paragraphCode = """ Typography.p []
    [
       R.str "Lorem ipsum dolor sit amet, consectetur "
       R.a [] [R.str "adipiscing elit"]
       R.str ". Praesent risus leo, dictum in vehicula sit amet, feugiat tempus tellus. Duis quis sodales risus. Etiam euismod ornare consequat"
    ]
ofString Typography.p "limb leg rub face on everything give attitude nap all day for under the bed. Chase mice attack feet but rub face on everything hopped up on goofballs."
"""
let paragraphsBlock = 
    block 
        "Paragraphs" 
        paragraphCode
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
        
let columnOfElement n element = 
    Grid.column [ Grid.Column.Size n ] [] [ element ]
let halfColumn = columnOfElement 6
let thirdColumn = columnOfElement 4
    
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

let ruby = 
    R.span []
        [
            Typography.ruby [] 
                [
                    R.str "漢"
                    ofString Typography.rt "kan"
                    R.str "字"
                    ofString Typography.rt "ji"
                                      
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
    [
        abbr
        bold
        cite
        code
        del
        i
        ins
        kbd
        highlighted
        ruby
        s
        samp
        sub
        sup
        time
        u
        var
    ] 
    |> List.map halfColumn 
    |> Grid.row [] [] 
    |> block "Semantic text elements" """""" 
    
let blockquoteBlock =
    [
        ofString Typography.p "Some people have told me they don't think a fat penguin really embodies the grace of Linux, which just tells me they have never seen an angry penguin charging at them in excess of 100 mph. They'd be a lot more careful about what they say if they had."
        ofString Typography.cite " - Linus Torvalds"
    ] 
    |> Typography.blockquote []
    |> block "Blockquote" 
        """ofString Typography.p "Some people have told me they don't think a fat penguin really embodies the grace of Linux, which just tells me they have never seen an angry penguin charging at them in excess of 100 mph. They'd be a lot more careful about what they say if they had."
ofString Typography.cite " - Linus Torvalds"
"""    
    
let getList listConstructor listItemConstructor =
    [
        ofString listItemConstructor "list item 1"
        ofString listItemConstructor "list item 2"
        listConstructor []
            [
                ofString listItemConstructor "list item 2.1"    
                ofString listItemConstructor "list item 2.2"    
                ofString listItemConstructor "list item 2.3"    
            ]
        ofString listItemConstructor "list item 3"    
    ] 
    |> listConstructor []
    |> thirdColumn

let descriptionListItem label value =
    [
        ofString Typography.dt label
        ofString Typography.dd value
    ]

let descriptionList =
    [
        descriptionListItem "Coffee" "Black hot drink"
        descriptionListItem "Milk" "White cold drink"
        descriptionListItem "Orange juice" "100% from fruit"
    ] 
    |> List.flatMap
    |> Typography.dl []
    |> thirdColumn

let listBlock =
    [
        getList Typography.ul Typography.li
        getList Typography.ol Typography.li   
        descriptionList
    ]
    |> Grid.row [] []
    |> block "Lists" "" 
   
let typographyPage = 
    R.div []
        [
            headingsBlock
            paragraphsBlock
            semanticTextElementsBlock
            blockquoteBlock
            listBlock
        ]
    
let view () = 
    typographyPage 
    |> page "Typography" "Typography sets default styles for headings, paragraphs, semantic text, blockquote and lists elements." 
