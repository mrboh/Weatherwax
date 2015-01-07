namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.Weatherwax.Core.ServerDirectives
open ellipsoid.org.Weatherwax.Web.AngularScopes
open ellipsoid.org.Weatherwax.Web.Remoting
open IntelliFactory.Html
open Microsoft.FSharp.Linq
open System.Linq
open System.Linq.Expressions

module AngularTemplates =

    let TemplateImplementation =
        function
            | Master ->
                [
                    Div [ Id "master" ] -< [
                        H1 [ Class "ui block header teal" ] -< [ Text "Weatherwax: WebSharper + Angular" ]
                        Div [ Class "ui menu" ] -< [
                            A [ SRef "master.home"; Class "item" ] -< [ I [ Class "home icon" ]; Text "Home" ]
                            A [ SRef "master.about"; Class "item" ] -< [ I [ Class "help circle icon" ]; Text "About" ]
                            A [ SRef "master.music"; Class "item" ] -< [ I [ Class "music icon" ]; Text "Music" ]
                            Div [ Class "right menu" ] -< [
                                A [ SRef "master.error({ id: 404 })"; Class "item" ] -< [ I [ Class "frown icon" ]; Text "Error Page" ]
                            ]
                        ]
                        UIView []
                    ]
                ]
            | Home -> 
                [ Div [ Text "This is the home template" ] ]
            | About -> 
                [ 
                    Div [ Text ("This template demonstrates the use of other WebSharper extensions inside " +
                                "Angular. The AboutController instantiates a chart inside the #chart tag " +
                                "when it is first loaded.") ] 
                    Br []
                    Div [ Id "chart" ]
                ]
            | Music ->
                let musicRepeater = NgRepeater <@ fun (scope: MusicScope) -> scope.songs @>

                [ 
                    Div [ Text ("This template demonstrates the interaction between Angular and WebSharper's " +
                                "RPC mechanism by loading a list of songs via the controller and binding " +
                                "the list to the view. It also demonstrates the use of a type-safe ng-repeat " +
                                "directive.") ]
                    H3 [ Text "Favourite Songs" ]
                    Table [ Class "ui table" ] -< [
                        THead [
                            TR [
                                TH [ Text "Artist" ]
                                TH [ Text "Title" ]
                                TH [ Text "Album" ]
                                TH [ Text "Play Count" ]
                            ]
                        ]
                        TR [ NgRepeat musicRepeater.RepeatString ] -< [
                            TD [ musicRepeater.TextBinding <@ fun song -> song.Artist @> ]
                            TD [ musicRepeater.TextBinding <@ fun song -> song.Title @> ]
                            TD [ musicRepeater.TextBinding <@ fun song -> song.Album @> ]
                            TD [ musicRepeater.TextBinding <@ fun song -> song.PlayCount @> ]
                        ]
                    ]
                ]
            | Error errorCode -> 
                [ Div [ sprintf "Oh dear, something has gone horribly wrong (Error Code %d)" errorCode |> Text ] ]