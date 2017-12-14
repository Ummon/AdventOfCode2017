module AdventOfCode2017.Day14Compact

let regions (input : string) =
    let m = Array2D.zeroCreate 128 128
    for i = 0 to 127 do
        input + "-" + (string i)
        |> Day10.knotHash2Encoding (fun i -> System.Convert.ToString(i, 2).PadLeft(8, '0'))
        |> Seq.iteri (fun j c -> m.[i, j] <- int c - int '0')
    let mutable n = 0
    let rec remove i j =
        if i >= 0 && i < 128 && j >= 0 && j < 128 && m.[i, j] = 1 then
            n <- n + 1
            m.[i, j] <- 0
            1 + remove (i + 1) j * remove (i - 1) j * remove i (j + 1) * remove i (j - 1)
        else
            0
    [ for i in 0 .. 127 do for j in 0 .. 127 -> remove i j ] |> List.sum, n