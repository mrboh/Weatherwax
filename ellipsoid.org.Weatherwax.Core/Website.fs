namespace ellipsoid.org.Weatherwax.Core

open ellipsoid.org.SharpAngles
open IntelliFactory.Html
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Sitelets
open System
open System.IO
open System.Web

module WsClientOps = IntelliFactory.WebSharper.Html.Operators

type Action<'T> =
    | [<CompiledName "">] Index
    |                     Template of 'T

type WebSharperTemplateBase =
    { Body: Content.HtmlElement list }

type AngularTemplateBase =
    { Content: Content.HtmlElement list }

type ISettings<'T when 'T : equality> =
    abstract member GenerateSnapshot: baseUrl: string -> fragment: string -> string
    abstract member MainHtmlPath: string
    abstract member ClientControl: Web.Control
    abstract member TemplateHtmlPath: string
    abstract member TemplateImplementation: 'T -> Element<_> list

type AngularWebsite<'T when 'T : equality> (settings: ISettings<'T>) =
    let appTemplate =
        Content.Template<WebSharperTemplateBase>(settings.MainHtmlPath)
            .With ("body", fun template -> template.Body)
    let angularTemplate =
        Content.Template<AngularTemplateBase>(settings.TemplateHtmlPath)
            .With ("content", fun template -> template.Content)
    interface IWebsite<Action<'T>> with
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
                    Content.WithTemplate angularTemplate <| fun ctx ->
                        let headers = ctx.Request.Headers
                        { Content = settings.TemplateImplementation templateId }
        member this.Actions = []

    