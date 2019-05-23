namespace UiFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module Dropdown =
  type [<StringEnum(CaseRules.LowerFirst)>] DropdownMenuItemType = Header | Divider
  type [<Erase>] IDropdownOption = 
    { key: string
      text: string
      itemType: DropdownMenuItemType }
  type [<StringEnum(CaseRules.LowerFirst)>] ResponsiveMode = Large | Small
  type IDropdownProps =
    | Props of IHTMLProp list
    | DefaultSelectedKeys of int []
    | DropdownWidth of int
    | MultiSelect of bool
    | MultiSelectDelimiter of string
    | NotifyOnReselect of bool
    | OnChange of ((obj * IDropdownOption * int option) -> unit)
    | OnDismiss of (unit -> unit)
    | OnRenderPlaceholder of (IDropdownOption -> ReactElement)
    | OnRenderTitle of (IDropdownOption -> ReactElement)
    | Options of IDropdownOption []
    | ResponsiveMode of ResponsiveMode
    | SelectedKeys of int []
    | [<CompiledName("selectedKeys")>]SelectedKeysStr of string []
    | Styles of {| root: obj |}
    | Theme of ITheme
    | Label of string
    | Disabled of bool
    | Value of obj
    | Required of bool
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let dropdown props = ofImport "Dropdown" ImportPath (IDropdownProps.p props)

