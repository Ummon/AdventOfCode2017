module AdventOfCode2017.Day12

open System

let parseInput (lines : string[]) : Map<int, Set<int>> =
    lines
    |> Array.fold (
        fun dic str ->
            let l = str.Split ([| ' '; ',' |], StringSplitOptions.RemoveEmptyEntries)
            dic.Add (int l.[0], l.[2 .. l.Length - 1] |> Array.map int |> Set.ofArray)
    ) Map.empty

let graphCount (g : Map<int, Set<int>>) =

    let rec visit (current : int) (visited : Set<int>) : Set<int> =
        if visited |> Set.contains current then
            Set.empty
        else
            seq { yield g.[current]; for neighbor in g.[current] -> visit neighbor (visited |> Set.add current) } |> Set.unionMany

    let rec nbRoots (vertices : Set<int>) =
        if Set.isEmpty vertices then
            0
        else
            1 + nbRoots (vertices - (visit (vertices |> Set.minElement) Set.empty))

    visit 0 Set.empty |> Set.count, g |> Map.toList |> List.map fst |> Set.ofList |> nbRoots