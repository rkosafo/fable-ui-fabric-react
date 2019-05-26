namespace UiFabric


open System
open Fable.Core
open Utils
open Fable.React


[<RequireQualifiedAccess>]
module Button =
  open Fable.React.Props

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
    | IconProps of {| iconName: string |} // Icons.IIconProps list
    //KeytipProps of IKeytipProps
    | Primary of bool
    | PrimaryDisabled of bool
    | SecondaryText of string
    | Split of bool
    | SplitButtonAriaLabel of string
    | Style of obj
    | Text of string
    | Toggle of bool
    | MenuProps of {| items: {| key:string; text: string; iconProps: {| iconName: string |} |} [] |}
    | UniqueId of string
    | OnClick of (unit -> unit)
    | [<CompiledName("uniqueId")>] UniqueIdInt of int
    | Props of IHTMLProp list
    interface IHTMLProp

  let p (props: IButtonProps list) =
    props 
    |> List.fold (fun s x -> match x with
                              | Props x -> s @ x
                              //| IconProps xs -> unbox("iconProps", Icons.p xs) :: s
                              | x -> (x :> IHTMLProp) :: s) []
    |> kvl

  let defaultButton props = ofImport "DefaultButton" ImportPath (p props)
  let primaryButton props = ofImport "PrimaryButton" ImportPath (p props)
  let compoundButton props = ofImport "CompoundButton" ImportPath (p props)
  let commandBarButton props = ofImport "CommandBarButton" ImportPath (p props)
  let iconButton props = ofImport "IconButton" ImportPath (p props)
  let actionButton props = ofImport "ActionButton" ImportPath (p props)
  let commandButton props = ofImport "CommandButton" ImportPath (p props)