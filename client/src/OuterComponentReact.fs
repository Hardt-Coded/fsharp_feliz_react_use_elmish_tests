module OuterComponentReact

    open Feliz
    open Feliz.UseElmish
    open OuterComponentElmish
    open WebComponent

    [<ReactWebComponent(false,true)>]
    let outerCounter (start:string) =
        let state, dispatch = React.useElmish(init start, update, [| start :> obj |])
        view state dispatch

