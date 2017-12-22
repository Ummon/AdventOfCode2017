module AdventOfCode2017.Day21

type M = bool[,]

// Custom equality: more efficient than '='.
let inline (|==|) (a1 : 'a[,]) (a2 : 'a[,]) : bool =
    let l1 = Array2D.length1 a1
    if l1 <> Array2D.length1 a2 || Array2D.length2 a1 <> Array2D.length2 a2 then
        false
    else
        let rec result i j =
            if j = Array2D.length2 a1 then
                true
            elif a1.[i,j] <> a2.[i,j] then
                false
            else
                result ((i + 1) % l1) (if i + 1 = l1 then j + 1 else j)
        result 0 0

let parseInput (lines : string[]) : (M * M)[] =
    let readMat (str : string) =
        str.Split '/' |> Array.map (Array.ofSeq >> Array.map ((=) '#')) |> array2D

    lines
    |> Array.map (
        fun line ->
            let matPair = line.Split ([| " => " |], System.StringSplitOptions.RemoveEmptyEntries)
            readMat matPair.[0], readMat matPair.[1]
    )

let fractalArt (patterns : (M * M)[]) (nbIterations : int) : int =
    let turn (m : M) =
        let m' = m.[*, *]
        if Array2D.length1 m = 2 then
            m'.[0,0] <- m.[1,0]; m'.[0,1] <- m.[0,0]; m'.[1,1] <- m.[0,1]; m'.[1,0] <- m.[1,1]
        else
            m'.[0,0] <- m.[2,0]; m'.[0,1] <- m.[1,0]; m'.[0,2] <- m.[0,0]; m'.[1,2] <- m.[0,1]; m'.[2,2] <- m.[0,2]; m'.[2,1] <- m.[1,2]; m'.[2,0] <- m.[2,2]; m'.[1,0] <- m.[2,1]
        m'

    let flip (m : M) =
        let m' = m.[*, *]
        if Array2D.length1 m = 2 then
            m'.[0,0] <- m.[0,1]; m'.[0,1] <- m.[0,0]; m'.[1,1] <- m.[1,0]; m'.[1,0] <- m.[1,1]
        else
            m'.[0,0] <- m.[0,2]; m'.[1,0] <- m.[1,2]; m'.[2,0] <- m.[2,2]; m'.[0,2] <- m.[0,0]; m'.[1,2] <- m.[1,0]; m'.[2,2] <- m.[2,0]
        m'

    let variants (m : M) : M seq =
        let l = seq { 1 .. 3 } |> Seq.scan (fun m _ -> turn m) m
        if Array2D.length1 m > 2 then
            let l' = Seq.cache l
            Seq.append l' (l' |> Seq.map flip)
        else
            l

    let findPattern (p : M) : M =
        variants p |> Seq.pick (fun v -> patterns |> Array.tryPick (fun (m1, m2) -> if m1 |==| v then Some m2 else None))

    let next (m : M) : M =
        let l = Array2D.length1 m
        let s = if l % 2 = 0 then 2 else 3
        let l' = l + l / s
        let m' = Array2D.zeroCreate l' l'
        for i = 0 to l / s - 1 do
            for j = 0 to l / s - 1 do
                let pattern = findPattern m.[i * s .. i * s + s - 1, j * s .. j * s + s - 1]
                Array2D.blit pattern 0 0 m' (i * (s + 1)) (j * (s + 1)) (s + 1) (s + 1)
        m'

    let mutable n = 0
    [ 1 .. nbIterations ]
    |> List.fold (fun m _ -> next m) (array2D [ [ false; true; false ]; [ false; false; true ]; [ true; true; true] ])
    |> Array2D.iter (fun e -> if e then n <- n + 1)
    n