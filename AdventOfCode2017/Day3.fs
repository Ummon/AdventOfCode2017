module AdventOfCode2017.Day3

type Direction = Right | Up | Left | Down

let nextDirection = function Right -> Up | Up -> Left | Left -> Down | Down -> Right

let move (pos : int * int) (d : Direction) =
    let x, y = pos
    match d with Right -> x + 1, y | Up -> x, y + 1 | Left -> x - 1, y | Down -> x, y - 1

let rec next (pos : int * int) (l : int) (d : Direction) : (int * int) seq =
    let directions = Seq.unfold (fun d -> Some (d, nextDirection d)) d |> Seq.take 3 |> List.ofSeq

    let mutable pos' = pos

    seq {
        for d in directions |> List.take 2 do
            for _j = 1 to l do
                pos' <- move pos' d
                yield pos'
        yield! next pos' (l + 1) (List.last directions)
    }

let spiralManhattanDistanceSum (n : int) =
    let x, y = next (0, 0) 1 Right |> Seq.item (n - 2)
    abs x + abs y

let spiralAdjacentSumBiggerThan (n : int) =
    let neighborsSum (dic : Map<int * int, int>) (pos : int * int) =
        let x, y = pos
        [ x + 1, y; x + 1, y + 1; x, y + 1; x - 1, y + 1; x - 1, y; x - 1, y - 1; x, y - 1; x + 1, y - 1]
        |> List.map (
            fun (x, y) ->
                match dic |> Map.tryFind (x, y) with
                | Some v -> v
                | None -> 0
        )
        |> List.sum

    next (0, 0) 1 Right
    |> Seq.scan (
        fun (_sum, dic) pos ->
            let sum = neighborsSum dic pos
            sum, dic |> Map.add pos sum
    ) (1, Map.empty |> Map.add (0, 0) 1)
    |> Seq.pick (fun (sum, _) -> if sum > n then Some sum else None)