module OuterComponentReact

    open Feliz
    open Feliz.UseElmish
    open OuterComponentElmish
    open WebComponent


    let something () = ()


    [<ReactWebComponent(false)>]
    let OuterCounter (parms:{| start:string; arg2:string; arg3:string; arg4:string; arg5:string; arg6:string |}) =
        let state, dispatch = React.useElmish(
            init parms.start parms.arg2 parms.arg3 parms.arg4 parms.arg5 parms.arg6, 
            update, 
            [| parms.start :> obj; parms.arg2:> obj; parms.arg3:> obj; parms.arg4:> obj; parms.arg5:> obj |])
        view state dispatch

