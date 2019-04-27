namespace UiFabric


open System
open Fable.Core
open Utils
open Fable.Helpers.React


[<RequireQualifiedAccess>]
module Button =
  open Fable.Helpers.React.Props

  type IButton =
    | DismissMenu of (unit -> unit)
    | Focus of (unit -> unit)
    ///ShouldFocusOnContainer, ShouldFocusOnMount
    | OpenMenu of Action<bool, bool>
  type IButtonProps =
    | AllowDisabledFocus of bool
    | AriaDescription of string
    | AriaHidden of bool
    | AriaLabel of string
    | Checked of bool
    | ClassName of string
    //| ComponentRef of IRefObject<IButton>
    | Data of obj
    | Disabled of bool
    //getClassNames
    //getSplitButtonClassNames
    | Href of string
    | IconProps of Icon.IIconProps list
    //KeytipProps of IKeytipProps
    | Primary of bool
    | PrimaryDisabled of bool
    | SecondaryText of string
    | Split of bool
    | SplitButtonAriaLabel of string
    //styles
    | Text of string
    | Toggle of bool
    | UniqueId of string
    | [<CompiledName("uniqueId")>] UniqueIdInt of int
    | Props of IHTMLProp list
    interface IHTMLProp

  let p (props: IButtonProps list) =
    props 
    |> List.fold (fun s x -> match x with
                              | Props x -> s @ x
                              | IconProps xs -> unbox("iconProps", Icon.p xs) :: s
                              | x -> (x :> IHTMLProp) :: s) []
    |> kvl

  let defaultButton props = ofImport "DefaultButton" ImportPath (p props)
  let primaryButton props = ofImport "PrimaryButton" ImportPath (p props)
  let compoundButton props = ofImport "CompoundButton" ImportPath (p props)
  let commandBarButton props = ofImport "CommandBarButton" ImportPath (p props)