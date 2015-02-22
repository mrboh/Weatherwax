namespace ellipsoid.org.Weatherwax.Web

open CacheByAttribute
open ellipsoid.org.SharpAngles
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.ClientDirectives
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.Sitelets
open System
open System.Diagnostics
open System.IO
open System.Web
open System.Web.Configuration

(*
    Note
    ====

    If copying this sample application, don't forget to remove the references to the following assemblies
    and install the corresponding NuGet packages:

    - ellipsoid.org.Weatherwax.Core
*)

type AngularTemplate =
    | Master
    | Home
    | About
    | Music
    | Error of int

type AngularController =
    | Base
    | Home
    | About
    | Music
    | Error

[<JavaScript>]
type StateImplementation (url, template, ?controller) =
    interface IState<AngularTemplate,AngularController> with
        member this.Url = url
        member this.Template = template
        member this.Controller = controller

module Configuration =

    [<JavaScript>]
    let AppName = "siteletApp"

    [<Cache(ExpiryHours = 24)>]
    let PhantomJsSnapshot baseUrl fragment =
        async {
            // As (somewhat) per http://stackoverflow.com/questions/18530258/how-to-make-a-spa-seo-crawlable
            let appRoot = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)
            let appPath = Path.Combine(appRoot, "App_Data\\PhantomJs\\phantomjs.exe")
            let optionsPath = Path.Combine(appRoot, "App_Data\\PhantomJs\\snapshot.js")
            let fragmentUrl = sprintf "%s/#!/%s" baseUrl fragment
            let startInfo =
                ProcessStartInfo
                    (Arguments = sprintf "--load-images=false --ignore-ssl-errors=true --ssl-protocol=any %s %s"
                                     optionsPath fragmentUrl, FileName = appPath, UseShellExecute = false,
                     CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true,
                     RedirectStandardInput = true, StandardOutputEncoding = System.Text.Encoding.UTF8)
            let phantomJsProcess = new Process(StartInfo = startInfo)
            let startResult = phantomJsProcess.Start()
            let output = phantomJsProcess.StandardOutput.ReadToEnd()
            let stopResult = phantomJsProcess.WaitForExit(10000)

            // WebSharper uses non-HTML-encoded strings in its meta tags (specifically the "generator" tag)
            // but the spec (and what PhantomJs produces) is to use HTML-encoded strings. Therefore the output
            // from this method will generate JS errors if viewed in a web browser but should be sufficient
            // from the point of view of a crawler.
            return output
        }
        |> Async.RunSynchronously