module AdventOfCode2017.Day6

open System

type Blocks = int[]

let parseInput (str : string) : int[] =
    str.Split ([| '\r'; '\t'; ' ' |], StringSplitOptions.RemoveEmptyEntries) |> Array.map int

let nbRedistribution (blocks : Blocks) =
    let rec next (previous : Blocks list) =
        let blocks = List.head previous |> Array.copy
        let i, max = blocks |> Array.indexed |> Array.maxBy snd
        blocks.[i] <- 0
        for offset = i + 1 to i + max do
            let i' = offset % blocks.Length
            blocks.[i'] <- blocks.[i'] + 1

        match previous |> List.tryFindIndex ((=) blocks) with
        | Some i -> previous, i + 1
        | None -> next (blocks :: previous)

    let blockList, cycleLength = next [ blocks ]

    List.length blockList, cycleLength
