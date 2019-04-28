# fable-ui-fabric-react
Office UI Fabric (react) to Fable bindings


# Usage
This is currently under development and thus has no nuget package. To use

- Clone the project
- Add *ProjectReference* to your fable project
- Add *Fable.UiFabric.fsproj* as content
- Open *UiFabric* and use the components


# Example

```fsharp
let root model dispatch =
  div
    [ ]
    [ div []
        [ Button.defaultButton [] [ str "I'm a default button" ]
          Button.primaryButton [] [ str "I'm a primary button" ] ] 
      hr []
      div [] [ Icon.icon' Icons.Dictionary ]
      hr []
      Dialog.dialog
        [ Dialog.Hidden true
          Dialog.OnDismiss (fun _ -> printfn "Dismissed")
          Dialog.DialogContentProps
            [ Dialog.Title "Are you sure?"
              Dialog.SubText "This cannot be undone."
              Dialog.Type Dialog.DialogType.Normal ]
          Dialog.ModelProps
            [ Dialog.IsBlocking true] ]
        [ h1 [] [ str "Hello world" ]
          Dialog.dialogFooter
            [ Button.primaryButton [] [str "OK"]
              Button.defaultButton [] [str "Cancel"] ] ] ]
```
