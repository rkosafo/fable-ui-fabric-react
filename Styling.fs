namespace UiFabric


open Fable.Core.JsInterop
open Utils


module Styling =
  let loadTheme: (obj -> unit) = importMember<obj -> unit> ImportPath

