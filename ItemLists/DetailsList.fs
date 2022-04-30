namespace Fable.FluentUI

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

    [<Import("Selection", "@fluentui/react/lib/DetailsList")>]
    let SelectionBuilder : SelectionStatic = jsNative

    //[<Import("Selection", "@fluentui/lib/DetailsList")>]
    //let selection: ISelection = jsNative
        
    type GetKey<'T> = ('T * int option) -> string

    type IColumn<'T> = {
        key: string
        name: string 
        fieldName: string
        minWidth: int
        maxWidth: int
        isResizable: bool
        onRender: 'T -> ReactElement
    }

    type IDetailsListProps<'T> =
        | Props of IHTMLProp list
        | Compact of bool
        | Items of 'T array
        | Columns of IColumn<'T> array
        | IsHeaderVisible of bool
        | Selection of ISelection
        | ConstrainMode of ConstrainModes
        | SetKey of string
        | GetKey of GetKey<'T>
        | LayoutMode of DetailsListLayoutMode
        | SelectionPreservedOnEmptyClick of bool
        | AriaLabelForSelectionColumn of string

        interface IHTMLProp
        static member p<'T> props =
            props
            |> List.fold (fun s x -> 
                match x with
                | Props x -> s @ x
                | GetKey getKey -> 
                    let safeGetKey((e: 'T), (i: int option)) = if (box e) <> null then getKey(e, i) else null
                    (GetKey safeGetKey :> IHTMLProp) :: s
                | x -> (x :> IHTMLProp) :: s) []
                |> kvl
            

    let detailsList<'T> props = ofImport "DetailsList" ImportPath (IDetailsListProps<'T>.p<'T> props)

type DetailsList<'T> =
    /// Creates a DetailsList column.
    static member Column(name: string, fieldName: string, onRender: 'T -> ReactElement, ?isResizable, ?minWidth, ?maxWidth) =
        let safeOnRender (t: 'T) = 
            if (box t) <> null
            then onRender t
            else null

        { DetailsList.IColumn.key = fieldName
          DetailsList.IColumn.fieldName = fieldName
          DetailsList.IColumn.name = name
          DetailsList.IColumn.isResizable = isResizable |> Option.defaultValue true
          DetailsList.IColumn.minWidth = minWidth |> Option.defaultValue 20
          DetailsList.IColumn.maxWidth = maxWidth |> Option.defaultValue 200
          DetailsList.IColumn.onRender = safeOnRender }