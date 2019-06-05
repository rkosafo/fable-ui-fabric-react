namespace UiFabric


module Utils =
  open Fable.Core

  let [<Literal>] ImportPath = "office-ui-fabric-react"
  let kvl xs = JsInterop.keyValueList CaseRules.LowerFirst xs
