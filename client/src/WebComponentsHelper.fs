module WebComponentsHelper

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open System.Runtime.CompilerServices


[<Import("default", "react-to-webcomponent")>]
let reactToWebComponent (comp:obj, react:obj, dom:obj, opts: obj) : obj = jsNative

let react:obj = importDefault "react"
let reactDom:obj = importDefault "react-dom"


type PropType () =
    [<Emit("$0.isRequired")>]
    member __.isRequired:obj = jsNative


type IPropTypes () =
    [<Emit("$0.string")>]   
    member __.``string``:PropType = jsNative
    [<Emit("$0.number")>]   
    member __.number:PropType = jsNative
    //[<Emit("$0.object")>]   
    //member __.``object``:PropType = jsNative
    //[<Emit("$0.symbol")>]   
    //member __.``symbol``:PropType = jsNative
    //[<Emit("$0.func")>]     
    //member __.``func``:PropType = jsNative
    //[<Emit("$0.bool")>]     
    //member __.``bool``:PropType = jsNative
    //[<Emit("$0.array")>]    
    //member __.``array``:PropType = jsNative


[<Import("default","prop-types")>]
let PropTypes:IPropTypes = jsNative


[<Extension>]
type FunctionExtension() =
    [<Extension>]
    [<Emit("$0.propTypes=$1")>]
    static member inline propTypes (f: 'a -> ReactElement, props:obj)  = jsNative 

    [<Extension>]
    [<Emit("$0.propTypes=$1")>]
    static member inline propTypes (f: 'a -> 'b -> ReactElement, props:obj)  = jsNative 



module CustomElement =

    [<Emit("customElements.define($0,$1);")>] 
    let define (elementName:string, component:obj) = jsNative




