namespace ellipsoid.org.Weatherwax.Web

open AngularConfiguration
open ellipsoid.org.SharpAngles
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.ClientDirectives
open ellipsoid.org.Weatherwax.Core.Dependencies
open ellipsoid.org.Weatherwax.Core.Utilities
open ellipsoid.org.Weatherwax.Web.Controllers
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html.Client
open IntelliFactory.WebSharper.JavaScript
open IntelliFactory.WebSharper.JQuery
open IntelliFactory.WebSharper.Sitelets
open System.Web

type StateDefinitionService =
    { States: StateDefinition array }

type private AngularEntryPoint () =
    inherit Web.Control ()

    [<JavaScript>]
    override __.Body =
        Div [ Attr.Id "angular-sitelet-root"; NgController "BaseController" ] -< [ UIView [] ]
        |>! OnAfterRender (fun el -> 
            async {
                // Get state definition
                let! stateDefinition = UntypedStateManager.Instance.StateDefinition ()

                // Generate module
                Angular.Module(Configuration.AppName, [| Dependencies.Router; Dependencies.UIRouter |])
                       .Config(UrlConfiguration)
                       .Config(UIRouterConfiguration)
                       .States(stateDefinition, Some "/error/404", [| { UrlIn = ""; UrlOut = "/" } |])
                       .Controllers([ BaseController (); HomeController (); AboutController (); MusicController (); ErrorController () ])
                |> ignore
                        
                // Bootstrap site
                Angular.Bootstrap(el.Dom, [| Configuration.AppName |]) |> ignore
            } |> Async.Start
        ) :> _
        
type Settings () =
    interface ISettings with
        member this.ClientControl = new AngularEntryPoint () :> _
        member this.FileTemplateRootPath = "~/App_Data/Template"
        member this.GenerateSnapshot baseUrl fragment = Configuration.PhantomJsSnapshot baseUrl fragment
        member this.MainHtmlPath = "~/Main.html"
        member this.TemplateHtmlPath = "~/Template.html"
            
type Website () =
    inherit WeatherwaxWebsite<AngularState,AngularController> (Settings ())

type Global() =
    inherit HttpApplication ()
    member g.Application_Start(sender: obj, args: System.EventArgs) =
        ()

[<assembly: Website(typeof<Website>)>]
do ()