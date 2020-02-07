namespace Fable.UIFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module Text =
  type [<StringEnum(CaseRules.LowerFirst)>] FontStyles =
    | Tiny
    | XSmall
    | Small
    | SmallPlus
    | Medium
    | MediumPlus
    | Large
    | XLarge
    | XXLarge
    | Mega
  type ITextProps =
    | Props of IHTMLProp list
    | As of ReactElementType<obj>
    | Block of bool
    | Nowrap of bool
    | Variant of FontStyles
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let text props = ofImport "Text" ImportPath (ITextProps.p props)

