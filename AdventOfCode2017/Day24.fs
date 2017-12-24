module AdventOfCode2017.Day24

type Components = (int * int) list

let parseInput (lines : string[]) : Components =
    lines
    |> List.ofArray
    |> List.map (
        fun line ->
            let numbers = line.Split '/'
            int numbers.[0], int numbers.[1]
    )

let rec chooseAndRemove (f : 'a -> 'b option) (l : 'a list) : ('b * 'a list) list =
    l
    |> List.choose (fun e -> match f e with Some e' -> Some (e, e') | None -> None)
    |> List.map (fun (e, e') -> e', l |> List.except [ e ])

let bridges (components : Components) : Components list =
    let rec build (components : Components) (bridge : Components) : Components list =
        let validComponents =
            components
            |> chooseAndRemove
                (match bridge with
                | [] -> fun (a, b) -> if a = 0 then Some (b, a) else None
                | (a, _) :: _ -> fun (a', b') -> if a' = a then Some (b', a') elif b' = a then Some (a', b') else None)

        if List.isEmpty validComponents then
            [ bridge ]
        else
            validComponents |> List.fold (fun bridges (c, cs) -> build cs (c :: bridge) @ bridges) []
    build components []

let bridgeValue = List.sumBy (fun (a, b) -> a + b)
let maxBridge = List.map bridgeValue >> List.max
let longestBridge = List.sortByDescending (fun bridge -> List.length bridge, bridgeValue bridge) >> List.head >> bridgeValue
