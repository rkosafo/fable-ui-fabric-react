namespace UiFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module TextField =
  type ITextFieldProps =
    | Props of IHTMLProp list
    | Label of string
    | Disabled of bool
    | Required of bool
    | DefaultValue of string
    | ErrorMessage of string
    | Placeholder of string
    | Multiline of bool
    | Rows of int
    | Resizable of bool
    | Underlined of bool
    | AutoAdjustHeight of bool
    | Description of bool
    | Borderless of bool
    | DeferredValidationTime of int
    | Mask of string
    | MaskFormat of obj
    | Prefix of string
    | ReadOnly of bool
    | Suffix of string
    | ValidateOnFocusIn of bool
    | ValidateOnFocusOut of bool
    | Styles of {| root: obj |}
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let textField props = ofImport "TextField" ImportPath (ITextFieldProps.p props)

