namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day10 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input = "3,4,1,5"
        Day10.knotHash1 input 5 =! "12"

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day10.knotHash2 "" =! "a2582a3a0e66e6e86e3812dcb672a272"
        Day10.knotHash2 "AoC 2017" =! "33efeb34ea91902bb2f59c9920caa6cd"
        Day10.knotHash2 "1,2,3" =! "3efbe78a8d82f29979031a4aa0b16a9d"
        Day10.knotHash2 "1,2,4" =! "63960835bcdc130f0b66d7ff4f6a5a8e"