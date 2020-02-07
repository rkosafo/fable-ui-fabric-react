namespace Fable.UIFabric


open System
open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module DatePicker =
  type DayOfWeek = 
    | Sunday = 0 | Monday = 1 | Tuesday = 2 | Wednesday = 3 
    | Thursday = 4 | Friday = 5 | Saturday = 6
  type IDatePickerProps =
    | Props of IHTMLProp list
    | Placeholder of string
    | AllFocusable of bool
    | AllowTextInput of bool
    | Borderless of bool
    | ClassName of string
    | DisabledAutoFocus of bool
    | Disabled of bool
    | FormatDate of (DateTime -> string)
    | FirstDayOfWeek of DayOfWeek
    | FirstWeekOfYear of int
    | HighlightCurrentMonth of bool
    | HighlightSelectedMonth of bool
    | InitialPickerDate of DateTime
    | IsMonthPickerVisible of bool
    | IsRequired of bool
    //| ErrorMessage of string
    | Label of string
    | MaxDate of DateTime
    | MinDate of DateTime
    | OnAfterMenuDismiss of (unit -> unit)
    | OnSelectDate of (DateTime option -> unit)
    | ParseDateFromString of (string -> DateTime option)
    | ShowClosebutton of bool
    | ShowGoToToday of bool
    | ShowMonthPickerAsOverlay of bool
    | ShowWeekNumbers of bool
    | Styles of {| root: obj |}
    | Style of obj
    | TabIndex of int
    | TextField of TextField.ITextFieldProps list
    | OnValidate of (string -> string)
    | Theme of ITheme
    | Today of DateTime option
    | Underlined of bool
    | Value of DateTime
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | TextField xs -> unbox("textField", TextField.ITextFieldProps.p xs) :: s
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let datePicker props = ofImport "DatePicker" ImportPath (IDatePickerProps.p props)

