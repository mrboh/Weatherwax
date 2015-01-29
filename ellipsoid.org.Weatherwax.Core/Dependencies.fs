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
module Dependencies =

    let Router = "ngRoute"
    let UIRouter = "ui.router"

    module Services =
        
        let CustomScope<'T when 'T :> Scope> = Dependency<'T> ("$scope")
        let RootScope = Dependency<RootScopeService> ("$rootScope")
        let Scope = Dependency<Scope> ("$scope")
        let State = Dependency<StateService> ("$state")

    module Providers =

        let Location = Dependency<LocationProvider> ("$locationProvider")
        let State = Dependency<StateProvider> ("$stateProvider")
        let UrlMatcherFactory = Dependency<UrlMatcherFactory> ("$urlMatcherFactoryProvider")
        let UrlRouter = Dependency<UrlRouterProvider> ("$urlRouterProvider")

    module Other =
    
        let StateParams<'T> = Dependency<'T> ("$stateParams")