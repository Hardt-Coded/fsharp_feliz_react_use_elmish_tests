module Main

open Fable.Core.JsInterop
open WebComponentsHelper
open Feliz
open WebComponent


importSideEffects "./styles/main.scss"

[<ReactWebComponentCall("component-one")>]
let webComp = OuterComponentReact.OuterCounter

//rc.propTypes {| start = PropTypes.string.isRequired |}

//let webComp = reactToWebComponent(rc, react, reactDom, {| shadow = true |})



//CustomElement.define("component-one", webComp)


















//ReactDOM.render(
//    OuterComponentReact.outerCounter (),
//    document.getElementById("component-one")
//)