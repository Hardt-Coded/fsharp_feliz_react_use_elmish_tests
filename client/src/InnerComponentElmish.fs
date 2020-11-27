module InnerComponentElmish

    open Feliz
    open Feliz.UseElmish
    open Elmish

    //open Models.Inner


        type Model = {
            Counter: int
            SetOuterValue: int -> unit
        }
    
        type Msg =
            | Increment
            | Decrement
            
    
        let init value callback =
            { Counter = value; SetOuterValue = callback }, Cmd.none
    
    
        let update msg state =
            match msg with
            | Increment ->
                let newValue = state.Counter + 10
                { state with Counter = newValue }, Cmd.ofSub (fun _ -> state.SetOuterValue newValue)
            | Decrement ->
                let newValue = state.Counter - 10
                { state with Counter = newValue }, Cmd.ofSub (fun _ -> state.SetOuterValue newValue)
            
        
        let view state dispatch =
            Html.div [
                prop.style [ style.padding 20 ]
                prop.children [
                    Html.h1 "The Inner Counter"
                    Html.h1 state.Counter
                    Html.button [
                        prop.text "Increment"
                        prop.onClick (fun _ -> dispatch Increment)
                    ]
                    Html.button [
                        prop.text "Decrement"
                        prop.onClick (fun _ -> dispatch Decrement)
                    ]
                ]
            ]

