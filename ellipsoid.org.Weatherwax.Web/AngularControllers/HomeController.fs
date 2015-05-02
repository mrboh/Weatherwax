namespace ellipsoid.org.Weatherwax.Web.Controllers

open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.Dependencies
open IntelliFactory.WebSharper
open ellipsoid.org.Weatherwax.Web

[<JavaScript>]
type HomeController () =
    inherit WeatherwaxController<AngularController> ()
    override this.Name = this.FromSourceFilename __SOURCE_FILE__
    override this.Controller = AngularController.Home
    override this.Implementation =
        AngularExpression1<_>(Services.Scope).Resolve(
            fun scope ->
                ()
        )    