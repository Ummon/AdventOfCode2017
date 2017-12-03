namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day3 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day3.spiralManhattanDistanceSum 12 =! 3
        Day3.spiralManhattanDistanceSum 23 =! 2
        Day3.spiralManhattanDistanceSum 1024 =! 31

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day3.spiralAdjacentSumBiggerThan 1 =! 2
        Day3.spiralAdjacentSumBiggerThan 2 =! 4
        Day3.spiralAdjacentSumBiggerThan 3 =! 4
        Day3.spiralAdjacentSumBiggerThan 4 =! 5
        Day3.spiralAdjacentSumBiggerThan 5 =! 10
        Day3.spiralAdjacentSumBiggerThan 20 =! 23
        Day3.spiralAdjacentSumBiggerThan 100 =! 122
        Day3.spiralAdjacentSumBiggerThan 500 =! 747