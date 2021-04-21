# Fable.FluentUI
Fluent UI (react) Fable bindings

# Setup

Install the following packages from NPM:

- "@fluentui/date-time-utilities": "^8.0.2"
- "@fluentui/react": "^8.11.2"
- "@fluentui/react-focus": "^8.0.7"
- "@fluentui/react-icons": "^1.1.118"

# Usage
This is currently under development and thus has no nuget package. To use

- Clone the project
- Add *ProjectReference* to your fable project
- Add *Fable.FluentUI.fsproj* as content
- Open *Fable.FluentUI* and use the components


# Example

```fsharp
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
