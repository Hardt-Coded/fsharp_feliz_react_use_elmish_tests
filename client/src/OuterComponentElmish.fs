module OuterComponentElmish

    open Feliz
    open Feliz.UseElmish
    open Elmish

        type Model = {
            Counter: int
            
        }
    
        type Msg =
            | Increment
            | Decrement
            | GetValueFromInnerComponent of int
    
        let init () =
            { Counter = 0 }, Cmd.none
    
    
        let update msg state =
            match msg with
            | Increment ->
                { state with Counter = state.Counter + 5 }, Cmd.none
            | Decrement ->
                { state with Counter = state.Counter - 5 }, Cmd.none
            | GetValueFromInnerComponent value ->
                { state with Counter = value }, Cmd.none
    
        
        let view state dispatch =
            Html.div [
                prop.style [ style.padding 20 ]
                prop.children [
                    Html.h1 "The Outer Component"
                    Html.p "The counter value is passed to the inner component"
                    Html.h1 state.Counter
                    Html.button [
                        prop.text "Increment"
                        prop.onClick (fun _ -> dispatch Increment)
                    ]
                    Html.button [
                        prop.text "Decrement"
                        prop.onClick (fun _ -> dispatch Decrement)
                    ]
    
                    
    
                    // The inner component with parameter!
                    Html.div [ 
                        prop.style [
                            style.border (1, borderStyle.solid, "#000000")
                        ]
                        prop.children [
                            InnerComponentReact.counter state.Counter (GetValueFromInnerComponent >> dispatch)
                        ]
                    ]
                    
                    
                ]
            ]

