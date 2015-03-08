namespace ellipsoid.org.Weatherwax.Web.States

open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.ServerDirectives
open ellipsoid.org.Weatherwax.Web
open ellipsoid.org.Weatherwax.Web.AngularScopes
open ellipsoid.org.Weatherwax.Web.Controllers
open IntelliFactory.WebSharper.Html.Server
open System

type Master_MusicState () =
    inherit WeatherwaxState<AngularState> ()
    override this.State = Master_Music
    override this.Name = this.FromSourceFilename __SOURCE_FILE__
    override this.Url = Some "^/music"
    override this.Controller = Some <| (MusicController () :> _)
    override this.Template =
        Inline <|
            fun (urlParams, context, helper) -> 
                let musicRepeater = NgRepeater <@ fun (scope: MusicScope) -> scope.songs @>
                [ 
                    Div [ 
                        Text """
                            This template demonstrates the interaction between Angular and WebSharper's
                            RPC mechanism by loading a list of songs via the controller and binding
                            the list to the view. It also demonstrates the use of a type-safe ng-repeat
                            directive.
                        """
                    ]
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