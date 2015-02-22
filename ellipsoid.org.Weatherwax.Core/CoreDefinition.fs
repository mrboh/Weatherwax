namespace ellipsoid.org.Weatherwax.Core

open IntelliFactory.WebSharper.Html.Server
open IntelliFactory.WebSharper
open System.Collections.Generic

[<JavaScript>]
type InheritableProperty<'T> =
    { mutable value: 'T }
        
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

[<JavaScript>]
type StateTemplateReference<'TTemplate when 'TTemplate : equality> =
    | Direct of 'TTemplate
    | Parameterised of (obj -> string)

type IState<'TTemplate,'TController when 'TTemplate : equality and 'TController : equality> =
    abstract Url: string option
    abstract Template: StateTemplateReference<'TTemplate>
    abstract Controller: 'TController option

//[<JavaScript>]
//[<AbstractClass>]
//type State<'TTemplate,'TController when 'TTemplate : equality and 'TController : equality> (url, template, controller) =
//    member val Url: string option = url
//    member val Template: StateTemplateReference<'TTemplate> = template
//    member val Controller: 'TController option = controller

[<JavaScript>]
type StateInfo<'TTemplate,'TController,'TState when 'TTemplate : equality and 'TController : equality and 'TState : equality> =
    { State: 'TState
      Name: string
      Implementation: IState<'TTemplate,'TController>}

[<JavaScript>]
type StateConfiguration<'TTemplate,'TController,'TState when 'TTemplate : equality and 'TController : equality and 'TState : equality> (nameMapper: 'TState -> string) =
    let mutable _states: StateInfo<'TTemplate,'TController,'TState> list = []
    let mutable _whens: (string * string) list = []
    let mutable _otherwise: string option = None

    member this.States with get() = _states
    member this.Whens with get() = _whens
    member this.DefineState (state: 'TState, implementation: IState<'TTemplate,'TController>) =
        let name = nameMapper state

        // Check if state has already been defined
        match List.tryFind (fun s -> s.Name = name) _states with
            | Some s -> failwith "State has already been defined"
            | None -> _states <- List.append [ { State = state; Name = name; Implementation = implementation } ] _states
        this
//    member this.StateName state =
//        match List.tryFind (fun s -> s.State = state) _states with
//            | Some s -> nameMapper state
//            | None -> failwith "State not defined in StateConfiguration"
    member this.When (whenPath: string, toPath: string) =
        _whens <- List.append [ (whenPath, toPath) ] _whens
        this
    member this.Otherwise () = _otherwise
    member this.Otherwise (path: string) = 
        _otherwise <- Some path
        this

type TemplateFile =
    | Html of string
    // | Markdown of string

type Template =
    | Inline of Element list
    | Static of TemplateFile

type ISettings<'TTemplate,'TController,'TState when 'TTemplate : equality and 'TController : equality and 'TState : equality> =
    abstract member ClientControl: Web.Control
    abstract member ControllerConfiguration: ControllerConfiguration<'TController>
    abstract member FileTemplateRootPath: string
    abstract member GenerateSnapshot: baseUrl: string -> fragment: string -> string
    abstract member MainHtmlPath: string
    abstract member StateConfiguration: StateConfiguration<'TTemplate,'TController,'TState>
    abstract member TemplateHtmlPath: string
    abstract member TemplateRelativePath: 'TTemplate -> string
    abstract member TemplateImplementation: 'TTemplate -> Template