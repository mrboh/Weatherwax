namespace ellipsoid.org.Weatherwax.Core

open ellipsoid.org.SharpAngles
open IntelliFactory.WebSharper
open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Reflection
open System.Collections.Generic

module Utilities =

    type Module with
        [<JavaScript>]
        member this.Controllers (config: ControllerConfiguration<'T>) =
            for c in config.Controllers do this.Controller(c.Name, c.Implementation) |> ignore

//        [<JavaScript>]
//        member this.Controllers (controllers: 'T list, nameMapping: 'T -> string, implementationMapping: 'T -> obj) =
//            for c in controllers do this.Controller(nameMapping c, implementationMapping c) |> ignore
                        
    let private hasNestedProperty = 
        function
            | PropertyGet (_, _, _) -> true
            | _ -> false

    let rec internal GetMemberName = 
        function
            | Lambda (_, lambdaBody) -> GetMemberName lambdaBody
            | Value (_, valueInfo) -> Some valueInfo.Name
            | FieldGet (fieldContents, fieldInfo) -> 
                match fieldContents with
                    | Some contents ->
                        match GetMemberName contents with
                            | Some r -> sprintf "%s.%s" r fieldInfo.Name |> Some
                            | None -> Some fieldInfo.Name
                    | None -> Some fieldInfo.Name
            | Call (_, methodInfo, _) -> methodInfo.Name + "()" |> Some
            | PropertyGet (propertyContents, propertyInfo, _) ->
                match propertyContents with
                    | Some contents ->
                        match GetMemberName contents with
                            | Some r -> sprintf "%s.%s" r propertyInfo.Name |> Some
                            | None -> Some propertyInfo.Name
                    | None -> Some propertyInfo.Name
            | _ -> None // failwith "Not a valid expression"

    let GetControllers<'T when 'T : equality> () =
        FSharpType.GetUnionCases (typeof<'T>)
        |> Array.filter(fun c -> c.GetFields().Length = 0)      // Ignore "abstract" controllers (i.e. those that take arguments)
        |> Array.map(fun c ->
            let caseValue = FSharpValue.MakeUnion (c, [||]) :?> 'T
            match c.GetCustomAttributes (typeof<CompiledNameAttribute>) with
                | [| attr |] -> caseValue, (attr :?> CompiledNameAttribute).CompiledName
                | _ -> caseValue, c.Name            
        )

    let GetUnionCases<'T when 'T : equality> () =
        // TODO: Make this a function that converts a discriminated union into a partial URL string based on the arguments
        // supplied to each member of the discriminated union (e.g. | Error errorCode -> sprintf "Error/%s" errorCode
        FSharpType.GetUnionCases (typeof<'T>)
        |> Array.map (fun c ->
            let rec fields fieldInfo =
                seq {
                    match fieldInfo with
                        | head :: tail -> 
                            yield "blah/"
                            yield! fields tail
                        | _ -> ()
                }
            let caseValue = FSharpValue.MakeUnion (c, [||]) :?> 'T
            match c.GetCustomAttributes (typeof<CompiledNameAttribute>) with
                | [| attr |] -> caseValue, (attr :?> CompiledNameAttribute).CompiledName
                | _ -> caseValue, c.Name
        )