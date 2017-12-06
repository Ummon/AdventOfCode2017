namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day6 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let l, _ = Day6.nbRedistribution [| 0; 2; 7; 0 |]
        l =! 5

    [<Fact>]
    let ``(Part2) From web page`` () =
        let _, cycleLength = Day6.nbRedistribution [| 0; 2; 7; 0 |]
        cycleLength =! 4