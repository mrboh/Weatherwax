namespace ellipsoid.org.Weatherwax.Web

open AngularControllers
open AngularTemplates
open ellipsoid.org.Weatherwax.Core
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.JavaScript

open AngularStates

[<JavaScript>]
module AngularRouter =

    type C = AngularController
    type SI = StateImplementation
    type T = AngularTemplate

    type ErrorRouteParameters =
        { id: int }

    // This takes an object containing the URL parameters (p) and converts it into a template path
    let internal errorTemplate = fun (p: obj) -> sprintf "Template/%s" <| TemplateRelativePath (T.Error (p :?> ErrorRouteParameters).id)

    let StateConfiguration =
        StateConfiguration<AngularTemplate,AngularController,AngularState>(AngularStateName)
            // Abstract states
            .DefineState(Master None,               SI (None,                       Direct T.Master))

            // Concrete states
            .DefineState(Master <| Some Home,       SI (Some "^/",                  Direct T.Home,                  C.Home))
            .DefineState(Master <| Some About,      SI (Some "^/about",             Direct T.About,                 C.About))
            .DefineState(Master <| Some Music,      SI (Some "^/music",             Direct T.Music,                 C.Music))
            .DefineState(Master <| Some Error,      SI (Some "^/error/{id}",        Parameterised errorTemplate,    C.Error))

            // Default to the master.home state if no state provided
            .When("", "/")

            // If no matching state, show the error state
            .Otherwise("/error/404")