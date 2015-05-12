namespace ellipsoid.org.Weatherwax.Core

open ellipsoid.org.Weatherwax.Core.Dependencies
open ellipsoid.org.SharpAngles
open ellipsoid.org.SharpAngles.UI
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.JavaScript
open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Reflection
open System
open System.Collections.Generic

module Utilities =

    type System.Reflection.Assembly with
        member this.GetLoadableTypes () =
            try
                this.GetTypes ()
            with
                | :? System.Reflection.ReflectionTypeLoadException as ex -> 
                    ex.Types
                    |> Array.filter (fun t -> t <> null)
                | _ -> [||]

    [<AbstractClass>]
    type CommonObjectManager<'T> () =
        let _availableObjects =
            AppDomain.CurrentDomain.GetAssemblies ()
            |> Array.map (fun a -> a.GetLoadableTypes ())
            |> Array.concat
            |> Array.filter (fun t -> t.IsClass && not t.IsAbstract && t.IsSubclassOf (typeof<'T>))
            |> Array.map (fun t -> Activator.CreateInstance (t) :?> 'T)
        member this.AvailableObjects with get () = _availableObjects

    type UntypedControllerManager private () =
        inherit CommonObjectManager<WeatherwaxController> ()
//        let _availableObjects =
//            AppDomain.CurrentDomain.GetAssemblies ()
//            |> Array.map (fun a -> a.GetLoadableTypes ())
//            |> Array.concat
//            |> Array.filter (fun t -> t.IsClass && not t.IsAbstract && t.IsGenericType && t.Name = (typedefof<WeatherwaxTypedController<_>>.Name))
//            |> Array.map (fun t -> Activator.CreateInstance (t))
        static let _instance = UntypedControllerManager ()
        static member Instance with get () = _instance

        // member this.AvailableObjects with get () = _availableObjects
//        member this.ControllerName ctrl =
//            let controller = 
//                this.AvailableObjects
//                |> Array.tryFind (fun c -> (c :?> WeatherwaxTypedController<_>).Controller = ctrl)
//            match controller with
//                | None -> failwith "Unknown controller"
//                | Some c -> (c :?> WeatherwaxTypedController<_>).Name
//        member this.ControllerName controllerType =
//            let controller = 
//                this.AvailableObjects
//                |> Array.tryFind (fun c -> c.GetType () = controllerType)
//            match controller with
//                | None -> failwith "Unknown controller"
//                | Some c -> c.Name

//        [<Rpc>]
//        member this.ControllerDefinition () =
//            async {
//                return
//                    this.AvailableObjects
//                    |> Array.map (fun c ->
//                        let ctrl = c :?> WeatherwaxTypedController<_>
//                        { Name = ctrl.Name
//                          Controller = ctrl.Controller :> obj }
//                    )
//            }

//    type ControllerManager<'TController when 'TController : equality> private () =
//        inherit CommonObjectManager<WeatherwaxController<'TController>> ()
//        static let _instance = ControllerManager<'TController> ()
//        static member Instance with get () = _instance
//        member this.FindController controller =
//            this.AvailableObjects
//            |> Array.tryFind (fun c -> c.Name = controller)

    type UntypedStateManager private () =
        inherit CommonObjectManager<WeatherwaxBaseState> ()
        static let _instance = UntypedStateManager ()
        static member Instance with get () = _instance

        [<Rpc>]
        member this.StateDefinition () =
            async {
                return 
                    this.AvailableObjects
                    |> Array.map (fun s ->
                        { Name = s.Name
                          Url = s.Url
                          UrlParametersToPassToTemplate = s.UrlParametersToPassToTemplate
                          ControllerName = 
                              match s.ControllerType with 
                                  | None -> None
                                  | Some t ->
                                      Some (Activator.CreateInstance(t) :?> WeatherwaxController).Name
                          CustomData = s.CustomData }
                    )
            }

    type StateManager<'TState when 'TState : equality> private () =
        inherit CommonObjectManager<WeatherwaxState<'TState>> ()
        static let _instance = StateManager<'TState> ()
        static member Instance with get () = _instance
        member this.FindState state =
            this.AvailableObjects
            |> Array.tryFind (fun s -> s.Name = state)

    type Module with
        [<JavaScript>]
        member this.Controller (controller: WeatherwaxController) =
            this.Controller(controller.Name, controller.Implementation) |> ignore
            this

        [<JavaScript>]
        member this.Controllers (controllers: WeatherwaxController list) =
            for c in controllers do this.Controller(c) |> ignore
            this

        [<JavaScript>]
        member this.States (stateDefinitions: StateDefinition array, otherwise: string option, ?redirects: StateWhen array) =
            let templateFunction (state: StateDefinition) =
                let paramLength = state.UrlParametersToPassToTemplate.Length
                let baseUrl = sprintf "/Template/%s/%i/" state.Name paramLength
                match paramLength with
                    | 0 -> fun (o: obj) -> baseUrl
                    | _ ->
                        fun (o: obj) ->
                            state.UrlParametersToPassToTemplate
                            |> List.fold (fun c p -> c + o?(p).ToString ()) baseUrl
            let routeConfiguration =
                AngularExpression2<_,_>(Providers.State, Providers.UrlRouter).Resolve(
                    fun (stateProvider, urlRouterProvider) ->
                        stateDefinitions
                        |> Array.iter (fun s ->
                            let url = match s.Url with | Some u -> u | None -> null
                            let templateUrl = templateFunction s
                            let controller = match s.ControllerName with | Some c -> c | None -> null

                            stateProvider.State (s.Name, StateConfig (Url = url, TemplateUrl = templateUrl, Controller = controller, Data = s.CustomData)) |> ignore
                        )

                        if redirects.IsSome then
                            redirects.Value
                            |> Array.iter (fun r -> urlRouterProvider.When (r.UrlIn, r.UrlOut) |> ignore)

                        match otherwise with
                            | Some o -> urlRouterProvider.Otherwise (o) |> ignore
                            | None -> ()
                )
            this.Config (routeConfiguration)

//        [<JavaScript>]
//        member this.ControllerName<'TController when 'TController : equality> (controller: 'TController) =
//            ""

//        [<JavaScript>]
//        member this.Controllers (config: ControllerConfiguration<'T>) =
//            for c in config.Controllers do this.Controller(c.Name, c.Implementation) |> ignore
//            this
//
//        [<JavaScript>]
//        member this.States (templateResolver: 'TTemplate -> string option, stateConfig: StateConfiguration<'TTemplate,'TController,'TState>, nameMapper: 'TState -> string, controllerConfig: ControllerConfiguration<'TController>) =
//            let resolveTemplate t =
//                match t with
//                    | Direct template -> 
//                        // sprintf "Template/%s" <| templateRelativePath template :> obj
//                        match templateResolver template with
//                            | Some url -> url :> obj
//                            | None -> "(template not found)" :> obj
//                    | Parameterised templateFunc -> templateFunc :> obj
//            let controllerName c =
//                controllerConfig.ControllerName c
//            let routeConfiguration =
//                AngularExpression2<_,_>(Providers.State, Providers.UrlRouter).Resolve(
//                    fun (stateProvider, urlRouterProvider) ->
//                        stateConfig.States
//                        |> List.iter (fun s ->
//                            match s.Implementation.Url with
//                                | Some u ->
//                                    match s.Implementation.Controller with
//                                        | Some c -> stateProvider.State (s.Name, StateConfig (Url = u, TemplateUrl = resolveTemplate (s.Implementation.Template), Controller = controllerName c, Data = s.Implementation.CustomData)) |> ignore
//                                        | None -> stateProvider.State (s.Name, StateConfig (Url = u, TemplateUrl = resolveTemplate (s.Implementation.Template), Data = s.Implementation.CustomData)) |> ignore
//                                | None ->
//                                    match s.Implementation.Controller with
//                                        | Some c -> stateProvider.State (s.Name, StateConfig (Abstract = true, TemplateUrl = resolveTemplate (s.Implementation.Template), Controller = controllerName c, Data = s.Implementation)) |> ignore
//                                        | None -> stateProvider.State (s.Name, StateConfig (Abstract = true, TemplateUrl = resolveTemplate (s.Implementation.Template), Data = s.Implementation.CustomData)) |> ignore
//                        )
//
//                        stateConfig.Whens
//                        |> List.iter (fun w -> match w with | (whenPath, toPath) -> urlRouterProvider.When (whenPath, toPath) |> ignore)
//
//                        match stateConfig.Otherwise() with
//                            | Some o -> urlRouterProvider.Otherwise (o) |> ignore
//                            | None -> ()
//                )
//            this.Config (routeConfiguration)

    type Auto.InjectorService with
        [<JavaScript>]
        member this.TransitionToState (newState: string) =
            this.Invoke(
                AngularExpression1<_>(Services.State).Resolve(
                    fun state ->
                        state.Go (newState) |> ignore
                )                                      
            ) |> ignore                        

    // let ControllerName<'T when 'T :> WeatherwaxController> = ControllerManager.Instance.ControllerName typeof<'T>

    let private hasNestedProperty = 
        function
            | PropertyGet (_, _, _) -> true
            | _ -> false

    let rec internal GetMemberName = 
        function
            | Lambda (_, lambdaBody) -> GetMemberName lambdaBody
            | Value (_, valueInfo) -> Some valueInfo.Name
            | FieldGet (fieldContents, fieldInfo) -> 
                match fieldContents with
                    | Some contents ->
                        match GetMemberName contents with
                            | Some r -> sprintf "%s.%s" r fieldInfo.Name |> Some
                            | None -> Some fieldInfo.Name
                    | None -> Some fieldInfo.Name
            | Call (_, methodInfo, _) -> methodInfo.Name + "()" |> Some
            | PropertyGet (propertyContents, propertyInfo, _) ->
                match propertyContents with
                    | Some contents ->
                        match GetMemberName contents with
                            | Some r -> sprintf "%s.%s" r propertyInfo.Name |> Some
                            | None -> Some propertyInfo.Name
                    | None -> Some propertyInfo.Name
            | _ -> None // failwith "Not a valid expression"

    let GetControllers<'T when 'T : equality> () =
        FSharpType.GetUnionCases (typeof<'T>)
        |> Array.filter(fun c -> c.GetFields().Length = 0)      // Ignore "abstract" controllers (i.e. those that take arguments)
        |> Array.map(fun c ->
            let caseValue = FSharpValue.MakeUnion (c, [||]) :?> 'T
            match c.GetCustomAttributes (typeof<CompiledNameAttribute>) with
                | [| attr |] -> caseValue, (attr :?> CompiledNameAttribute).CompiledName
                | _ -> caseValue, c.Name            
        )

    let GetUnionCases<'T when 'T : equality> () =
        // TODO: Make this a function that converts a discriminated union into a partial URL string based on the arguments
        // supplied to each member of the discriminated union (e.g. | Error errorCode -> sprintf "Error/%s" errorCode
        FSharpType.GetUnionCases (typeof<'T>)
        |> Array.map (fun c ->
            let rec fields fieldInfo =
                seq {
                    match fieldInfo with
                        | head :: tail -> 
                            yield "blah/"
                            yield! fields tail
                        | _ -> ()
                }
            let caseValue = FSharpValue.MakeUnion (c, [||]) :?> 'T
            match c.GetCustomAttributes (typeof<CompiledNameAttribute>) with
                | [| attr |] -> caseValue, (attr :?> CompiledNameAttribute).CompiledName
                | _ -> caseValue, c.Name
        )