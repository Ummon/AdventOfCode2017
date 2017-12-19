module AdventOfCode2017.Day19

open System

let followThePath (lines : string[]) : string * int =
    let rec next (i, j) (di, dj) str n =
        let i', j' = i + di, j + dj
        let c = lines.[i'].[j']
        if c = '+' then
            let nextDir =
                [ 0, 1; -1, 0; 0, -1; 1, 0 ]
                |> List.pick (
                    fun (ndi, ndj) ->
                        let ni, nj = i' + ndi, j' + ndj
                        if (ni, nj) <> (i, j) && (Char.IsWhiteSpace lines.[ni].[nj] |> not) then Some (ndi, ndj) else None
                )
            next (i', j') nextDir str (n + 1)
        elif Char.IsWhiteSpace c |> not then
            next (i', j') (di, dj) (if Char.IsLetter c then str + string c else str) (n + 1)
        else
            str, n
    next (0, lines.[0].IndexOf '|') (1, 0) "" 1
