namespace ellipsoid.org.Weatherwax.Web.Controllers

open ellipsoid.org.SharpAngles.UI
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.Dependencies
open ellipsoid.org.Weatherwax.Web
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html.Client
open IntelliFactory.WebSharper.JQuery

[<JavaScript>]
type BaseController () =
    inherit WeatherwaxController ()
    override this.Name = this.FromSourceFilename __SOURCE_FILE__
    override this.Implementation =
        AngularExpression2<_,_>(Services.Scope, Services.RootScope).Resolve(
            fun (scope, rootScope) ->
                rootScope.On(Dependencies.Events.ViewContentLoaded,
                    // This function is necessary so that PhantomJs knows when Angular has finished rendering
                    // and can return the rendered output
                    fun _ ->
                        match JQuery.Of("#compositionComplete").Length with
                            | 0 ->
                                let element = Span [ Id "compositionComplete" ]
                                JQuery.Of("body").Append(element.Dom) |> ignore
                            | _ -> ()
                            
                ) |> ignore
                scope.On(
                    Dependencies.Events.StateChangeSuccess,
                        fun (event, toState: StateConfig, toParams, fromState: StateConfig, fromParams) ->
                            // Changes in state can be reacted to here
                            let data = toState.Data
                            ()
                )       )
