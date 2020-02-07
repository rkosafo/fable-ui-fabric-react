namespace Fable.UIFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module Label =
  type ILabelProps =
    | Props of IHTMLProp list
    | Disabled of bool
    | Required of bool
    | Styles of {| root: obj |}
    | Theme of ITheme
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let label props = ofImport "Label" ImportPath (ILabelProps.p props)

