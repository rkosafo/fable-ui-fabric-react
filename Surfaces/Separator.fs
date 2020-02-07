namespace Fable.UIFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module Separator =
  type [<StringEnum(CaseRules.LowerFirst)>] Alignment = Start | Center | End
  type ISeparatorProps =
    | Props of IHTMLProp list
    | AlignContent of Alignment
    | Styles of obj
    | Theme of ITheme
    | Vertical of bool
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let separator props = ofImport "Separator" ImportPath (ISeparatorProps.p props)

