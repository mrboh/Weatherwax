namespace ellipsoid.org.Weatherwax.Web.Controllers

open ellipsoid.org.SharpAngles.UI
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.Dependencies
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html.Client
open IntelliFactory.WebSharper.JQuery
open ellipsoid.org.Weatherwax.Web

[<JavaScript>]
type ErrorController () =
    inherit WeatherwaxController ()
    override this.Name = this.FromSourceFilename __SOURCE_FILE__
    override this.Implementation =
        AngularExpression1<_>(Services.Scope).Resolve(
            fun scope ->
                ()
        )      