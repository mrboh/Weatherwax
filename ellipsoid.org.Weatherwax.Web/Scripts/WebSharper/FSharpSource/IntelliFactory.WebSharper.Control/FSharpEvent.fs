// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2014 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}

namespace IntelliFactory.WebSharper.Control

open IntelliFactory.WebSharper

[<Proxy(typeof<Event<_>>)>]
type private FSharpEvent<'T> [<JavaScript>] () =
    let event = Event.New ()

    [<Inline>]
    [<JavaScript>]
    member this.Trigger(x: 'T) = event.Trigger x

    [<JavaScript>]
    member this.Publish with [<Inline>] get () = event :> IEvent<_>

[<Proxy(typeof<IDelegateEvent<_>>)>]
type private IDelegateEventProxy<'D> =
    abstract AddHandler : 'D -> unit
    abstract RemoveHandler : 'D -> unit
