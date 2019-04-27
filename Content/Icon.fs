namespace UiFabric


open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Utils
open Fable.Core.JsInterop


[<RequireQualifiedAccess>]
module Icon =
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

  let icon props = ofImport "Icon" ImportPath (p props)

  let initializeIcons = importMember<unit -> unit> ImportPath