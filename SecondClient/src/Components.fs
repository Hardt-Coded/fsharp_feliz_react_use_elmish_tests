module Components

open Feliz
open Feliz.UseElmish
open Elmish


type Model = {
    Counter: int
}

type Msg =
    | Increment
    | Decrement

let init () =
    { Counter = 0 }, Cmd.none


let update msg state =
    match msg with
    | Increment ->
        { Counter = state.Counter + 15 }, Cmd.none
    | Decrement ->
        { Counter = state.Counter - 15 }, Cmd.none

let view state dispatch =
    Html.div [
        prop.style [ style.padding 20 ]
        prop.children [
            Html.h1 "Second Counter!"
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
let secondCounter() =
    let (state, dispatch) = React.useElmish(init, update, [||])
    view state dispatch
    
