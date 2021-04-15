namespace Fable.UIFabric

open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

type DropdownMenuItemType = Item = 0 | Divider = 1 | Header = 2

type ResponsiveMode = Small = 0 | Medium = 1 | Large = 2 | XLarge = 3 | XXLarge = 4 | XXXLarge = 5 | Unknown = 999

type IDropdownOption = 
    { key: string
      text: string
      itemType: DropdownMenuItemType }

[<RequireQualifiedAccess>]
module Dropdown =
    type IDropdownProps =
        | Props of IHTMLProp list
        | DefaultSelectedKeys of int []
        | DefaultSelectedKey of string
        | DropdownWidth of int
        | MultiSelect of bool
        | MultiSelectDelimiter of string
        | NotifyOnReselect of bool
        | OnChange of (Browser.Types.Event -> IDropdownOption -> int -> unit)
        | OnDismiss of (unit -> unit)
        | Placeholder of string
        | OnRenderPlaceholder of (IDropdownOption -> ReactElement)
        | OnRenderTitle of (IDropdownOption -> ReactElement)
        | Options of IDropdownOption []
        | ResponsiveMode of ResponsiveMode
        | SelectedKeys of int []
        | [<CompiledName("selectedKeys")>]SelectedKeysStr of string []
        | SelectedKey of int
        | [<CompiledName("selectedKey")>]SelectedKeyStr of string
        | ErrorMessage of string
        | Styles of obj
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

    // Options helpers:
    let optionItem key text = { IDropdownOption.key = key; text = text; itemType = DropdownMenuItemType.Item }
    let optionHeader key text = { IDropdownOption.key = key; text = text; itemType = DropdownMenuItemType.Header }
    let optionDivider key = { IDropdownOption.key = key; text = "-"; itemType = DropdownMenuItemType.Divider }