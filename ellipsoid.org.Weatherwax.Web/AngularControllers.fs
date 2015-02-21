﻿namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open ellipsoid.org.SharpAngles.UI
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.Dependencies
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Highcharts
open IntelliFactory.WebSharper.Html.Client
open IntelliFactory.WebSharper.JavaScript
open IntelliFactory.WebSharper.JQuery
open ellipsoid.org.Weatherwax.Web.AngularScopes

[<JavaScript>]
[<Require(typeof<Resources.Highcharts>)>]
module AngularControllers =

    type ErrorRouteParameters =
        { id: int }

    let ControllerConfiguration =
        ControllerConfiguration<AngularController>()
            .DefineController(AngularController.Base, "BaseController",
                AngularExpression2<_,_>(Services.Scope, Services.RootScope).Resolve(
                    fun (scope, rootScope) ->
                        rootScope.On("$viewContentLoaded",
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
                            "$stateChangeSuccess",
                                fun (event, toState: StateConfig, toParams, fromState: StateConfig, fromParams) ->
                                    let data = toState.Data :?> StateImplementation
                                    ()
                        )                )
            )
            
            .DefineController(AngularController.Home, "HomeController",
                AngularExpression1<_>(Services.Scope).Resolve(
                    fun scope ->
                        ()
                )            
            )

            .DefineController(AngularController.About, "AboutController",
                AngularExpression1<_>(Services.Scope).Resolve(
                    fun scope ->
                        let chart = JQuery.Of("#chart")

                        // Sample taken directly from WebSharper sample application: https://github.com/intellifactory/websharper.highcharts/blob/master/Site/Highchart.fs
                        Highcharts.Create(chart,
                            HighchartsCfg(
                                Title = TitleCfg(
                                    Text = "Monthly Average Temperature",
                                    X = -20.
                                ),
                                Subtitle = SubtitleCfg(
                                    Text = "Source: WorldClimate.com",
                                    X = -20.
                                ),        
                                XAxis = XAxisCfg(
                                    Categories = [| "Jan"; "Feb"; "Mar"; "Apr"; "May"; "Jun"; "Jul"; "Aug"; "Sep"; "Oct"; "Nov"; "Dec" |]
                                ),
                                YAxis = YAxisCfg(
                                    Title = YAxisTitleCfg(
                                        Text = "Temperature (°C)"        
                                    ),
                                    PlotLines = [|
                                        YAxisPlotLinesCfg(
                                            Value = 0.,
                                            Width = 1.,
                                            Color = "#808080"
                                        )
                                    |]
                                ),
                                Tooltip = TooltipCfg(
                                    ValueSuffix = "°C"    
                                ), 
                                Legend = LegendCfg(
                                    Layout = "vertical",
                                    Align = "right",
                                    VerticalAlign = "middle",
                                    BorderWidth = 0.
                                ),
                                Series = [|
                                    SeriesCfg(
                                        Name = "Tokyo",
                                        Data = As [| 7.0; 6.9; 9.5; 14.5; 18.2; 21.5; 25.2; 26.5; 23.3; 18.3; 13.9; 9.6 |]
                                    )
                                    SeriesCfg(
                                        Name = "New York",
                                        Data = As [| -0.2; 0.8; 5.7; 11.3; 17.0; 22.0; 24.8; 24.1; 20.1; 14.1; 8.6; 2.5 |]
                                    )
                                    SeriesCfg(
                                        Name = "Berlin",
                                        Data = As [| -0.9; 0.6; 3.5; 8.4; 13.5; 17.0; 18.6; 17.9; 14.3; 9.0; 3.9; 1.0 |]
                                    )
                                    SeriesCfg(
                                        Name = "London",
                                        Data = As [| 3.9; 4.2; 5.7; 8.5; 11.9; 15.2; 17.0; 16.6; 14.2; 10.3; 6.6; 4.8 |]
                                    )
                                |]
                            )                
                        )
                )
            
            )

            .DefineController(AngularController.Music, "MusicController",
                AngularExpression1<_>(Services.CustomScope<MusicScope>).Resolve(
                    fun scope ->
                        async {
                            let! result = Remoting.GetSongs ()
                            scope.songs <- result
                            scope.Apply () |> ignore        // Required to notify binding of async update
                        } |> Async.Start
                )            
            )

            .DefineController(AngularController.Error, "ErrorController",
                AngularExpression1<_>(Services.Scope).Resolve(
                    fun scope ->
                        ()
                )            
            )