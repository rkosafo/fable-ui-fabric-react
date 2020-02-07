namespace Fable.UIFabric


module Utils =
  open Fable.Core

  let [<Literal>] ImportPath = "office-ui-fabric-react"
  let [<Literal>] ImportPathLib = "office-ui-fabric-react/lib"
  let kvl xs = JsInterop.keyValueList CaseRules.LowerFirst xs
