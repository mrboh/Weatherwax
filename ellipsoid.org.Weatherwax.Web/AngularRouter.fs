namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open ellipsoid.org.SharpAngles.Route
open ellipsoid.org.SharpAngles.UI
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.Dependencies
open ellipsoid.org.Weatherwax.Web.AngularControllers
open ellipsoid.org.Weatherwax.Web.AngularTemplates
open IntelliFactory.WebSharper
open System.Collections.Generic

[<JavaScript>]
module AngularRouter =

    type ErrorRouteParameters =
        { id: int }

    type T = AngularTemplate
    type C = AngularController

    let TemplateUrl t = "Template/" + TemplateRelativePath t
    let ControllerName controller =
        match List.tryFind (fun c -> c.Controller = controller) ControllerConfiguration.Controllers with
            | Some c -> c.Name
            | None -> failwith "Controller not defined in ControllerConfiguration"

    let RouteConfiguration =
        AngularExpression2<_,_>(Providers.State, Providers.UrlRouter).Resolve(
            fun (stateProvider, urlRouterProvider) ->
                stateProvider
                
                    // UI-Router can use nested states; we define a master state which is the parent for all other states
                    .State("master", StateConfig(Abstract = true, TemplateUrl = TemplateUrl Master))

                    // Other states
                    .State("master.home",       StateConfig(Url = "^/",         TemplateUrl = TemplateUrl T.Home,      Controller = ControllerName C.Home))
                    .State("master.about",      StateConfig(Url = "^/about",    TemplateUrl = TemplateUrl T.About,     Controller = ControllerName C.About))
                    .State("master.music",      StateConfig(Url = "^/music",    TemplateUrl = TemplateUrl T.Music,     Controller = ControllerName C.Music))
                    .State("master.error",
                        StateConfig(
                            Url = "^/error/{id}",
                            TemplateUrl = (fun (p: ErrorRouteParameters) -> TemplateUrl (T.Error p.id)),
                            Controller = ControllerName C.Error
                        ))
                    |> ignore

                // Default to front page
                urlRouterProvider.When ("", "/") |> ignore

                // If route not found
                urlRouterProvider.Otherwise ("/error/404") |> ignore
        )