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

type private D = System.DateTime
type private K = System.DateTimeKind
type private TS = System.TimeSpan

[<AbstractClass>]
type private E =
    [<Inline "new Date($d)">]
    static member FromDateTime(d: D) = X<E>
    
    [<Inline "new Date($y,$mo,$d)">]
    static member Create3(y: int, mo: int, d: int) = X<E>

    [<Inline "new Date($y,$mo,$d,$h,$m,$s)">]
    static member Create6(y: int, mo: int, d: int, h: int, m: int, s: int) = X<E>

    [<Inline "new Date($y,$mo,$d,$h,$m,$s,$ms)">]
    static member Create7(y: int, mo: int, d: int, h: int, m: int, s: int, ms: int) = X<E>

    [<Stub>] abstract member getTime         : unit -> D
    [<Stub>] abstract member getFullYear     : unit -> int
    [<Stub>] abstract member getMonth        : unit -> int
    [<Stub>] abstract member getDate         : unit -> int
    [<Stub>] abstract member getHours        : unit -> int
    [<Stub>] abstract member getMinutes      : unit -> int
    [<Stub>] abstract member getSeconds      : unit -> int
    [<Stub>] abstract member getMilliseconds : unit -> int
    [<Stub>] abstract member getDay          : unit -> int

module private DateTimeHelpers =
    [<JavaScript>]
    let DatePortion d =
        let e = E.FromDateTime(d)
        E.Create3(       
            e.getFullYear(),
            e.getMonth(),
            e.getDate()
        ).getTime()        

    [<JavaScript>]
    let TimePortion d =
        let e = E.FromDateTime(d)
        TS(
            0,
            e.getHours(), 
            e.getMinutes(), 
            e.getSeconds(), 
            e.getMilliseconds()
        )        

    [<JavaScript>]
    let AddYears(d, years) : D =
        let e = E.FromDateTime(d)
        E.Create7(   
            e.getFullYear() + years,
            e.getMonth(),
            e.getDate(),
            e.getHours(),
            e.getMinutes(),
            e.getSeconds(),
            e.getMilliseconds()
        ).getTime()

    [<JavaScript>]
    let AddMonths(d, months: int) : D =
        let e = E.FromDateTime(d)
        E.Create7(   
            e.getFullYear(),
            e.getMonth() + months,
            e.getDate(),
            e.getHours(),
            e.getMinutes(),
            e.getSeconds(),
            e.getMilliseconds()
        ).getTime()    
             
[<Proxy(typeof<System.DateTime>)>]
type private DateTimeProxy =
    [<Inline "0">]
    new () = {}

    [<Inline "new Date($y,$mo-1,$d).getTime()">]
    new (y: int, mo: int, d: int) = {}

    [<Inline "new Date($y,$mo-1,$d,$h,$m,$s).getTime()">]
    new (y: int, mo: int, d: int, h: int, m: int, s: int) = {}

    [<Inline "new Date($y,$mo-1,$d,$h,$m,$s,$ms).getTime()">]
    new (y: int, mo: int, d: int, h: int, m: int, s: int, ms: int) = {}

    static member Now
        with [<Inline "Date.now()">] get() = X<D>
    
    static member UtcNow
        with [<Inline "Date.now()">] get() = X<D>
    
    [<Inline "1">]
    member this.Kind = X<System.DateTimeKind>

    member this.Date 
        with [<Inline; JavaScript>] get() : D = DateTimeHelpers.DatePortion(As this)

    static member Today
        with [<Inline; JavaScript>] get() = DateTimeProxy.Now.Date  

    member this.TimeOfDay 
        with [<Inline; JavaScript>] get() = DateTimeHelpers.TimePortion(As this)

    member this.Year
        with [<Inline; JavaScript>] get() = E.FromDateTime(As this).getFullYear()

    member this.Month 
        with [<Inline; JavaScript>] get() = E.FromDateTime(As this).getMonth() + 1

    member this.Day 
        with [<Inline; JavaScript>] get() = E.FromDateTime(As this).getDate()

    member this.Hour 
        with [<Inline; JavaScript>] get() = E.FromDateTime(As this).getHours()
                                                  
    member this.Minute 
        with [<Inline; JavaScript>] get() = E.FromDateTime(As this).getMinutes()
    
    member this.Second 
        with [<Inline; JavaScript>] get() = E.FromDateTime(As this).getSeconds()

    member this.Millisecond 
        with [<Inline; JavaScript>] get() = E.FromDateTime(As this).getMilliseconds()
    
    member this.DayOfWeek 
        with [<Inline; JavaScript>] get() = As<System.DayOfWeek>(E.FromDateTime(As this).getDay())

    member this.Ticks
        with [<Inline "$this * 1E4">] get() = X<int64>

    [<Inline "$this + $t">]
    member this.Add(t: TS) = X<D>
                            
    [<Inline "$this - $t">]
    member this.Subtract(t: TS) = X<D>

    [<Inline "$this - $d">]
    member this.Subtract(d: D) = X<TS>

    [<Inline; JavaScript>]
    member this.AddYears(years: int) : D = DateTimeHelpers.AddYears(As this, years)

    [<Inline; JavaScript>]
    member this.AddMonths(months: int) : D = DateTimeHelpers.AddMonths(As this, months)

    [<Inline; JavaScript>]
    member this.AddDays(days: float) : D =
        this.Add(TS.FromDays days)

    [<Inline; JavaScript>]
    member this.AddHours(hours: float) : D =
        this.Add(TS.FromHours hours)

    [<Inline; JavaScript>]
    member this.AddMinutes(minutes: float) : D =
        this.Add (TS.FromMinutes minutes)

    [<Inline; JavaScript>]
    member this.AddSeconds(seconds: float) : D =
        this.Add (TS.FromSeconds seconds)

    [<Inline; JavaScript>]
    member this.AddMilliseconds(msec: float) : D =
        this.Add (TS.FromMilliseconds msec)

    [<Inline; JavaScript>]
    member this.AddTicks(ticks: int64) : D =
        this.Add (TS.FromTicks ticks)
