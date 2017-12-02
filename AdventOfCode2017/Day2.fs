module AdventOfCode2017.Day2

open System

let parseInput (str : string) : int[][] =
    str.Split ([| '\n' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun line -> line.Split ([| ' '; '\t' |], StringSplitOptions.RemoveEmptyEntries) |> Array.map int)

let checksum1 (a : int[][]) =
    a
    |> Array.map (fun ns -> Array.max ns - Array.min ns)
    |> Array.sum

let checksum2 (a : int[][]) =
    a
    |> Array.map (
        fun ns ->
            seq {
                for a in ns do
                    for b in ns do
                        if a <> b && a % b = 0 then yield a / b
            } |> Seq.head
    )
    |> Array.sum
