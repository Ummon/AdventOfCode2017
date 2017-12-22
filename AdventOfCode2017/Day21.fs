module AdventOfCode2017.Day21

type M = bool[,]

/// We use a Map which is slower than a Dictionary<T,U>.
/// To use a Dictionary<T,U> a new type must be created instead of bool[,] because Array2D do not properly support the 'GetHashCode' methode.
/// To get a correct hash code of a Array2D the function 'hash' must be used.
let parseInput (lines : string[]) : Map<M, M> =
    let readMat (str : string) =
        str.Split '/' |> Array.map (Array.ofSeq >> Array.map ((=) '#')) |> array2D

    lines
    |> Array.map (
        fun line ->
            let matPair = line.Split ([| " => " |], System.StringSplitOptions.RemoveEmptyEntries)
            readMat matPair.[0], readMat matPair.[1]
    )
    |> Map.ofArray

let fractalArt (patterns : Map<M, M>) (nbIterations : int) : int =
    let turn (m : M) =
        let m' = m.[*, *]
        if Array2D.length1 m = 2 then
            m'.[0,0] <- m.[1,0]
            m'.[0,1] <- m.[0,0]
            m'.[1,1] <- m.[0,1]
            m'.[1,0] <- m.[1,1]
        else
            m'.[0,0] <- m.[2,0]
            m'.[0,1] <- m.[1,0]
            m'.[0,2] <- m.[0,0]
            m'.[1,2] <- m.[0,1]
            m'.[2,2] <- m.[0,2]
            m'.[2,1] <- m.[1,2]
            m'.[2,0] <- m.[2,2]
            m'.[1,0] <- m.[2,1]
        m'

    let flip (m : M) =
        let m' = m.[*, *]
        if Array2D.length1 m = 2 then
            m'.[0,0] <- m.[0,1]
            m'.[0,1] <- m.[0,0]
            m'.[1,1] <- m.[1,0]
            m'.[1,0] <- m.[1,1]
        else
            m'.[0,0] <- m.[0,2]
            m'.[1,0] <- m.[1,2]
            m'.[2,0] <- m.[2,2]
            m'.[0,2] <- m.[0,0]
            m'.[1,2] <- m.[1,0]
            m'.[2,2] <- m.[2,0]
        m'

    let variants (m : M) : M list =
        let l = List.unfold (fun (i, m) -> if i < 4 then Some (m, (i + 1, turn m)) else None) (0, m)
        if Array2D.length1 m > 2 then l @ (l |> List.map flip) else l

    let findPattern (p : M) : M =
        variants p |> List.pick (fun v -> patterns |> Map.tryFind v)

    let rec next (m : M) (n : int) : M =
        if n = 0 then
            m
        else
            let l = Array2D.length1 m
            let s = if l % 2 = 0 then 2 else 3
            let l' = l + l / s
            let m' = Array2D.zeroCreate l' l'
            for i = 0 to l / s - 1 do
                for j = 0 to l / s - 1 do
                    let pattern = findPattern m.[i * s .. i * s + s - 1, j * s .. j * s + s - 1]
                    Array2D.blit pattern 0 0 m' (i * (s + 1)) (j * (s + 1)) (s + 1) (s + 1)
            next m' (n - 1)

    let mutable n = 0
    next (array2D [ [ false; true; false ]; [ false; false; true ]; [ true; true; true] ]) nbIterations |> Array2D.iter (fun e -> if e then n <- n + 1)
    n