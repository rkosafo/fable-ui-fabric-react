namespace Fable.UIFabric

open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module DetailsList =
    type [<StringEnum(CaseRules.LowerFirst)>] ConstrainModes = Unconstrained | HorizontalConstrained
    type SelectionModes = none = 0 | single = 1 | multiple = 2
    type [<StringEnum(CaseRules.LowerFirst)>] DetailsListLayoutMode = FixedColumns | Justified

    type ISelectionOptions = {
        selectionMode: SelectionModes
        onSelectionChanged: (unit -> unit)
    }

    type ISelection = 
        abstract selectionMode: SelectionModes with get,set
        abstract onSelectionChanged: (unit -> unit) with get,set
    
    type SelectionStatic =
        [<Emit("new $0($1)")>]
        abstract Create: ISelectionOptions -> ISelection

    [<Import("Selection", "office-ui-fabric-react/lib/DetailsList")>]
    let SelectionBuilder : SelectionStatic = jsNative

    //[<Import("Selection", "office-ui-fabric-react/lib/DetailsList")>]
    //let selection: ISelection = jsNative
        
    type IColumn = {
        Key: string
        Name: string
        FieldName: string
        MinWidth: int
        MaxWidth: int
        IsResizable: bool
    }

    type IDetailsListProps =
        | Props of IHTMLProp list
        | Compact of bool
        | Items of obj
        | Columns of IColumn list
        | Selection of ISelection
        | ConstrainMode of ConstrainModes
        | SetKey of string
        | LayoutMode of DetailsListLayoutMode
        | SelectionPreservedOnEmptyClick of bool
        | AriaLabelForSelectionColumn of string

        interface IHTMLProp
        static member p props =
            props
            |> List.fold (fun s x -> match x with
                                     | Props x -> s @ x
                                     | x -> (x :> IHTMLProp) :: s) []
                                     |> kvl

    let detailsList props = ofImport "DetailsList" ImportPath (IDetailsListProps.p props)

