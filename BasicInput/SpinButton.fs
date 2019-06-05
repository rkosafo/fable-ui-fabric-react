namespace UiFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module SpinButton =
  type [<StringEnum(CaseRules.None)>] LabelPosition = Left | Right
  type ISpinButtonProps =
    | Props of IHTMLProp list
    | ClassName of string
    | DefaultValue of string
    | Disabled of bool
    | Label of string
    | LabelPosition of LabelPosition
    | Max of int
    | [<CompiledName("max")>]MaxFloat of float
    | Min of int
    | [<CompiledName("min")>]MinFloat of float
    | OnDecrement of (string -> unit)
    | OnIncrement of (string -> unit)
    | OnValidate of ((string -> Browser.Types.Event -> string))
    | OnFocus of (unit -> unit)
    | OnBlur of (unit -> unit)
    | Precision of int
    | Step of int
    | Styles of {| root: obj |}
    | Theme of ITheme
    | Value of string
    | IsRequired of bool
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let spinButton props = ofImport "SpinButton" ImportPath (ISpinButtonProps.p props)

