module AdventOfCode2017.Day8

open System

type Instruction = string * string * int * string * string * int

let parseInput (lines : string[]) : Instruction list =
    lines
    |> List.ofArray
    |> List.map (
        fun line ->
            let line = line.Split ([| '\r'; '\t'; ' ' |], StringSplitOptions.RemoveEmptyEntries)
            ( line.[0], line.[1], int line.[2], line.[4], line.[5], int line.[6])
    )

let execute (input : Instruction list) : int * int =
    let highest, register =
        input
        |> List.fold (
            fun (highest, register) (reg, ins, value, regCond, op, valueCond) ->
                let regCondValue = register |> Map.tryFind regCond |> Option.defaultValue 0
                let op' = match op with ">" -> (>) | "<" -> (<) | ">=" -> (>=) | "<=" -> (<=) | "!=" -> (<>) | "==" | _ -> (=)
                if op' regCondValue valueCond then
                    let regValue = register |> Map.tryFind reg |> Option.defaultValue 0
                    let regValue' = match ins with "inc" -> regValue + value | "dec" -> regValue - value | _ -> regValue
                    max highest regValue', register |> Map.add reg regValue'
                else
                    highest, register
        ) (Int32.MinValue, Map.empty)
    highest, (register |> Map.toList |> List.map snd |> List.max)
