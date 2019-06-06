namespace UiFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module Persona =
  type IPersonaProps =
    | Props of IHTMLProp list
    | ClassName of string
    | Text of string
    | SecondaryText of string
    | TertiaryText of string
    | OptionalText of string
    | Size of int
    | CoinSize of int
    | ImageUrl of string
    | ImageInitials of string
    | ShowUnknownPersonaCoin of bool
    | Styles of obj
    | Theme of ITheme
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let persona props = ofImport "Persona" ImportPath (IPersonaProps.p props) []