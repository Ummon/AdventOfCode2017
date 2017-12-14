namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day14 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day14.nbOfUsedSquares "flqrgnkx" =! 8108

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day14.nbOfConnectedRegions "flqrgnkx" =! 1242