namespace ellipsoid.org.Weatherwax.Web.States

open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.ServerDirectives
open ellipsoid.org.Weatherwax.Web
open ellipsoid.org.Weatherwax.Web.Controllers
open IntelliFactory.WebSharper.Html.Server
open System

type Master_HomeState () =
    inherit WeatherwaxState<AngularState> ()
    override this.State = Master_Home
    override this.Name = this.FromSourceFilename __SOURCE_FILE__
    override this.Url = Some "^/"
    override this.Controller = Some <| (HomeController () :> _)
    override this.Template = Static <| Html "Home.html"