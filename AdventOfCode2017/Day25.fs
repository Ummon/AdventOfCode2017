module AdventOfCode2017.Day25

let readMove (str : string) = if str = "right" then 1 else -1

type State =
    {
        Values : int[]
        Moves : int[] // -1: left, +1: right.
        NextState : char[]
    }

let split (str : string) (chars : char[]) = str.Split (chars, System.StringSplitOptions.RemoveEmptyEntries)

let parseInput (lines : string[]) : Map<char, State> * char * int =
    let firstState = (split lines.[0] [| ' '; '.' |]).[3] |> char
    let nbSteps = lines.[1].Split(' ').[5] |> int

    [
        for i = 0 to (lines.Length - 2) / 9 - 1 do
            let lineNum = i * 10 + 3
            let name = (split lines.[lineNum] [| ' '; ':' |]).[2] |> char
            let state =
                {
                    Values = [| (split lines.[lineNum + 2] [| ' '; '.' |]).[4] |> int; (split lines.[lineNum + 6] [| ' '; '.' |]).[4] |> int |]
                    Moves = [| (split lines.[lineNum + 3] [| ' '; '.' |]).[6] |> readMove; (split lines.[lineNum + 7] [| ' '; '.' |]).[6] |> readMove |]
                    NextState = [| (split lines.[lineNum + 4] [| ' '; '.' |]).[4] |> char; (split lines.[lineNum + 8] [| ' '; '.' |]).[4] |> char |]
                }
            yield name, state
    ] |> Map.ofList, firstState, nbSteps

let checksum (states : Map<char, State>, firstState : char, nbSteps : int) : int =
    let next (tape : Set<int>) (cursor : int) (stateName : char) : Set<int> * int * char =
        let state = states |> Map.find stateName
        let v = if tape |> Set.contains cursor then 1 else 0
        (tape |> if state.Values.[v] = 1 then Set.add cursor else Set.remove cursor), cursor + state.Moves.[v], state.NextState.[v]

    let tape, _, _ = [ 1 .. nbSteps ] |> List.fold (fun (tape, cursor, state) _ -> next tape cursor state) (Set.empty, 0, firstState)
    tape |> Set.count