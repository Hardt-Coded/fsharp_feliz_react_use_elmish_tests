module OuterComponentReact

    open Feliz
    open Feliz.UseElmish
    open OuterComponentElmish

    [<ReactComponent>]
    let outerCounter () =
        let state, dispatch = React.useElmish(init , update, [|  |])
        view state dispatch

