namespace ellipsoid.org.Weatherwax.Core

open ellipsoid.org.SharpAngles
open ellipsoid.org.Weatherwax.Core
open IntelliFactory.Html
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Sitelets
open System
open System.IO
open System.Web

type Action<'T> =
    | [<CompiledName "">] Index
    |                     Template of 'T

type WebSharperTemplateBase =
    { Body: Content.HtmlElement list }

type AngularTemplateBase =
    { Content: Content.HtmlElement list }

type AngularWebsite<'TTemplate,'TController when 'TTemplate : equality and 'TController : equality> (settings: ISettings<'TTemplate,'TController>) =
    let appTemplate =
        Content.Template<WebSharperTemplateBase>(settings.MainHtmlPath)
            .With ("body", fun template -> template.Body)
    let angularTemplate =
        Content.Template<AngularTemplateBase>(settings.TemplateHtmlPath)
            .With ("content", fun template -> template.Content)
    interface IWebsite<Action<'TTemplate>> with
        member this.Sitelet = 
            Sitelet.Infer <| function
                | Index ->
                    let req = HttpContext.Current.Request
                    match req.QueryString.["_escaped_fragment_"] with
                        | null ->
                            Content.WithTemplate appTemplate <| fun ctx ->
                                { Body = [ Div [ settings.ClientControl ] ] }
                        | fragment ->
                            let baseUrl = req.Url.GetLeftPart(UriPartial.Authority)
                            let snapshot = settings.GenerateSnapshot baseUrl fragment
                            CustomContent <| fun context ->
                                { Status = Http.Status.Ok
                                  Headers = [ Http.Header.Custom "Content-Type" "text/plain" ]  // text/html
                                  WriteBody = fun stream ->
                                      use streamWriter = new StreamWriter (stream)
                                      streamWriter.Write snapshot }
                | Template templateId ->
                    let templateInfo = settings.TemplateImplementation templateId
                    match templateInfo with
                        | Inline templateContent ->
                            Content.WithTemplate angularTemplate <| fun ctx ->
                                let headers = ctx.Request.Headers
                                { Content = templateContent }
                        | Static staticType ->
                            CustomContent <| fun context ->
                                { Status = Http.Status.Ok  
                                  Headers = [ Http.Header.Custom "Content-Type" "text/ng-template" ]
                                  WriteBody = fun stream ->
                                      let withTrailingSlash (s: string) = match s with | withSlash when withSlash.EndsWith ("/") -> withSlash | withoutSlash -> withoutSlash + "/"
                                      let getLocalPath p = HttpContext.Current.Server.MapPath (withTrailingSlash settings.FileTemplateRootPath + p)
                                      use streamWriter = new StreamWriter (stream)
                                      match staticType with
                                          | Html filename ->
                                              let localPath = getLocalPath filename
                                              use textReader = new StreamReader (localPath)
                                              streamWriter.Write (textReader.ReadToEnd ()) }
        member this.Actions = []