namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open IntelliFactory.WebSharper
open ellipsoid.org.Weatherwax.Web.AngularConfiguration
open ellipsoid.org.Weatherwax.Web.AngularControllers
open ellipsoid.org.Weatherwax.Web.AngularRouter

[<JavaScript>]
module AngularModules =

    let SiteletApp = 
        Angular.Module(Configuration.AppName, [| AngularDependencies.UIRouter |])
               .Config(UrlConfiguration)
               .Config(UIRouterConfiguration)
               .Config(RouteConfiguration)
               .Controller("BaseController", BaseController)
               .Controller("HomeController", HomeController)
               .Controller("AboutController", AboutController)
               .Controller("MusicController", MusicController)
               .Controller("ErrorController", ErrorController)