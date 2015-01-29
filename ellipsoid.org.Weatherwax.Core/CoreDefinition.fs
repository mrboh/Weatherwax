namespace ellipsoid.org.Weatherwax.Core

open IntelliFactory.Html
open IntelliFactory.WebSharper
open System.Collections.Generic

[<JavaScript>]
type ControllerInfo<'T when 'T : equality> =
    { Controller: 'T
      Name: string
      Implementation: obj }

[<JavaScript>]
type ControllerConfiguration<'T when 'T : equality> () =
    let mutable _controllers: ControllerInfo<'T> list = []
    member this.Controllers with get() = _controllers
    member this.DefineController (controller, name, implementation) =
        // Check if controller has already been defined
        match List.tryFind (fun c -> c.Controller = controller) _controllers with
            | Some c -> failwith "Controller has already been defined"
            | None -> _controllers <- List.append [ { Controller = controller; Name = name; Implementation = implementation } ] _controllers
        this
    member this.ControllerName controller =
        match List.tryFind (fun c -> c.Controller = controller) _controllers with
            | Some c -> c.Name
            | None -> failwith "Controller not defined in ControllerConfiguration"

type TemplateFile =
    | Html of string
    // | Markdown of string

type Template<'a> =
    | Inline of Element<'a> list
    | Static of TemplateFile

type ISettings<'TTemplate,'TController when 'TTemplate : equality and 'TController : equality> =
    abstract member ClientControl: Web.Control
    abstract member ControllerConfiguration: ControllerConfiguration<'TController>
    abstract member FileTemplateRootPath: string
    abstract member GenerateSnapshot: baseUrl: string -> fragment: string -> string
    abstract member MainHtmlPath: string
    abstract member TemplateHtmlPath: string
    abstract member TemplateRelativePath: 'TTemplate -> string
    abstract member TemplateImplementation: 'TTemplate -> Template<_>