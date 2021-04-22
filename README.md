# Fable.FluentUI
Fluent UI (react) Fable bindings

[![NuGet version (Fable.FluentUI)](https://img.shields.io/nuget/v/Fable.FluentUI.svg?style=flat-square)](https://www.nuget.org/packages/Fable.FluentUI/)

# Install

Install into your project using [Femto](https://github.com/Zaid-Ajaj/Femto) (recommended)
```bash
cd ./path/to/YourProject

# when using femto as a global CLI tool
femto install Fable.FluentUI

# when using femto as a local CLI tool
dotnet femto install Fable.FluentUI
```
This will install the nuget package and afterwards automatically installs the required npm packages used by this binding. 

> Femto will detect whether you are using paket and will install the package using paket into the dependency group of the project

You can install the library manually if you want by first installing the nuget package
```bash
cd ./path/to/YourProject
dotnet add package Fable.FluentUI
```
then installing the npm packages separately
```bash
npm install --save @fluentui/date-time-utilities@8.0.2 @fluentui/react@8.11.2 @fluentui/react-focus@8.0.7 @fluentui/react-icons@1.1.118
```
# Local Project Usage
This is a work-in-progress! 

To use the project locally (without nuget):

- Clone the project
- Add *ProjectReference* to your fable project
- Add *Fable.FluentUI.fsproj* as content
- Open *Fable.FluentUI* and use the components

# Icons

To use the icons, make sure to initialize them via your app entry point (usually Main.fs or App.fs):

```
Fable.FluentUI.Icons.initializeIcons()
```

# Examples
See the [wiki](https://github.com/JordanMarr/Fable.FluentUI/wiki) for examples of controls.


```fsharp
        div [] [ 
            div [] [ 
                Button.defaultButton [] [ str "I'm a default button" ]
                Button.primaryButton [] [ str "I'm a primary button" ] 
            ] 
            div [] [ 
                Icons.icon [
                    Icons.IconName "Link"
                    Icons.Props [Props.Style [Color "green"; FontSize "18px"]]
                ] []
            ]
            
            Dialog.dialog [ 
                Dialog.Hidden true
                Dialog.OnDismiss (fun _ -> printfn "Dismissed")
                Dialog.DialogContentProps [ 
                    Dialog.Title "Are you sure?"
                    Dialog.SubText "This cannot be undone."
                    Dialog.Type Dialog.DialogType.Normal 
                ]
                Dialog.ModalProps [ 
                    Dialog.IsBlocking true
                ] 
            ] [ 
                h1 [] [ str "Hello world" ]
                Dialog.dialogFooter [ 
                    Button.primaryButton [] [str "OK"]
                    Button.defaultButton [] [str "Cancel"] 
                ] 
            ] 
        ]
```
