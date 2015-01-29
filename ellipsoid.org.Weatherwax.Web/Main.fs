namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.ClientDirectives
open ellipsoid.org.Weatherwax.Web.Configuration
open ellipsoid.org.Weatherwax.Web.AngularControllers
open ellipsoid.org.Weatherwax.Web.AngularTemplates
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.Sitelets
open System.Web

type private AngularEntryPoint () =
    inherit Web.Control ()

    [<JavaScript>]
    override __.Body =
        Div [ Attr.Class "angular-sitelet-root"; NgController "BaseController" ] -< [ UIView [] ]
        |>! OnAfterRender (fun el -> Angular.Bootstrap(el.Body, [| Configuration.AppName |]) |> ignore)
        :> _
        
type private Settings () =
    interface ISettings<AngularTemplate,AngularController> with
        member this.ClientControl = new AngularEntryPoint () :> _
        member this.ControllerConfiguration = ControllerConfiguration
        member this.FileTemplateRootPath = "~/App_Data/Template"
        member this.GenerateSnapshot baseUrl fragment = PhantomJsSnapshot baseUrl fragment
        member this.MainHtmlPath = "~/Main.html"
        member this.TemplateHtmlPath = "~/Template.html"
        member this.TemplateImplementation templateId = TemplateImplementation templateId
        member this.TemplateRelativePath template = TemplateRelativePath template

type Website () =
    inherit AngularWebsite<AngularTemplate,AngularController> (Settings ())
    
type Global() =
    inherit System.Web.HttpApplication()
    member g.Application_Start(sender: obj, args: System.EventArgs) =
        ()

[<assembly: Website(typeof<Website>)>]
do ()