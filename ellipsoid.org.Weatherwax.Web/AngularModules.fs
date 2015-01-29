namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open IntelliFactory.WebSharper
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.Utilities
open ellipsoid.org.Weatherwax.Web.AngularConfiguration
open ellipsoid.org.Weatherwax.Web.AngularControllers
open ellipsoid.org.Weatherwax.Web.AngularRouter

[<JavaScript>]
module AngularModules =
    open System.Collections.Generic

    let SiteletApp = 
        Angular.Module(Configuration.AppName, [| Dependencies.Router; Dependencies.UIRouter |])
               .Config(UrlConfiguration)
               .Config(UIRouterConfiguration)
               .Config(RouteConfiguration)  // RouteConfiguration routerConfig
               .Controllers(ControllerConfiguration)