module AdventOfCode2017.Day08

open System

type Instruction = string * string * int * string * (int -> int -> bool) * int

let parseInput (lines : string[]) : Instruction list =
    lines
    |> List.ofArray
    |> List.map (
        fun line ->
            let line = line.Split ' '
            line.[0], line.[1], int line.[2], line.[4], (match line.[5] with ">" -> (>) | "<" -> (<) | ">=" -> (>=) | "<=" -> (<=) | "!=" -> (<>) | "==" | _ -> (=)), int line.[6]
    )

let execute (input : Instruction list) : int * int =
    let highest, register =
        input
        |> List.fold (
            fun (highest, register) (reg, ins, value, regCond, op, valueCond) ->
                if op (register |> Map.tryFind regCond |> Option.defaultValue 0) valueCond then
                    let regValue' = (register |> Map.tryFind reg |> Option.defaultValue 0) + match ins with "inc" -> value | "dec" -> -value | _ -> 0
                    max highest regValue', register |> Map.add reg regValue'
                else
                    highest, register
        ) (Int32.MinValue, Map.empty)
    highest, (register |> Map.toList |> List.map snd |> List.max)
