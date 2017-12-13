module AdventOfCode2017.Day13

let parseInput (lines : string[]) =
    lines
    |> Array.map (
        fun line ->
            let values = line.Split ([| ':'; ' ' |], System.StringSplitOptions.RemoveEmptyEntries)
            int values.[0], int values.[1]
    )

let severity (input : (int * int)[]) =
    let inline sum delay =
        input |> Array.sumBy (fun (d, r) -> if (d + delay) % (2 * r - 2) = 0 then (d + delay) * r else 0)

    sum 0, Seq.initInfinite (fun i -> i, sum i) |> Seq.pick (fun (i, s) -> if s = 0 then Some i else None)