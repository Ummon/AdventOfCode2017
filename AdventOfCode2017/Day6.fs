module AdventOfCode2017.Day6

open System

let parseInput (str : string) : int[] =
    str.Split ([| '\r'; '\t'; ' ' |], StringSplitOptions.RemoveEmptyEntries) |> Array.map int

// Custom equality: more efficient than '='.
let inline (|=|) (a1 : 'a[]) (a2 : 'a[]) : bool =
    if a1.Length <> a2.Length then
        false
    else
        let rec result i =
            if i = a1.Length then
                true
            elif a1.[i] <> a2.[i] then
                false
            else
                result (i + 1)
        result 0

let nbRedistribution (blocks : int[]) =
    let rec next (previous : int[] list) =
        let blocks = List.head previous |> Array.copy
        let i, max = blocks |> Array.indexed |> Array.maxBy snd
        blocks.[i] <- 0
        for offset = i + 1 to i + max do
            let i' = offset % blocks.Length
            blocks.[i'] <- blocks.[i'] + 1

        match previous |> List.tryFindIndex ((|=|) blocks) with
        | Some i -> previous, i + 1
        | None -> next (blocks :: previous)

    let blockList, cycleLength = next [ blocks ]

    List.length blockList, cycleLength
