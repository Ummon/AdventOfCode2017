module AdventOfCode2017.Day10

let knotHash (nbRounds : int) (reduce : int[] -> string) (lengths : int list) (size : int) =
    let state = Array.init size id
    let mutable current, skipSize = 0, 0

    let swap i j =
        let tmp = state.[i]
        state.[i] <- state.[j]
        state.[j] <- tmp

    for _r = 1 to nbRounds do
        for l in lengths do
            for i = current to current + l / 2 - 1 do
                swap (i % state.Length) ((2 * current + l - 1 - i) % state.Length)
            current <- current + l + skipSize
            skipSize <- skipSize + 1

    reduce state

let knotHash1 (str : string) =
    knotHash 1 (fun s -> s.[0] * s.[1] |> string) (str.Split ',' |> List.ofArray |> List.map int)

let knotHash2Encoding (encoding : int -> string) (str : string) =
    knotHash 64 (Array.chunkBySize 16 >> Array.map (Array.reduce (^^^) >> encoding) >> Array.reduce (+)) (List.append (str |> List.ofSeq |> List.map int) [ 17; 31; 73; 47; 23 ]) 256

let knotHash2 = knotHash2Encoding (sprintf "%02x")