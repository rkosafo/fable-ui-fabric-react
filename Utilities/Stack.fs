namespace Fable.FluentUI

open Fable.React
open Fable.React.Props
open Utils
open Fable.Core


type [<StringEnum(CaseRules.LowerFirst)>] HorizontalAlignTypes =
    | End
    | [<CompiledName("space-around")>] SpaceAround
    | [<CompiledName("space-between")>] SpaceBetween
    | [<CompiledName("space-evenly")>] SpaceEvenly

[<RequireQualifiedAccess>]
module Stack =
    
    type IStackProps =
        | Props of IHTMLProp list
        | Horizontal
        | HorizontalAlign of HorizontalAlignTypes
        | Tokens of {| childrenGap: int; padding: string |}
        /// "Gap" has been deprecated in favor of "tokens.childrenGap"; this binding maps to "tokens.childrenGap".
        | Gap of int
        | [<CompiledName("gap")>] GapStr of string
        | Styles of {| root: obj |}
        | MaxHeight of int
        | MaxWidth of int
        | Padding of int
        | Reversed
        | VerticalFill
        | Wrap

        interface IHTMLProp
            static member p props =
                props
                |> List.fold (fun s x -> match x with | Props x -> s @ x | x -> (x :> IHTMLProp) :: s) []
                |> kvl

    let stack props = 

        // Replace "Gap" with "Tokens"
        let props =
            props
            |> List.choose (fun p -> match p with Gap gap -> Some (Tokens {| childrenGap = gap; padding = "" |}) | _ -> Some p)


        ofImport "Stack" ImportPath (IStackProps.p props)

[<RequireQualifiedAccess>]
module StackItem =

    type IStackItemProps =
        | Props of IHTMLProp list
        | Align of string
        | Styles of {| root: obj |}
        | MaxHeight of int
        | MaxWidth of int
        | Padding of int
        | Reversed
        | Wrap

        interface IHTMLProp
            static member p props =
                props
                |> List.fold (fun s x -> match x with | Props x -> s @ x | x -> (x :> IHTMLProp) :: s) []
                |> kvl

    let stackItem props = 
        ofImport "StackItem" ImportPath (IStackItemProps.p props)

