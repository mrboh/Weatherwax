namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.ClientDirectives
open ellipsoid.org.Weatherwax.Web.Configuration
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
    interface ISettings<AngularTemplate> with
        member this.ClientControl = new AngularEntryPoint () :> _
        member this.GenerateSnapshot baseUrl fragment = PhantomJsSnapshot baseUrl fragment
        member this.MainHtmlPath = "~/Main.html"
        member this.TemplateHtmlPath = "~/Template.html"
        member this.TemplateImplementation templateId = AngularTemplates.TemplateImplementation templateId

type Website () =
    inherit AngularWebsite<AngularTemplate> (Settings ())
    
type Global() =
    inherit System.Web.HttpApplication()
    member g.Application_Start(sender: obj, args: System.EventArgs) =
        ()

[<assembly: Website(typeof<Website>)>]
do ()