module AdventOfCode2017.Day22

type CellState = Weakened | Infected | Flagged | Clean

// We dont use a 'Map' because the part 2 is too slow with it: ~1 min instead of 8 s.
type M = System.Collections.Generic.Dictionary<int * int, CellState>

let parseInput (lines : string[]) : M =
    let m = M ()
    for y = 0 to lines.Length - 1 do
        for x = 0 to lines.[y].Length - 1 do
            if lines.[y].[x] = '#' then
                m.Add ((x - lines.[y].Length / 2, -y + lines.Length / 2), Infected)
    m

let inline reverse (dx, dy) = -dx, -dy
let turnRight = function 1, 0 -> 0, -1 | 0, 1 ->  1, 0 | -1, 0 -> 0, 1  | _ -> -1, 0
let turnLeft = turnRight >> reverse

let infection (rule : CellState -> CellState * ((int * int) -> (int * int))) (nbIterations : int) (m : M) : int =
    let rec burst (x, y) d n becomeInfected =
        if n = 0 then
            becomeInfected
        else
            let nextState, f =  match m.TryGetValue ((x, y)) with true, state -> rule state | _ -> rule Clean
            let dx, dy = f d
            if nextState = Clean then
                m.Remove (x, y) |> ignore
            else
                m.[(x, y)] <- nextState
            burst (x + dx, y + dy) (dx, dy) (n - 1) (if nextState = Infected then becomeInfected + 1 else becomeInfected)

    burst (0, 0) (0, 1) nbIterations 0

let infection1 (m : M) =
    infection (
        function
        | Infected -> Clean, turnRight
        | _ -> Infected, turnLeft
    ) 10_000 m

let infection2 (m : M) =
    infection (
        function
        | Weakened -> Infected, id
        | Infected -> Flagged, turnRight
        | Flagged -> Clean, reverse
        | Clean -> Weakened, turnLeft
    ) 10_000_000 m