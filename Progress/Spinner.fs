namespace Fable.FluentUI


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module Spinner =
  type [<StringEnum(CaseRules.LowerFirst)>] LabelPosition =
    | Top
    | Right
    | Bottom
    | Left
  type SpinnerSize =
    | XSmall = 0
    | Small = 1
    | Medium = 2
    | Large = 3
  type ISpinnerProps =
    | Props of IHTMLProp list
    | ClassName of string
    | Label of string
    | LabelPosition of LabelPosition
    | Size of SpinnerSize
    | Styles of obj

    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let spinner props = ofImport "Spinner" ImportPath (ISpinnerProps.p props)

