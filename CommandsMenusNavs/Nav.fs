namespace UiFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module Nav =
  type INavLink =
    {|key: string
      name: string
      url: string
      icon: string|}
  type IGroup =
    {|name: string
      links: INavLink []|}
  type INavProps =
    | Props of IHTMLProp list
    | ExpandButtonAriaLabel of string
    | Groups of IGroup []
    | Styles of obj
    | OnLinkClick of (Browser.Types.Event -> INavLink -> unit)
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let nav props = ofImport "Nav" ImportPath (INavProps.p props)

