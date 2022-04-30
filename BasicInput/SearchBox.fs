namespace Fable.FluentUI

open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module SearchBox =

    type ISearchBoxProps =
        | Props of IHTMLProp list
        | Placeholder of string
        | OnFocus of (unit -> unit)
        | OnBlur of (unit -> unit)
        //| OnChange of (string -> unit)
        | OnChange of (Browser.Types.Event option -> unit)
        | OnSearch of (string -> unit)
        | OnEscape of (unit -> unit)
        | OnClear of (unit -> unit)
        | IconProps of {| iconName: string |}
        | Underlined of bool
        | Styles of obj
        | Theme of ITheme
        | Value of string
        | DisableAnimation of bool
        | ClassName of bool
        | AriaLabel of string
        | ComponentRef of (obj -> unit)
        interface IHTMLProp
        static member p props =
            props
            |> List.fold (fun s x -> match x with
                                        | Props x -> s @ x
                                        | x -> (x :> IHTMLProp) :: s) []
            |> kvl

    let searchBox props = ofImport "SearchBox" ImportPath (ISearchBoxProps.p props)

