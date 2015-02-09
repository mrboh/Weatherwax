namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.ServerDirectives
open ellipsoid.org.Weatherwax.Web
open ellipsoid.org.Weatherwax.Web.AngularScopes
open ellipsoid.org.Weatherwax.Web.AngularStates
open ellipsoid.org.Weatherwax.Web.Remoting
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html.Server
open Microsoft.FSharp.Linq
open System.Linq
open System.Linq.Expressions

module AngularTemplates =

    type AngularTemplate =
        | Master
        | Home
        | About
        | Music
        | Error of int

    [<JavaScript>]
    let TemplateRelativePath =
        function
            | Master -> "Master"
            | Home -> "Home"
            | About -> "About"
            | Music -> "Music"
            | Error x -> sprintf "Error/%d" x

    let CreateSRef state = AngularStateName state |> SRef
    let CreateMasterSRef state = AngularStateName <| AngularState.Master (Some state) |> SRef
    let CreateMasterSRefWithArg state arg value =
        let stateName = AngularStateName <| AngularState.Master (Some state)
        sprintf "%s({%s: %s})" stateName arg value |> SRef

    let TemplateImplementation =
        function
            | Master -> 
                Inline [
                    Div [ Id "master" ] -< [
                        H1 [ Class "ui block header teal" ] -< [ Text "Weatherwax: WebSharper + Angular" ]
                        Div [ Class "ui menu" ] -< [
                            A [ CreateMasterSRef MasterState.Home; Class "item" ] -< [ I [ Class "home icon" ]; Text "Home" ]
                            A [ CreateMasterSRef MasterState.About; Class "item" ] -< [ I [ Class "help circle icon" ]; Text "About" ]
                            A [ CreateMasterSRef MasterState.Music; Class "item" ] -< [ I [ Class "music icon" ]; Text "Music" ]
                            Div [ Class "right menu" ] -< [
                                A [ CreateMasterSRefWithArg MasterState.Error "id" "404"; Class "item" ] -< [ I [ Class "frown icon" ]; Text "Error Page" ]
                            ]
                        ]
                        UIView []
                    ]
                ]
            | Home -> 
                Static <| Html "Home.html"
            | About -> 
                Inline [ 
                    Div [ Text ("This template demonstrates the use of other WebSharper extensions inside " +
                                "Angular. The AboutController instantiates a chart inside the #chart tag " +
                                "when it is first loaded.") ] 
                    Br []
                    Div [ Id "chart" ]
                ]
            | Music ->
                let musicRepeater = NgRepeater <@ fun (scope: MusicScope) -> scope.songs @>

                Inline [ 
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
                Inline [ Div [ sprintf "Oh dear, something has gone horribly wrong (Error Code %d)" errorCode |> Text ] ]