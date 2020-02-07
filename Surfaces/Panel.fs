namespace Fable.UIFabric

open Fable.Core
open Fable.React
open Fable.React.Props
open Utils
    
type PanelType = 
    | Custom = 7
    | CustomNear = 8 
    | ExtraLarge = 6
    | Large = 4
    | LargeFixed = 5
    | Medium = 3
    | SmallFixedFar = 1
    | SmallFluid = 0

[<RequireQualifiedAccess>]
module Panel =
    type IPanelProps =
        | HeaderText of string
        | OnDismiss of (unit -> unit)
        | OnOpen of (unit -> unit)
        | OnOpened of (unit -> unit)
        | OnRenderFooterContent of (unit -> ReactElement)
        | CloseButtonAriaLabel of string
        | ClassName of string
        | CustomWidth of string
        | Styles of obj
        | Type of PanelType
        | IsBlocking of bool
        | IsFooterAtBottom of bool
        | IsHiddenOnDismiss of bool
        | IsLightDismiss of bool
        | IsOpen of bool
        static member p (xs: IPanelProps list) = kvl xs

    let panel props = ofImport "Panel" ImportPath (IPanelProps.p props)
