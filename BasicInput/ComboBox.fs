namespace Fable.FluentUI

open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

type [<StringEnum(CaseRules.LowerFirst)>] AutoComplete = On | Off

type ComboBoxMenuItemType = Item = 0 | Divider = 1 | Header = 2

type IComboBoxOption = 
    { key: string
      text: string
      itemType: ComboBoxMenuItemType }

[<RequireQualifiedAccess>]
module ComboBox =
    type IComboBoxProps =
        | Props of IHTMLProp list
        | DefaultSelectedKeys of int []
        | ComboBoxWidth of int
        | MultiSelect
        | MultiSelectDelimiter of string
        | NotifyOnReselect of bool
        | OnChange of (Browser.Types.Event -> IComboBoxOption option -> int -> unit)
        | OnFocus of (unit -> unit)
        | OnBlur of (unit -> unit)
        | OnMenuOpen of (unit -> unit)
        | OnDismiss of (unit -> unit)
        | OnRenderPlaceholder of (IComboBoxOption -> ReactElement)
        | OnRenderTitle of (IComboBoxOption -> ReactElement)
        | Placeholder of string
        | AllowFreeform
        | AutoComplete of AutoComplete
        | Options of IComboBoxOption []
        | SelectedKeys of string []
        | [<CompiledName("selectedKeys")>]SelectedKeysStr of string []
        | SelectedKey of string option
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

    let comboBox props = ofImport "ComboBox" ImportPath (IComboBoxProps.p props)

    // Options helpers:
    let optionItem key text = { IComboBoxOption.key = key; text = text; itemType = ComboBoxMenuItemType.Item }
    let optionHeader key text = { IComboBoxOption.key = key; text = text; itemType = ComboBoxMenuItemType.Header }
    let optionDivider key = { IComboBoxOption.key = key; text = "-"; itemType = ComboBoxMenuItemType.Divider }