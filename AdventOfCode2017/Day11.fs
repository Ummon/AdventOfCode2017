module AdventOfCode2017.Day11

let distanceInHex (moves : string) =
    let distance (x, y) =
        let x, y = abs x, abs y
        if y >= x then y + (x - y) / 2 else x

    let destination, furthest =
        moves.Split ',' |> Seq.fold (
            fun ((x, y), furthest) m ->
                let pos = match m with "n" -> (x, y + 2) | "ne" -> (x + 1, y + 1) | "se" -> (x + 1, y - 1) | "s" -> (x, y - 2) | "sw" -> (x - 1, y - 1) | _ -> (x - 1, y + 1)
                pos, distance pos |> max furthest
            ) ((0, 0), 0)
    distance destination, furthest