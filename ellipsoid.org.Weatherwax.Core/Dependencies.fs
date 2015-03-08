namespace ellipsoid.org.Weatherwax.Core

open ellipsoid.org.SharpAngles
open ellipsoid.org.SharpAngles.UI
open IntelliFactory.WebSharper

[<JavaScript>]
type Dependency<'T> (javascriptName) =
    member this.JavascriptName = javascriptName

[<JavaScript>]
type IAngularExpression =
    interface end

[<JavaScript>]
type AngularExpression0 () =
    member this.Resolve (lambda: unit -> _) = lambda :> obj
    interface IAngularExpression

[<JavaScript>]
type AngularExpression1<'T1> (d1: Dependency<'T1>) =
    member this.Resolve (lambda: 'T1 -> _) = (d1.JavascriptName, lambda) :> obj
    interface IAngularExpression

[<JavaScript>]
type AngularExpression2<'T1,'T2> (d1: Dependency<'T1>, d2: Dependency<'T2>) =
    member this.Resolve (lambda: 'T1 * 'T2 -> _) = (d1.JavascriptName, d2.JavascriptName, lambda) :> obj
    interface IAngularExpression

[<JavaScript>]
type AngularExpression3<'T1,'T2,'T3> (d1: Dependency<'T1>, d2: Dependency<'T2>, d3: Dependency<'T3>) =
    member this.Resolve (lambda: 'T1 * 'T2 * 'T3 -> _) = (d1.JavascriptName, d2.JavascriptName, d3.JavascriptName, lambda) :> obj
    interface IAngularExpression

[<JavaScript>]
module Dependencies =

    let Router = "ngRoute"
    let UIRouter = "ui.router"

    module Events =

        let StateChangeSuccess = "$stateChangeSuccess"
        let ViewContentLoaded = "$viewContentLoaded"

    module Services =
        
        let CustomScope<'T when 'T :> Scope> = Dependency<'T> ("$scope")
        let Location = Dependency<LocationService> ("$location")
        let RootScope = Dependency<RootScopeService> ("$rootScope")
        let Route = Dependency<Route.RouteService> ("$route")
        let Sce = Dependency<SCEService> ("$sce")
        let Scope = Dependency<Scope> ("$scope")
        let State = Dependency<StateService> ("$state")

    module Providers =

        let Location = Dependency<LocationProvider> ("$locationProvider")
        let State = Dependency<StateProvider> ("$stateProvider")
        let UrlMatcherFactory = Dependency<UrlMatcherFactory> ("$urlMatcherFactoryProvider")
        let UrlRouter = Dependency<UrlRouterProvider> ("$urlRouterProvider")

    module Other =
    
        let StateParams<'T> = Dependency<'T> ("$stateParams")