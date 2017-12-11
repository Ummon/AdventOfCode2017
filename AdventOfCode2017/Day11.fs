module AdventOfCode2017.Day11

let parseInput (input : string) : string list = input.Split ',' |> List.ofArray

let distanceInHex (moves : string list) =
    let distance (x, y) =
        let x, y = abs x, abs y
        if y >= x then y + (x - y) / 2 else x

    let rec next (x, y) furthest (moves : string list) =
        let furthest' = distance (x, y) |> max furthest
        match moves with
        | "n"  :: xs -> next (x, y + 2) furthest' xs
        | "ne" :: xs -> next (x + 1, y + 1) furthest' xs
        | "se" :: xs -> next (x + 1, y - 1) furthest' xs
        | "s"  :: xs -> next (x, y - 2) furthest' xs
        | "sw" :: xs -> next (x - 1, y - 1) furthest' xs
        | "nw" :: xs -> next (x - 1, y + 1) furthest' xs
        | _ -> (x, y), furthest'

    let destination, furthest = next (0, 0) 0 moves
    distance destination, furthest