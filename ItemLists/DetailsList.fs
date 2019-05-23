namespace UiFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module DetailsList =
  type IDetailsListProps =
    | Props of IHTMLProp list
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let detailsList props = ofImport "DetailsList" ImportPath (IDetailsListProps.p props)

