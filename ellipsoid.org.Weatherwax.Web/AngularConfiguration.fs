namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open ellipsoid.org.SharpAngles.UI
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.Dependencies
open IntelliFactory.WebSharper

[<JavaScript>]
module AngularConfiguration =

    let UrlConfiguration =
        AngularExpression1<_>(Providers.Location).Resolve(
            fun locationProvider ->
                locationProvider
                    .Html5Mode(false)
                    .HashPrefix("!")
        )

    let UIRouterConfiguration =
        AngularExpression1<_>(Providers.UrlMatcherFactory).Resolve(
            fun urlMatcherFactory ->
                urlMatcherFactory.CaseInsensitive(true) |> ignore
                urlMatcherFactory.StrictMode(false) |> ignore
        )