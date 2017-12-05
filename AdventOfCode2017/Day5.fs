module AdventOfCode2017.Day5

open System

let parseInput (str : string) : int[] =
    str.Split ([| '\r'; '\t'; ' ' |], StringSplitOptions.RemoveEmptyEntries) |> Array.map int

let nbSteps (next : int -> int) (instructions : int[])  =
    let is = instructions.[*]
    let mutable cursor, steps = 0, 0
    while cursor >= 0 && cursor < instructions.Length do
        let i = is.[cursor]
        is.[cursor] <- next is.[cursor]
        cursor <- cursor + i
        steps <- steps + 1
    steps

let nbSteps1 = nbSteps ((+) 1)
let nbSteps2 = nbSteps (fun i -> if i >= 3 then i - 1 else i + 1)