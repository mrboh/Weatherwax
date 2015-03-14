namespace ellipsoid.org.Weatherwax.Web.States

open ellipsoid.org.Weatherwax.Core
open ellipsoid.org.Weatherwax.Core.ServerDirectives
open ellipsoid.org.Weatherwax.Web
open ellipsoid.org.Weatherwax.Web.Controllers
open IntelliFactory.WebSharper.Html.Server
open System

type Master_ErrorState () =
    inherit WeatherwaxState<AngularState> ()
    let idParameter = IntParameter "id"

    override this.State = Master_Error
    override this.Name = this.FromSourceFilename __SOURCE_FILE__
    override this.Url = Some <| sprintf "^/error/{%s}" idParameter.Name
    override this.UrlParametersToPassToTemplate = [ idParameter.Name ]
    override this.ControllerType = Some typeof<ErrorController>
    override this.Template =
        Inline <|
            fun (urlParams, context, helper) -> 
                let errorCode = idParameter.ReadValue urlParams
                [ Div [ sprintf "Oh dear, something has gone horribly wrong (Error Code %i)" errorCode |> Text ] ]            