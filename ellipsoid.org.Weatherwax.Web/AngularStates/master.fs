namespace ellipsoid.org.Weatherwax.Web.States

open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.ServerDirectives
open ellipsoid.org.Weatherwax.Web
open IntelliFactory.WebSharper.Html.Server
open System

type MasterState () =
    inherit WeatherwaxState<AngularState,AngularController> ()
    override this.State = Master
    override this.Name = this.FromSourceFilename __SOURCE_FILE__
    override this.Template =
        Inline <|
            fun (urlParams, context, helper) -> 
                [
                    Div [ Id "master" ] -< [
                        H1 [ Class "ui block header teal" ] -< [ Text "Weatherwax: WebSharper + Angular" ]
                        Div [ Class "ui menu" ] -< [
                            A [ helper.SRef Master_Home; Class "item" ] -< [ I [ Class "home icon" ]; Text "Home" ]
                            A [ helper.SRef Master_About; Class "item" ] -< [ I [ Class "help circle icon" ]; Text "About" ]
                            A [ helper.SRef Master_Music; Class "item" ] -< [ I [ Class "music icon" ]; Text "Music" ]
                            Div [ Class "right menu" ] -< [
                                A [ helper.SRef (Master_Error, ("id", "404")); Class "item" ] -< [ I [ Class "frown icon" ]; Text "Error Page" ]
                            ]
                        ]
                        UIView []
                    ]
                ]
            