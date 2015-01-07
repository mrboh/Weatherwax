namespace ellipsoid.org.Weatherwax.Web

open IntelliFactory.WebSharper

module Remoting =

    type Song =
        { Title: string
          Artist: string
          Album: string
          PlayCount: int }

    [<Remote>]
    let GetSongs () =
        async {
            return [|
                { Title = "Sweetness and Light"; Artist = "Itch-E and Scratch-E"; Album = "Sweetness and Light"; PlayCount = 42 }
                { Title = "Dirty Work"; Artist = "Steely Dan"; Album = "Can't Buy a Thrill"; PlayCount = 13 }
                { Title = "That Lonesome Road"; Artist = "The Boxcar Lilies"; Album = "Sugar Shack"; PlayCount = 4 }
                { Title = "Angel"; Artist = "The Idea of North"; Album = "Anthology"; PlayCount = 77 }
            |]
        }
