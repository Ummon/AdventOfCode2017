module AdventOfCode2017.Day11

let parseInput (input : string) : string list = input.Split ',' |> List.ofArray

let distanceInHex (moves : string list) =
    let distance (x, y) =
        let x, y = abs x, abs y
        if y >= x then y + (x - y) / 2 else x

    let rec next (x, y) further (moves : string list) =
        let further' = distance (x, y) |> max further
        match moves with
        | "n"  :: xs -> next (x, y + 2) further' xs
        | "ne" :: xs -> next (x + 1, y + 1) further' xs
        | "se" :: xs -> next (x + 1, y - 1) further' xs
        | "s"  :: xs -> next (x, y - 2) further' xs
        | "sw" :: xs -> next (x - 1, y - 1) further' xs
        | "nw" :: xs -> next (x - 1, y + 1) further' xs
        | _ -> (x, y), further'

    let destination, further = next (0, 0) 0 moves
    distance destination, further


