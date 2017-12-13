module AdventOfCode2017.Day13

open System

let parseInput (lines : string[]) =
    lines
    |> Array.map (
        fun line ->
            let values = line.Split ([| ':'; ' ' |], StringSplitOptions.RemoveEmptyEntries)
            int values.[0], int values.[1]
    )

let severity (input : (int * int)[]) : int * int =
    let severity (f : int -> int -> int) delay =
        input |> Array.sumBy (fun (depth, range) -> if (depth + delay) % (2 * range - 2) = 0 then f depth range else 0)

    severity (*) 0, Seq.initInfinite (fun i -> i, severity (+) i) |> Seq.pick (fun (i, s) -> if s = 0 then Some i else None)