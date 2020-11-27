module Main

open Fable.Core.JsInterop
open Feliz
open Browser.Dom

importSideEffects "./styles/main.scss"

ReactDOM.render(
    Components.secondCounter(),
    document.getElementById("component-two")
)