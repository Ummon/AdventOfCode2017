module AdventOfCode2017.Day17

open System.Collections.Generic

let spinLock1 (moves : int) =
    let buffer = List [ 0 ]
    let mutable pos = 0
    for i = 1 to 2017 do
        pos <- (pos + moves) % buffer.Count + 1
        buffer.Insert (pos, i)
    buffer.[(pos + 1) % buffer.Count]

let spinLock2 (moves : int) =
    let mutable valueAt1 = 0
    let mutable pos = 0
    for i = 1 to 50_000_000 do
        pos <- (pos + moves) % i + 1
        if pos = 1 then valueAt1 <- i
    valueAt1