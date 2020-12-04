module Main

open Fable.Core.JsInterop
open WebComponentsHelper
open Feliz


importSideEffects "./styles/main.scss"


let rc = OuterComponentReact.outerCounter

rc.propTypes {| start = PropTypes.string.isRequired |}

let webComp = reactToWebComponent(rc, react, reactDom, {| shadow = true |})



CustomElement.define("component-one", webComp)


















//ReactDOM.render(
//    OuterComponentReact.outerCounter (),
//    document.getElementById("component-one")
//)