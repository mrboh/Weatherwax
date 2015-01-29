namespace ellipsoid.org.Weatherwax.Core

open ellipsoid.org.Weatherwax.Core.Utilities
open IntelliFactory.WebSharper
open Microsoft.FSharp.Quotations
open System

[<JavaScript>]
module ClientDirectives =

    open IntelliFactory.WebSharper.Html

    let NgView x = Tags.NewTag "ng-view" x
    let UIView x = Tags.NewTag "ui-view" x

    let NgController x = Attr.NewAttr "ng-controller" x
    let NgRepeat x = Attr.NewAttr "ng-repeat" x
    let SRef x = Attr.NewAttr "ui-sref" x

module ServerDirectives =

    open ellipsoid.org.SharpAngles
    open IntelliFactory.Html
    open System

    let private bindingString =
        function
            | Some s -> sprintf "{{ %s }}" s
            | None -> "{ binding error: cannot build binding string }"

    let TextBinding (unitSelector: Expr<'T -> _>) =
        bindingString <| GetMemberName unitSelector |> Text

    type NgRepeater<'TScope,'T when 'TScope :> Scope> (selector: Expr<'TScope -> 'T array>) =
        let variableName = "var" + Guid.NewGuid().ToString().Replace("-", "")
        let arrayName = GetMemberName selector
        let repeatString = 
            match arrayName with
                | Some s -> sprintf "%s in %s" variableName arrayName.Value
                | None -> sprintf "{ binding error: cannot build array name }"
        let repeaterBindingString =
            function
                | Some s -> sprintf "{{ %s.%s }}" variableName s
                | None -> "{ binding error: cannot build repeater binding string }"

        member this.RepeatString = repeatString
        member this.TextBinding (unitSelector: Expr<'T -> _>) =
            repeaterBindingString <| GetMemberName unitSelector |> Text

    let NgView x = Html.NewElement "ng-view" x
    let UIView x = Html.NewElement "ui-view" x

    let NgController x = Html.NewAttribute "ng-controller" x
    let NgRepeat x = Html.NewAttribute "ng-repeat" x
    let SRef x = Html.NewAttribute "ui-sref" x