module Main

open Fable.Core.JsInterop
open WebComponent


importSideEffects "./styles/main.scss"



[<CreateReactWebComponent("component-one")>]
let webComp = OuterComponentReact.OuterCounter




















//ReactDOM.render(
//    OuterComponentReact.outerCounter (),
//    document.getElementById("component-one")
//)