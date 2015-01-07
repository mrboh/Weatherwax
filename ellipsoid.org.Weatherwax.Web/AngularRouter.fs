namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open ellipsoid.org.SharpAngles.Route
open ellipsoid.org.SharpAngles.UI
open IntelliFactory.WebSharper

[<JavaScript>]
module AngularRouter =

    type ErrorRouteParameters =
        { id: int }

    let RouteConfiguration =
        ("$stateProvider", "$urlRouterProvider",
            fun (stateProvider: StateProvider, urlRouterProvider: UrlRouterProvider) ->
                stateProvider

                    // UI-Router can use nested states; we define a master state which is the parent for all other states
                    .State("master", StateConfig(Abstract = true, TemplateUrl = "Template/Master"))

                    // Other states
                    .State("master.home",       StateConfig(Url = "^/",         TemplateUrl = "Template/Home",      Controller = "HomeController"))
                    .State("master.about",      StateConfig(Url = "^/about",    TemplateUrl = "Template/About",     Controller = "AboutController"))
                    .State("master.music",      StateConfig(Url = "^/music",    TemplateUrl = "Template/Music",     Controller = "MusicController"))
                    .State("master.error",
                        StateConfig(
                            Url = "^/error/{id}",
                            TemplateUrl = (fun (p: ErrorRouteParameters) -> sprintf "Template/Error/%d" p.id),
                            Controller = "ErrorController"
                        ))
                    |> ignore

                // Default to front page
                urlRouterProvider.When ("", "/") |> ignore

                // If route not found
                urlRouterProvider.Otherwise ("/error/404") |> ignore
        )