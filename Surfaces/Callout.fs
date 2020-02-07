namespace Fable.UIFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module Callout =
  type ICalloutProps =
    | Props of IHTMLProp list
    | GapSpace of int
    | Hidden of bool
    | Theme of ITheme
    | Target of obj
    | Styles of obj
    | SetInitialFocus of bool
    | Role of string
    | PreventDismissOnScroll of bool
    | PreventDismissOnResize of bool
    | PreventDismissOnLostFocus of bool
    | OnScroll of (unit -> unit)
    | OnDismiss of (unit -> unit)
    | IsBeakVisible of bool
    | HideOverflow of bool
    | FinalHeight of int
    | CoverTarget of bool
    | CalloutWidth of int
    | CalloutMaxWidth of int
    | CalloutMaxHeight of int
    | ClassName of string
    | BeakerWidth of bool
    | BackgroundColor of bool
    | AlignTargetEdge of bool
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let callout props = ofImport "Callout" ImportPath (ICalloutProps.p props)

