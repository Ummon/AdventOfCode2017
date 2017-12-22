module AdventOfCode2017.Day22

type M = Set<int * int>

let parseInput (lines : string[]) : M =
    (*for i = 0 to lines.Length do
        for*)
    Set.empty


let infection (m : M) : int =

    let rec burst (i, j) (di, dj) n m =
        if n = 0 then
            ()
        else
            burst (i, j) (di, dj) (n - 1) m

    23

