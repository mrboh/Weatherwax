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

namespace IntelliFactory.WebSharper

open IntelliFactory.WebSharper.JavaScript

[<Name "IntelliFactory.WebSharper.List.T">]
[<Proxy(typeof<list<_>>)>]
type private ListProxy<'T> =
    | [<Name "Empty">] EmptyCase
    | [<Name "Cons">]  ConsCase of 'T * List<'T>

    [<Name "Construct">]
    [<JavaScript>]
    static member Cons(head: 'T, tail: list<'T>) = head :: tail

    [<Name "Nil">]
    [<JavaScript>]
    static member Empty : list<'T> = []

    member this.Head    with [<Inline "$this.$0">] get ()     = X<'T>
    member this.Tail    with [<Inline "$this.$1">] get ()     = X<list<'T>>
    member this.IsEmpty with [<Inline "$this.$ == 0">] get () = X<bool>

    [<JavaScript>]
    member this.Length with get () = Seq.length (As this)

    [<JavaScript>]
    member this.Item with get (x: int) : 'T = Seq.nth x (As this)

    [<JavaScript>]
    member this.GetEnumerator() =
        let data = As<list<'T>> this
        Enumerator.New data (fun e ->
            match e.State with
            | x :: xs ->
                e.Current <- x
                e.State <- xs
                true
            | [] ->
                false)

