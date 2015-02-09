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

open System
open IntelliFactory.WebSharper

[<Proxy "Microsoft.FSharp.Control.EventModule, \
    FSharp.Core, Culture=neutral, \
    PublicKeyToken=b03f5f7f11d50a3a">]
module private EventModule =

    [<Inline>]
    [<JavaScript>]
    let Add f (e: IEvent<_,_>) = e.Add f

    [<JavaScript>]
    let Choose c (e: IEvent<_,_>) : IEvent<_> =
        // let r = Event.New ()
        let r = Event<_>()
        e.Add (fun x ->
            match c x with
            | Some y    -> r.Trigger y
            | None      -> ())
        r.Publish :> _

    [<JavaScript>]
    let Filter ok (e: IEvent<_,_>) : IEvent<_> =
        let r = Event.New ()
        e.Add (fun x -> if ok x then r.Trigger x)
        r :> _

    [<JavaScript>]
    let Map f (e: IEvent<_,_>) : IEvent<_> =
        let r = Event.New ()
        e.Add (fun x -> r.Trigger (f x))
        r :> _

    [<JavaScript>]
    let Merge<'D1,'T,'D2 when 'D1 :> Delegate
                          and 'D1 :  delegate<'T,unit>
                          and 'D2 :> Delegate
                          and 'D2 :  delegate<'T,unit>>
            (e1: IEvent<'D1,'T>) (e2: IEvent<'D2,'T>) : IEvent<_> =
        let r = Event.New ()
        e1.Add r.Trigger
        e2.Add r.Trigger
        r :> _

    [<JavaScript>]
    let Pairwise (e: IEvent<_,_>) : IEvent<_> =
        let buf = ref None
        let ev  = Event.New ()
        e.Add (fun x ->
            match buf.Value with
            | None ->
                buf := Some x
            | Some old ->
                buf := Some x
                ev.Trigger(old, x))
        ev :> _

    [<JavaScript>]
    let Partition f e =
        (Event.filter f e, Event.filter (f >> not) e)

    [<JavaScript>]
    let Scan fold seed e =
        let state = ref seed
        let f value =
            state := fold !state value
            !state
        Event.map f e

    [<JavaScript>]
    let Split (f: 'T -> Choice<'U1,'U2>) (e: IEvent<'Del,'T>) =
        (
            e |> Event.choose (fun x ->
                match f x with
                | Core.Choice1Of2 x -> Some x
                | _                 -> None),
            e |> Event.choose (fun x ->
                match f x with
                | Core.Choice2Of2 x -> Some x
                | _                 -> None)
        )

