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

/// Defines operators and functions that are automatically available whenever
/// `IntelliFactory.WebSharper` is open.
[<AutoOpen>]
module IntelliFactory.WebSharper.JavaScript.Pervasives

open IntelliFactory.WebSharper
module M = IntelliFactory.WebSharper.Macro

/// Returns null or some other default value of the given type.
/// Note: a short-hand for "Unchecked.defaultof<'T>".
let X<'T> = Unchecked.defaultof<'T>

let private binary (x: obj) (y: obj) = JS.ClientSide<obj>
let private binaryAs<'T> (x: obj) (y: obj) = JS.ClientSide<'T>

/// Casts an object to the desired type.
[<Inline "$x">]
let As<'T> (x: obj) = JS.ClientSide<'T>

/// Implements piping with mutation.
[<Inline "($f($x), $x)">]
let ( |>! ) x f = f x; x

[<Inline "$x * $y">]
let ( *. ) x y = binary x y

[<Inline "$x / $y">]
let ( /. ) x y = binary x y

[<Inline "$x % $y">]
let ( %. ) x y = binary x y

[<Inline "$x + $y">]
let ( +. ) x y = binary x y

[<Inline "$x - $y">]
let ( -. ) x y = binary x y

[<Inline "$x << $y">]
let ( <<. ) x y = binary x y

[<Inline "$x >> $y">]
let ( >>. ) x y = binary x y

[<Inline "$x >>> $y">]
let ( >>>. ) x y = binary x y

[<Inline "$x < $y">]
let ( <. ) x y = binaryAs<bool> x y

[<Inline "$x > $y">]
let ( >. ) x y = binaryAs<bool> x y

[<Inline "$x >= $y">]
let ( >=. ) x y = binaryAs<bool> x y

[<Inline "$x <= $y">]
let ( <=. ) x y = binaryAs<bool> x y

[<Inline "$x == $y">]
let ( ==. ) x y = binaryAs<bool> x y

[<Inline "$x === $y">]
let ( ===. ) x y = binaryAs<bool> x y

[<Inline "$x != $y">]
let ( !=. ) x y = binaryAs<bool> x y

[<Inline "$x !== $y">]
let ( !==. ) x y = binaryAs<bool> x y

[<Inline "$x | $y">]
let ( |. ) x y = binary x y

[<Inline "$x & $y">]
let ( &. ) x y = binary x y

[<Inline "$x ^ $y">]
let ( ^. ) x y = binary x y

[<Inline "$obj[$field]">]
let ( ? ) (obj: obj) (field: string) = JS.ClientSide<'T>

[<Inline "void ($obj[$key] = $value)">]
let ( ?<- ) (obj: obj) (key: string) (value: obj) = JS.ClientSide<unit>

[<Inline "[$x,$y]">]
let ( => ) (x: string) (y: obj) = (x, y)

[<JavaScript>]
let private NewFromList<'T> (fields: seq<string * obj>) : 'T =
    let r = obj ()
    for (k, v) in fields do
        (?<-) r k v
    As r

/// Constructs a new object as if an object literal was used.
[<Macro(typeof<M.New>)>]
let New<'T> (fields: seq<string * obj>) = X<'T>

/// Constructs an proxy to a remote object instance.
[<Inline "null">]
let Remote<'T> = JS.ClientSide<'T>
