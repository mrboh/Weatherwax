namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open ellipsoid.org.SharpAngles.UI
open IntelliFactory.WebSharper

[<JavaScript>]
module AngularConfiguration =

    let UrlConfiguration =
        ("$locationProvider",
            fun (locationProvider: LocationProvider) ->
                locationProvider
                    .Html5Mode(false)
                    .HashPrefix("!")
        )

    let UIRouterConfiguration =
        ("$urlMatcherFactoryProvider",
            fun (urlMatcherFactory: UrlMatcherFactory) ->       
                urlMatcherFactory.CaseInsensitive(true) |> ignore       
                urlMatcherFactory.StrictMode(false) |> ignore
        )