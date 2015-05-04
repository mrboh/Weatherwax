namespace ellipsoid.org.Weatherwax.Web.Controllers

open ellipsoid.org.SharpAngles.UI
open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.Dependencies
open ellipsoid.org.Weatherwax.Web.AngularScopes
open ellipsoid.org.Weatherwax.Web.Remoting
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html.Client
open IntelliFactory.WebSharper.JQuery
open ellipsoid.org.Weatherwax.Web

[<JavaScript>]
type MusicController () =
    inherit WeatherwaxController ()
    override this.Name = this.FromSourceFilename __SOURCE_FILE__
    override this.Implementation =
        AngularExpression1<_>(Services.CustomScope<MusicScope>).Resolve(
            fun scope ->
                async {
                    let! result = GetSongs ()
                    scope.songs <- result
                    scope.Apply () |> ignore        // Required to notify binding of async update
                } |> Async.Start
        )            
