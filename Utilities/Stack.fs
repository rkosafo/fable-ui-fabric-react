namespace UiFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module Stack =
  type IStackProps =
    | Props of IHTMLProp list
    | Horizontal of bool
    | Gap of int
    | [<CompiledName("gap")>]GapStr of string
    | Styles of {| root: obj |}
    | MaxHeight of int
    | MaxWidth of int
    | Padding of int
    | Reversed of bool
    | VerticalFill of bool
    | Wrap of bool
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let stack props = ofImport "Stack" ImportPath (IStackProps.p props)

