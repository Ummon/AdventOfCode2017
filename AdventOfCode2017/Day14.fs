﻿    module AdventOfCode2017.Day14

    let hash = Day10.knotHash2Encoding (fun i -> System.Convert.ToString(i, 2).PadLeft(8, '0'))

    let buildMatrix (input : string) : bool[,] =
        let mat = Array2D.zeroCreate 128 128
        for i = 0 to 127 do
            input + "-" + (string i) |> hash |> Seq.iteri (fun j c -> if c = '1' then mat.[i, j] <- true)
        mat

    let nbOfUsedSquares (input : string) =
        let mutable i = 0
        buildMatrix input |> Array2D.iter (fun b -> if b then i <- i + 1)
        i

    let nbOfConnectedRegions (input : string) =
        let m = buildMatrix input

        let rec remove i j =
            if i >= 0 && i < 128 && j >= 0 && j < 128 && m.[i, j] then
                m.[i, j] <- false
                1 + remove (i + 1) j * remove (i - 1) j * remove i (j + 1) * remove i (j - 1)
            else
                0

        [ for i in 0 .. 127 do for j in 0 .. 127 -> remove i j ] |> List.sum