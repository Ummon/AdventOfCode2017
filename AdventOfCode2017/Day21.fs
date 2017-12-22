module AdventOfCode2017.Day21

open System

type M = bool[,]

let parseInput (lines : string[]) : (M * M) list =
    let readMat (str : string) =
        str.Split '/' |> Array.map (Array.ofSeq >> Array.map ((=) '#')) |> array2D

        (*

        let l = str.Length
        let m = Array2D.zeroCreate l l : M
        let rows = str.Split '/'
        for i = 0 to l - 1 do
            for j = 0 to l - 1 do
                m.[i, j] <- rows.[i].[j] = '#'
        m*)


    lines
    |> List.ofArray
    |> List.map (
        fun line ->
            let matPair = line.Split ([| "=>" |], StringSplitOptions.RemoveEmptyEntries)
            readMat matPair.[0], readMat matPair.[1]
    )

let fractalArt (patterns : (M * M) list) : int =
    let turn (m : M) =
        let l = Array2D.length1 m
        let m' = Array2D.zeroCreate l l
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
        let l = Array2D.length1 m
        let m' = Array2D.zeroCreate l l
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

    let next (m : M) : M =
        let l = Array2D.length1 m
        if l % 2 = 0 then
            let l' = l + l / 2
        else

    let mutable n = 0
    next (array2 [ [ false; true; false ]; [ false; false; true ]; [ true; true; true] ]) |> Array2D.iter (fun e -> if e then n <- n + 1)
    n