module FormPage

module R = Fable.Helpers.React
open R.Props
open Fabulosa
open Fabulosa.Index

let view () =
    Fable.Helpers.React.div [] [
        R.h2 [] [R.str "Forms"]
        R.p [] [R.str "Forms provide the most common control styles used in forms, including input, textarea, select, checkbox, radio and switch."]
        Grid.ƒ Grid.defaults [
            Grid.Row.ƒ Grid.Row.defaults [
                Grid.Column.ƒ { Grid.Column.defaults with Size = 4 } [
                    Fable.Helpers.React.form [] [
                        Form.group [] [
                            Label.ƒ Label.defaults "Name"
                            Input.ƒ
                                { Input.defaults with HTMLProps = [Placeholder "Please enter your name"] }
                        ]
                        Form.group [] [
                            Label.ƒ Label.defaults "Phone"
                            
                            Input.ƒ { input with 
                                    HTMLProps = [
                                        Placeholder "Please enter your phone number"; Type "tel"] 
                            }
                            
                        ]
                        Form.group [] [
                            Label.ƒ Label.defaults "Time"
                            IconInput.ƒ { 
                                iconInput { input with HTMLProps = [Placeholder "Please enter something"] } with 
                                IconLeft = Some { icon [] with Kind = Icon.Kind.Time }
                            }
                        ]
                        Form.group [] [
                            Label.ƒ Label.defaults "Profile description"
                            Textarea.textarea [Placeholder "Please enter a description"] []
                        ]
                        Form.group [] [
                            Label.ƒ Label.defaults "Contact preferences"
                            Radio.ƒ
                                { Radio.defaults with
                                    HTMLProps = [Name "contact-prefs"] }
                                "Call me"
                            Radio.ƒ
                                { Radio.defaults with
                                    HTMLProps = [Name "contact-prefs"] }
                                "Text me"
                        ]
                        Form.group [] [
                            Label.ƒ Label.defaults "Profile preferences"
                            Switch.input [] "Link my github account"
                        ]
                        Form.group [] [
                            Checkbox.ƒ Checkbox.defaults "Remember me"
                            Checkbox.ƒ Checkbox.defaults "Forget me"
                        ]
                        Anchor.ƒ (Anchor.defaults [R.str "Submit"])
                    ]
                ]
            ]
        ]
    ]