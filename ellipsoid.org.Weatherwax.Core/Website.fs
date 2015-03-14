namespace ellipsoid.org.Weatherwax.Core

open ellipsoid.org.Weatherwax.Core.Utilities
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Sitelets
open IntelliFactory.WebSharper.Html.Server
open ServerDirectives
open System
open System.IO
open System.Web

type WebSharperTemplateBase =
    { Body: Element list }

type AngularTemplateBase =
    { Content: Element list }

type WeatherwaxWebsite<'TState when 'TState : equality> (settings: ISettings) =    
    let weatherwaxRpcHandlerFactory =
        { new IRpcHandlerFactory with
              member this.Create t =
                  match t with
                      | tt when tt = typeof<UntypedStateManager> -> Some <| (UntypedStateManager.Instance :> _)
                      | _ -> None }
    do SetRpcHandlerFactory weatherwaxRpcHandlerFactory
    let stateManager = Utilities.StateManager.Instance
    interface IWebsite<WeatherwaxAction> with
        member this.Actions = []
        member this.Sitelet =
            let appTemplate =
                Content.Template<WebSharperTemplateBase>(settings.MainHtmlPath)
                    .With ("body", fun template -> template.Body)
            let angularTemplate =
                Content.Template<AngularTemplateBase>(settings.TemplateHtmlPath)
                    .With ("content", fun template -> template.Content)
            Sitelet.Infer <| function
                | Index ->
                    let req = HttpContext.Current.Request
                    match req.QueryString.["_escaped_fragment_"] with
                        | null ->
                            Content.WithTemplate appTemplate <| fun context ->
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
                | Template (templateId, args) ->
                    let stateInfo =
                        match stateManager.FindState templateId with
                            | None -> failwith "Template not found"
                            | Some s ->
                                match args.Length with
                                    | l when l = s.UrlParametersToPassToTemplate.Length -> s
                                    | _ -> failwith "Incorrect number of arguments"
                    let templateInfo = stateInfo.Template
                    let templateArgs =
                        args
                        |> List.mapi (fun n a -> (stateInfo.UrlParametersToPassToTemplate.[n], a))
                        |> dict
                    match templateInfo with
                        | Inline templateContent ->
                            Content.WithTemplate angularTemplate <| fun context ->
                                let helper = WebsiteHelper<'TState> (stateManager.AvailableObjects, context)
                                { Content = templateContent (templateArgs, context, helper) }
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
                | Error errorType ->
                    CustomContent <| fun context ->
                        { Status = Http.Status.Ok
                          Headers = [ Http.Header.Custom "Content-Type" "text/plain" ]
                          WriteBody = fun stream ->
                              use streamWriter = new StreamWriter (stream)
                              let message =
                                  match errorType with
                                      | Unspecified -> "Unspecified error"
                              let fullMessage = sprintf "Weatherwax Error: %s" message
                              streamWriter.Write fullMessage }
    //                | Sitemap ->
    //                    CustomContent <| fun context ->
    //                        { Status = Http.Status.Ok
    //                          Headers = [ Http.Header.Custom "Content-Type" "text/xml" ]
    //                          WriteBody = fun stream ->
    //                              let xmlDoc = new XmlDocument ()
    //                              let xmlRootNode = xmlDoc.CreateElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9")
    //                              xmlDoc.AppendChild (xmlRootNode) |> ignore
    //                              xmlDoc.Save (stream) }