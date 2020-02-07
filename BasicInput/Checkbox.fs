namespace Fable.UIFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module Checkbox =
  type [<StringEnum(CaseRules.LowerFirst)>] BoxSide = Start | End
  type ICheckboxProps =
    | Props of IHTMLProp list
    | BoxSide of BoxSide
    | Checked of bool
    | ClassName of string
    | DefaultChecked of bool
    | Disabled of bool
    | Label of string
    | OnChange of ((obj * bool) -> unit)
    | Styles of {| root: obj |}
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let checkbox props = ofImport "Checkbox" ImportPath (ICheckboxProps.p props)

