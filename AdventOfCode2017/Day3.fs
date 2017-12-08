module AdventOfCode2017.Day3

let directions = [| 1, 0; 0, 1; -1, 0; 0, -1 |]

let spiral =
    Seq.unfold (
        fun (pos, dir, n, i) ->
            let x, y = directions.[dir]
            let pos' = fst pos + x, snd pos + y
            let nMax = (i + 1) * 2 - 1
            let i', n' = if n = nMax then i + 1, 0 else i, n + 1
            let dir' = if i <> i' || n' = nMax / 2 + 1 then (dir + 1) % 4 else dir
            Some (pos, (pos', dir', n', i'))
    ) ((0, 0), 0, 0, 0)

let spiralManhattanDistanceSum (n : int) =
    let x, y = spiral |> Seq.item (n - 1)
    abs x + abs y

let spiralAdjacentSumBiggerThan (n : int) =
    let neighborsSum (dic : Map<int * int, int>) (pos : int * int) =
        let x, y = pos
        [ for dx in -1 .. 1 do for dy in -1 .. 1 -> x + dx, y + dy ]
        |> List.sumBy (fun (x, y) -> match dic |> Map.tryFind (x, y) with Some v -> v | None -> 0)

    spiral
    |> Seq.skip 1
    |> Seq.scan (
        fun (_sum, dic) pos ->
            let sum = neighborsSum dic pos
            sum, dic |> Map.add pos sum
    ) (1, Map.empty |> Map.add (0, 0) 1)
    |> Seq.pick (fun (sum, _) -> if sum > n then Some sum else None)