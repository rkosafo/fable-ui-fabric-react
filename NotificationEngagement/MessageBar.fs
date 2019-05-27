namespace UiFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module MessageBar =
  type Type =
    | Info = 0
    | Error = 1
    | Blocked = 2
    | SevereWarning = 3
    | Success = 4
    | Warning = 5
  type IMessageBarProps =
    | Props of IHTMLProp list
    | Actions of ReactElement
    | AriaLabel of string
    | ClassName of string
    | DismissButtonAriaLabel of string
    | IsMultiline of bool
    | MessageBarType of Type
    | OnDismiss of (obj -> unit)
    | OverflowButtonAriaLabel of string
    | Styles of obj
    | Theme of ITheme
    | Truncated of bool
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let messageBar props = ofImport "MessageBar" ImportPath (IMessageBarProps.p props)

