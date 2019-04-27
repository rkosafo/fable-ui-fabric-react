namespace UiFabric


open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Utils


[<RequireQualifiedAccess>]
module Dialog =
  type [<StringEnum>] DialogType =
    | Normal

  type IDialogContentProps =
    | Type of DialogType
    | Title of string
    | SubText of string
    static member p (xs: IDialogContentProps list) = kvl xs
  
  type IModelProps =
    | TitleAriaId of string
    | SubTitleAriaId of string
    | IsBlocking of bool
    | ContainerClassName of string
    static member p (xs: IModelProps list) = kvl xs

  type IDialogProps =
    | Hidden of bool
    | DialogContentProps of IDialogContentProps list
    | MaxWidth of obj
    | MinWidth of obj
    | ModelProps of IModelProps list
    | OnDismiss of (unit -> unit)
    | Styles of obj
    | Theme of obj
    | Props of IHTMLProp list
    interface IHTMLProp
    static member p props =
      props 
      |> List.fold (fun s x -> match x with
                                | Props x -> s @ x
                                | DialogContentProps xs -> unbox("dialogContentProps", IDialogContentProps.p xs) :: s
                                | ModelProps xs -> unbox("modelProps", IModelProps.p xs) :: s
                                | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let dialog props = ofImport "Dialog" ImportPath (IDialogProps.p props)
  let dialogFooter children = ofImport "DialogFooter" ImportPath (obj()) children
