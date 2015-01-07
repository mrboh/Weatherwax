namespace ellipsoid.org.Weatherwax.Core

open IntelliFactory.WebSharper
open Microsoft.FSharp.Linq
open Microsoft.FSharp.Linq.RuntimeHelpers
open Microsoft.FSharp.Quotations
open Microsoft.FSharp.Quotations.Patterns
open System
open System.Linq.Expressions
open System.Reflection

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

    let rec private GetMemberName = function
        | Lambda (_, lambdaInfo) -> GetMemberName lambdaInfo
        | Value (_, valueInfo) -> valueInfo.Name
        | FieldGet (_,fieldInfo) -> fieldInfo.Name
        | Call (_,methodInfo,_) -> methodInfo.Name
        | PropertyGet (_,propertyInfo,_) -> propertyInfo.Name
        | _ -> failwith "Not a member expression"

    type NgRepeater<'TScope,'T when 'TScope :> Scope> (selector: Expr<'TScope -> 'T array>) =
        let variableName = "var" + Guid.NewGuid().ToString().Replace("-", "")
        let arrayName = GetMemberName selector
        let repeatString = sprintf "%s in %s" variableName arrayName

        member this.RepeatString = repeatString
        member this.TextBinding (unitSelector: Expr<'T -> _>) =
            sprintf "{{ %s.%s }}" variableName (GetMemberName unitSelector) |> Text

    let NgView x = Html.NewElement "ng-view" x
    let UIView x = Html.NewElement "ui-view" x

    let NgRepeat x = Html.NewAttribute "ng-repeat" x
    let SRef x = Html.NewAttribute "ui-sref" x