module OuterComponentElmish

    open Feliz
    open Feliz.UseElmish
    open Elmish

        type Model = {
            Counter: int
            StartValue:string
            Arg2:string
            Arg3:string
            Arg4:string
            Arg5:string
            Arg6:string
        }
    
        type Msg =
            | Increment
            | Decrement
            | GetValueFromInnerComponent of int
    
        let init (startValue:string)
                 arg2 arg3 arg4 arg5 arg6 =
            Browser.Dom.console.log(startValue)
            let isOk,v = System.Int32.TryParse startValue
            let startValueInt = if isOk then v else 0
            { Counter = startValueInt; StartValue = startValue; Arg2 = arg2; Arg3 = arg3; Arg4 = arg4; Arg5 = arg5; Arg6 = arg6 }, Cmd.none
    
    
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
                    Html.h1 "The Outer React Web Component"
                    Html.p "Values from the WebComponents Arguments:"
                    Html.p state.StartValue
                    Html.p state.Arg2
                    Html.p state.Arg3
                    Html.p state.Arg4
                    Html.p state.Arg5
                    Html.p state.Arg6
                    Html.p ""
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

