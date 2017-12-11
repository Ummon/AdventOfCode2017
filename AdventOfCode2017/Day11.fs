module AdventOfCode2017.Day11

let distanceInHex (moves : string) =
    let distance (x, y, z) = (abs x + abs y + abs z) / 2

    let destination, furthest =
        moves.Split ',' |> Seq.fold (
            fun ((x, y, z), furthest) m ->
                let next =
                    match m with
                    | "n"  -> x    , y + 1, z - 1
                    | "ne" -> x + 1, y    , z - 1
                    | "se" -> x + 1, y - 1, z
                    | "s"  -> x    , y - 1, z + 1
                    | "sw" -> x - 1, y    , z + 1
                    | _    -> x - 1, y + 1, z
                next, distance next |> max furthest
            ) ((0, 0, 0), 0)
    distance destination, furthest