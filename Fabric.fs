namespace Fable.FluentUI


open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props
open Utils


[<RequireQualifiedAccess>]
module Fabric =
  type IFabricProps =
    | Props of IHTMLProp list
    interface IHTMLProp
    static member p props =
      props
      |> List.fold (fun s x -> match x with
                               | Props x -> s @ x) []
                               //| x -> (x :> IHTMLProp) :: s) [] 
      |> kvl

  let fabric props = ofImport "Fabric" ImportPath (IFabricProps.p props)




[<AutoOpen>]
module General =
  let customizer p els = ofImport "Customizer" ImportPath p els

  // Causes compile warning: 
  // export 'FluentCustomizations' was not found in '@fluentui/theme'
  //let FluentCustomizations = importMember<obj> "@fluentui/theme" 

