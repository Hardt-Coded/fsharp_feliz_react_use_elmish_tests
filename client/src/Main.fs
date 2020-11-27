module Main

open Fable.Core.JsInterop
open Feliz
open Browser.Dom

importSideEffects "./styles/main.scss"

ReactDOM.render(
    Components.Outer.outerCounter (),
    document.getElementById("component-one")
)