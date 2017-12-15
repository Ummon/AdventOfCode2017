namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day05 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day05.nbSteps1 [| 0; 3; 0; 1; -3 |] =! 5

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day05.nbSteps2 [| 0; 3; 0; 1; -3 |] =! 10