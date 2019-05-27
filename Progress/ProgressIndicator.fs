namespace UiFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module ProgressIndicator =
  type IProgressIndicatorProps =
    | Props of IHTMLProp list
    | BarHeight of int
    | ClassName of string
    | Description of ReactElement
    | Label of ReactElement
    | PercentComplete of float
    | ProgressHidden of bool
    | Styles of obj
    | Theme of ITheme
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let progressIndicator props = ofImport "ProgressIndicator" ImportPath (IProgressIndicatorProps.p props) []

