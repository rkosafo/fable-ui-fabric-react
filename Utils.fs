namespace Fable.FluentUI


module Utils =
  open Fable.Core

  let [<Literal>] ImportPath = "@fluentui/react"
  //let [<Literal>] ImportPathLib = "@fluentui/react/lib"
  let kvl xs = JsInterop.keyValueList CaseRules.LowerFirst xs
