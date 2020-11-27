module Components

open Feliz
open Feliz.UseElmish
open Elmish


module Inner =

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
    


    [<ReactComponent>]
    let counter value callback =
        // I have to cast the dependency values explictly to an obj
        let state, dispatch = React.useElmish(init value callback, update, [| value :> obj ; callback :> obj |])
        view state dispatch

module Outer =
    
    type Model = {
        Counter: int
        
    }

    type Msg =
        | Increment
        | Decrement
        | GetValueFromInnerComponent of int

    let init callback =
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
                        Inner.counter state.Counter (GetValueFromInnerComponent >> dispatch)
                    ]
                ]
                
                
            ]
        ]


    [<ReactComponent>]
    let outerCounter () =
        let state, dispatch = React.useElmish(init , update, [|  |])
        view state dispatch