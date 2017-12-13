module AdventOfCode2017.Day13

let parseInput (lines : string[]) =
    lines
    |> Array.map (
        fun line ->
            let values = line.Split ([| ':'; ' ' |], System.StringSplitOptions.RemoveEmptyEntries)
            int values.[0], int values.[1]
    )

let severity (input : (int * int)[]) =
    let inline sumBy (f : int -> int -> int) delay =
        input |> Array.sumBy (fun (d, r) -> if (d + delay) % (2 * r - 2) = 0 then f d r else 0)

    sumBy (*) 0, Seq.initInfinite (fun i -> i, sumBy (+) i) |> Seq.pick (fun (i, s) -> if s = 0 then Some i else None)