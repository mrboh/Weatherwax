namespace ellipsoid.org.Weatherwax.Web.States

open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.ServerDirectives
open ellipsoid.org.Weatherwax.Web
open ellipsoid.org.Weatherwax.Web.Controllers
open IntelliFactory.WebSharper.Html.Server
open System
open ellipsoid.org.Weatherwax.Core.Utilities

type Master_AboutState () =
    inherit WeatherwaxState<AngularState,AngularController> ()
    override this.State = Master_About
    override this.Name = this.FromSourceFilename __SOURCE_FILE__
    override this.Url = Some "^/about"
    override this.ControllerType = Some typeof<AboutController>
    override this.Template =
        Inline <|
            fun (urlParams, context, helper) -> 
                [
                    Div [ 
                        Text """
                            This template demonstrates the use of other WebSharper extensions inside
                            Angular. The AboutController instantiates a chart inside the #chart tag
                            when it is first loaded.
                        """ 
                    ] 
                    Br []
                    Div [ Id "chart" ]
                ]