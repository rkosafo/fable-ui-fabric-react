namespace Fable.UIFabric


open Fable.Core
open Fable.React
open Fable.React.Props
open Utils

[<RequireQualifiedAccess>]
module DocumentCardActions =
  type IDocumentCardActionsProps =
    | Props of IHTMLProp list
    | Actions of {| iconProps: {| iconName: string|}; onClick: (unit -> unit) |} []
    | ClassName of string
    | Styles of obj
    | Theme of ITheme
    | Views of int
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let documentCardActions props = ofImport "DocumentCardActions" ImportPath (IDocumentCardActionsProps.p props)

  let create actions = documentCardActions [Actions actions] []


[<RequireQualifiedAccess>]
module DocumentCardTitle =
  type IDocumentCardTitleProps =
    | Props of IHTMLProp list
    | Title of string
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let documentCardTitle props = ofImport "DocumentCardTitle" ImportPath (IDocumentCardTitleProps.p props) []
  let create title = documentCardTitle [Title title]


[<RequireQualifiedAccess>]
module DocumentCardActivity =
  type People = {| name: string; profileImageSrc: string; initials: string |}
  type IDocumentCardActivityProps =
    | Props of IHTMLProp list
    | Activity of string
    | People of People []
    | ClassName of string
    | Styles of obj
    | Theme of ITheme
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let documentCardActivity props = ofImport "DocumentCardActivity" ImportPath (IDocumentCardActivityProps.p props)


[<RequireQualifiedAccess>]
module DocumentCardDetails =
  type IDocumentCardDetailsProps =
    | Props of IHTMLProp list
    | ClassName of string
    | Styles of obj
    | Theme of ITheme
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let documentCardDetails props = ofImport "DocumentCardDetails" ImportPath (IDocumentCardDetailsProps.p props)


[<RequireQualifiedAccess>]
module DocumentCard =
  type DocumentCardType = Normal = 0 | Compact = 2
  type IDocumentCardProps =
    | Props of IHTMLProp list
    | ClasName of string
    | OnClickHref of string
    | Role of string
    | Styles of obj
    | Theme of ITheme
    | Type of DocumentCardType
    | OnClick of (Browser.Types.Event -> unit)
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let documentCard props = ofImport "DocumentCard" ImportPath (IDocumentCardProps.p props)
  

[<RequireQualifiedAccess>]
module DocumentCardImage =
  type IDocumentCardImageProps =
    | Props of IHTMLProp list
    | ClassName of string
    | Height of int
    | IconProps of {| iconName: string |}
    //| ImageFit of Fit
    | ImageSrc of string
    | Styles of obj
    | Theme of ITheme
    | Width of int
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x
                               | x -> (x :> IHTMLProp) :: s) []
      |> kvl

  let documentCardImage props = ofImport "DocumentCardImage" ImportPath (IDocumentCardImageProps.p props)