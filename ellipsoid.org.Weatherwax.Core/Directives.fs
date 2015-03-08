namespace ellipsoid.org.Weatherwax.Core

open ellipsoid.org.Weatherwax.Core.Utilities
open IntelliFactory.WebSharper
open Microsoft.FSharp.Quotations
open System

[<JavaScript>]
module ClientDirectives =

    open IntelliFactory.WebSharper.Html.Client

    let NgView x = Tags.NewTag "ng-view" x
    let UIView x = Tags.NewTag "ui-view" x

    let NgBindHtml x = Attr.NewAttr "ng-bind-html" x
    let NgController x = Attr.NewAttr "ng-controller" x
    let NgClass x = Attr.NewAttr "ng-class" x
    let NgHide x = Attr.NewAttr "ng-hide" x
    let NgHref x = Attr.NewAttr "ng-href" x
    let NgRepeat x = Attr.NewAttr "ng-repeat" x
    let NgShow x = Attr.NewAttr "ng-show" x
    let NgSrc x = Attr.NewAttr "ng-src" x
    let SRef x = Attr.NewAttr "ui-sref" x

module ServerDirectives =

    open ellipsoid.org.SharpAngles
    open IntelliFactory.WebSharper.Html.Server
    open System

    let private bindingString formatString =
        function
            | Some s -> sprintf formatString s
            | None -> "{ binding error: cannot build binding string }"

    let NgView x = Html.NewElement "ng-view" x
    let UIView x = Html.NewElement "ui-view" x

    let NgBindHtml x = Html.NewAttribute "ng-bind-html" x
    let NgController x = Html.NewAttribute "ng-controller" x
    let NgClass x = Html.NewAttribute "ng-class" x
    let NgHide x = Html.NewAttribute "ng-hide" x
    let NgHref x = Html.NewAttribute "ng-href" x
    let NgRepeat x = Html.NewAttribute "ng-repeat" x
    let NgShow x = Html.NewAttribute "ng-show" x
    let NgSrc x = Html.NewAttribute "ng-src" x
    let SRef x = Html.NewAttribute "ui-sref" x
    
    let MemberBindingString (unitSelector: Expr<'T -> _>) =
        bindingString "%s" <| GetMemberName unitSelector

    let ClassBinding (unitSelector: Expr<'T -> _>) =
        MemberBindingString unitSelector |> NgClass

    let HideBinding (unitSelector: Expr<'T -> _>) =
        MemberBindingString unitSelector |> NgHide

    let ShowBinding (unitSelector: Expr<'T -> _>) =
        MemberBindingString unitSelector |> NgShow

    let TextBindingString (unitSelector: Expr<'T -> _>) =
        bindingString "{{ %s }}" <| GetMemberName unitSelector

    let TextBinding (unitSelector: Expr<'T -> _>) =
        TextBindingString unitSelector |> Text

    type NgRepeater<'TScope,'T when 'TScope :> Scope> (selector: Expr<'TScope -> 'T array>) =
        let variableName = "var" + Guid.NewGuid().ToString().Replace("-", "")
        let arrayName = GetMemberName selector
        let repeatString = 
            match arrayName with
                | Some s -> sprintf "%s in %s" variableName arrayName.Value
                | None -> sprintf "{ binding error: cannot build array name }"
        let repeaterBindingString formatString =
            function
                | Some s -> sprintf formatString variableName s
                | None -> "{ binding error: cannot build repeater binding string }"

        member this.RepeatString = repeatString
        member this.MemberBindingString (unitSelector: Expr<'T -> _>) =
            repeaterBindingString "%s.%s" <| GetMemberName unitSelector
        member this.TextBindingString (unitSelector: Expr<'T -> _>) =
            repeaterBindingString "{{ %s.%s }}" <| GetMemberName unitSelector
        member this.TextBinding (unitSelector: Expr<'T -> _>) =
            this.TextBindingString unitSelector |> Text