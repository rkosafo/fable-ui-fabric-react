namespace UiFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module PivotItem =
  type IPivotItemProps =
    | Props of IHTMLProp list
    | HeaderText of string
    | ItemCount of int
    | ItemIcon of Icons
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let pivotItem props = ofImport "PivotItem" ImportPath (IPivotItemProps.p props)
  

[<RequireQualifiedAccess>]
module Pivot =
  type IPivotProps =
    | Props of IHTMLProp list
    | HeadersOnly of bool
    | DefaultSelectedKey of string
    | DefaultSelectedIndex of int
    | SelectedKey of string
    | Theme of ITheme
    | Styles of {| root: obj |}
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let pivot props = ofImport "Pivot" ImportPath (IPivotProps.p props)
