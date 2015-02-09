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

[<IntelliFactory.WebSharper.Core.Attributes.Name "Queue">]
module private IntelliFactory.WebSharper.QueueProxy

open IntelliFactory.WebSharper.JavaScript

[<Inline "$arr.splice($offset,$len)">]
let splice (arr: obj) (offset: int) (len: int) = X<unit>

[<JavaScript>]
let Clear (a: obj) =
    splice a 0 (a :?> obj []).Length

[<JavaScript>]
let Contains (a: obj) (el: 'T) =
    Seq.exists ((=) el) (a :?> seq<'T>)

[<JavaScript>]
let CopyTo (a: obj) (array: 'T[]) (index: int) =
    Array.blit (a :?> 'T []) 0 array index (a :?> 'T[]).Length

[<Proxy(typeof<System.Collections.Generic.Queue<_>>)>]
type private QueueProxy<'T when 'T : equality>

    [<Inline "$data">] (data: 'T []) =

    [<Inline "[]">]
    new () = QueueProxy [||]

    member this.Count with [<Inline "$this.length">] get () = X<int>

    [<Inline>]
    [<JavaScript>]
    member this.Clear() = Clear this

    [<Inline>]
    [<JavaScript>]
    member this.Contains(x: 'T) = Contains this x

    [<Inline>]
    [<JavaScript>]
    member this.CopyTo(array: 'T [], index: int) = CopyTo this array index

    [<Inline "$this[0]">]
    member this.Peek() = X<'T>

    [<Inline "$this.shift()">]
    member this.Dequeue() = X<'T>

    [<Inline "$this.push($x)">]
    member this.Enqueue(x: 'T) = X<unit>

    [<Inline "$this.slice(0)">]
    member this.ToArray() = data

