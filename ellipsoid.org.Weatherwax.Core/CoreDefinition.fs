namespace ellipsoid.org.Weatherwax.Core

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html.Server
open IntelliFactory.WebSharper.Sitelets
open System
open System.Collections.Generic

type WeatherwaxError =
    | Unspecified

type WeatherwaxAction =
    | [<CompiledName "">]            Index
    |                                Template of string * string list
    |                                Error of WeatherwaxError
    // | [<CompiledName "sitemap.xml">] Sitemap

type ISettings =
    abstract member ClientControl: IntelliFactory.WebSharper.Web.Control
    abstract member FileTemplateRootPath: string
    abstract member GenerateSnapshot: baseUrl: string -> fragment: string -> string
    abstract member MainHtmlPath: string
    abstract member TemplateHtmlPath: string

type TemplateFile =
    | Html of string
    // | Markdown of string

[<AbstractClass; JavaScript>]
type WeatherwaxController () =
    abstract member Name: string
    abstract member Implementation: obj
    member this.FromSourceFilename (f: string) =
        let startIndex = Math.Max (f.LastIndexOf '\\', f.LastIndexOf '/')               // startIndex = -1 means no path, only the filename
        f.Substring (startIndex + 1, f.Length - (Math.Max (startIndex, 0)) - 3)         // Remove the .fs extension

type WebsiteHelper<'TState when 'TState : equality> 
    (availableStates: WeatherwaxState<'TState> array, context) =
    
    member private this.SRefValue (value: string) = Html.NewAttribute "ui-sref" value
    member this.SRef (state: 'TState, [<ParamArray>] parameters: (string * string) array) =
        let paramSuffix =
            match parameters.Length with
                | 0 -> ""
                | _ ->
                    let suffixValue = 
                        parameters
                        |> Array.map (fun (name, value) ->
                            sprintf "%s: '%s'" name value
                        )
                        |> Array.fold (fun currentVal s -> match currentVal with | "" -> s | _ -> sprintf "%s, %s" currentVal s) ""
                    sprintf "({ %s })" suffixValue
        match Array.tryFind (fun (s: WeatherwaxState<'TState>) -> s.State = state) availableStates with
            | None -> this.SRefValue "(error: undefined state)"
            | Some s -> sprintf "%s%s" s.Name paramSuffix |> this.SRefValue
    member this.ControllerName (controllerType: Type) =
        let instance = Activator.CreateInstance(controllerType) :?> WeatherwaxController
        instance.Name

and Template<'TState when 'TState : equality> =
    | Inline of (IDictionary<string,string> * Context<WeatherwaxAction> * WebsiteHelper<'TState> -> Element list)
    | Static of TemplateFile

and [<AbstractClass>] WeatherwaxBaseState () =
    abstract member Name: string
    abstract member Url: string option
    abstract member UrlParametersToPassToTemplate: string list
    abstract member ControllerType: Type option
    abstract member CustomData: (string * string) list option

    default this.Url = None
    default this.UrlParametersToPassToTemplate = []
    default this.ControllerType = None
    default this.CustomData = None

    member this.FromSourceFilename f = 
        let filename = System.IO.FileInfo(f).Name
        filename.Substring (0, filename.Length - 3)     // Remove the .fs extension

and [<AbstractClass>] WeatherwaxState<'TState when 'TState : equality> () =
    inherit WeatherwaxBaseState ()
    abstract member State: 'TState
    abstract member Template: Template<'TState>

type ControllerDefinition =
    { Name: string
      Controller: obj }

type StateDefinition =
    { Name: string
      Url: string option
      UrlParametersToPassToTemplate: string list
      ControllerName: string option
      CustomData: (string * string) list option }

type StateWhen =
    { UrlIn: string
      UrlOut: string }

[<AbstractClass>]
type Parameter<'T> (name: string) =
    member this.Name with get () = name
    abstract member ReadValue: IDictionary<string,string> -> 'T

type StringParameter (name: string) =
    inherit Parameter<string> (name)
    override this.ReadValue urlParams = urlParams.[name]

type IntParameter (name: string) =
    inherit Parameter<int> (name)
    override this.ReadValue urlParams =
        let (success, result) = Int32.TryParse (urlParams.[name])
        if success then result else failwith "Parameter cannot be converted into an integer"

type FloatParameter (name: string) =
    inherit Parameter<float> (name)
    override this.ReadValue urlParams =
        let (success, result) = Double.TryParse (urlParams.[name])
        if success then result else failwith "Parameter cannot be converted into a float"

[<JavaScript>]
type InheritableProperty<'T> =
    { mutable value: 'T }