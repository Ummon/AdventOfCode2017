module AdventOfCode2017.Day12

open System

let parseInput (lines : string[]) : Map<int, Set<int>> =
    lines
    |> Array.map (
        fun str ->
            let l = str.Split ([| ' '; ',' |], StringSplitOptions.RemoveEmptyEntries)
            int l.[0], l.[2..] |> Array.map int |> Set.ofArray
    ) |> Map.ofArray

let graphCount (g : Map<int, Set<int>>) =
    let rec visit (visited : Set<int>) (current : int)  : Set<int> =
        if visited |> Set.contains current then
            Set.empty
        else
            let visited' = visited.Add current
            g.[current] + (g.[current] |> Set.map (visit visited') |> Set.unionMany)

    let rec nbRoots (vertices : Set<int>) =
        if Set.isEmpty vertices then 0 else 1 + nbRoots (vertices - (visit Set.empty (vertices |> Set.minElement)))

    visit Set.empty 0 |> Set.count, g |> Map.toList |> List.map fst |> Set.ofList |> nbRoots