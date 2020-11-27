module InnerComponentReact

    open Feliz
    open Feliz.UseElmish
    open InnerComponentElmish

    [<ReactComponent>]
    let counter value callback =
        // I have to cast the dependency values explictly to an obj
        let state, dispatch = React.useElmish(init value callback, update, [| value :> obj ; callback :> obj |])
        view state dispatch

