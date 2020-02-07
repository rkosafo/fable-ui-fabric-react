namespace Fable.UIFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module CommandBar =
  type ICommandBarItemProps =
    {|key: string
      name: string
      cacheKey: string
      iconProps: {| iconName: string |}
      split: bool
      disabled: bool
      iconOnly: bool
      onClick: (unit -> unit)|}
  type ICommandBarProps =
    | Props of IHTMLProp list
    | ClassName of string
    | FarItems of ICommandBarItemProps []
    | Items of ICommandBarItemProps []
    | OverflowItems of ICommandBarItemProps []
    | Styles of obj
    | Theme of ITheme
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let commandBar props = ofImport "CommandBar" ImportPath (ICommandBarProps.p props)

