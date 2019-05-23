namespace UiFabric


open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Utils


[<AutoOpen>]
module General =
  let customizer p els = ofImport "Customizer" ImportPath p els
  let FluentCustomizations = importMember<obj> "@uifabric/fluent-theme"

