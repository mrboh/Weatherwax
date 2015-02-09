namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open IntelliFactory.WebSharper
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.Utilities

open AngularConfiguration
open AngularControllers
open AngularRouter
open AngularStates
open AngularTemplates

[<JavaScript>]
module AngularModules =
    open System.Collections.Generic

    let SiteletApp = 
        Angular.Module(Configuration.AppName, [| Dependencies.Router; Dependencies.UIRouter |])
               .Config(UrlConfiguration)
               .Config(UIRouterConfiguration)
               .States(StateConfiguration, AngularStateName, TemplateRelativePath, ControllerConfiguration)
               .Controllers(ControllerConfiguration)