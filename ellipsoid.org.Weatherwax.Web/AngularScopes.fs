namespace ellipsoid.org.Weatherwax.Web

open ellipsoid.org.SharpAngles
open IntelliFactory.WebSharper
open ellipsoid.org.Weatherwax.Web.Remoting

[<JavaScript>]
module AngularScopes =

    [<AbstractClass>]
    type BaseScope =
        inherit Scope
        [<DefaultValue>] val mutable loadComplete: unit -> unit

    [<AbstractClass>]
    type MusicScope =
        inherit Scope
        [<DefaultValue>] val mutable songs: Song array