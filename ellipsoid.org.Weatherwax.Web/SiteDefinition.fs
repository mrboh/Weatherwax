namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open ellipsoid.org.Weatherwax.Core.ClientDirectives
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.Sitelets

type AngularTemplate =
    | Master
    | Home
    | About
    | Music
    | Error of int

module Configuration =
    open CacheByAttribute
    open ellipsoid.org.SharpAngles
    open ellipsoid.org.Weatherwax.Core
    open System
    open System.Diagnostics
    open System.IO
    open System.Web
    open System.Web.Configuration

    [<JavaScript>]
    let AppName = "siteletApp"

    let SampleSettings =
        let appConfig = WebConfigurationManager.OpenWebConfiguration(null).AppSettings.Settings

        let boolSetting setting defaultValue =
            match appConfig.[setting] with
            | null -> defaultValue
            | s ->
                match bool.TryParse(s.Value) with
                | (true, b) -> b
                | (false, _) -> defaultValue

        let stringSetting setting defaultValue =
            match appConfig.[setting] with
            | null -> defaultValue
            | s -> s

        ()

        //        { new ISettings with
        //              member this.RequireTemplateAuthentication = boolSetting "requireTemplateAuthentication" true }

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