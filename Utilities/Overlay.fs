namespace UiFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module Overlay =
  type IOverlayProps =
    | Props of IHTMLProp list
    | ClassName of string
    | IsDarkThemed of bool
    | OnClick of (unit -> unit)
    | Styles of obj
    | Theme of ITheme
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let overlay props = ofImport "Overlay" ImportPath (IOverlayProps.p props)

