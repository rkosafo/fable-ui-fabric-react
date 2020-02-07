namespace Fable.UIFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils
open Fable.Core.JsInterop


type [<StringEnum>] Icons =
  | Delete


[<RequireQualifiedAccess>]
module Icons =
  type [<StringEnum>] IconType =
    | Default
    | Image
  type IIconProps =
    | IconName of string
    | Props of IHTMLProp list
    | IconType of IconType
    interface IHTMLProp

  let p (props: IIconProps list) =
    props 
    |> List.fold (fun s x -> match x with
                              | Props x -> s @ x
                              | x -> (x :> IHTMLProp) :: s) []
    |> kvl

  ///Call this before using icons
  //let initializeIcons = importMember<unit -> unit> ImportPath
  let initializeIcons() : unit = importMember "@uifabric/icons"


//[<AutoOpen>]
//module Auto =
  let icon props = ofImport "Icon" ImportPath (p props)

  ///Create an icon with the given name
  let icon' (name: string) = icon [IconName name] []
