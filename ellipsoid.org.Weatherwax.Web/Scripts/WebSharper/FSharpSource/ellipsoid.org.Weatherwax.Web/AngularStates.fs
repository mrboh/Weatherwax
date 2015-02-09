namespace ellipsoid.org.Weatherwax.Web

open IntelliFactory.WebSharper

[<JavaScript>]
module AngularStates =

    type MasterState = 
        | Home
        | About
        | Music
        | Error

    type AngularState =
        | Master of MasterState option

    let subState name value matcher =
        match value with
            | None -> name
            | Some s -> sprintf "%s.%s" name <| matcher s

    let AngularStateName =
        function
            | Master value ->
                subState "master" value <| function
                    | Home -> "home"
                    | About -> "about"
                    | Music -> "music"
                    | Error -> sprintf "error"