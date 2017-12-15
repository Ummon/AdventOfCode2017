namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day03 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day03.spiralManhattanDistanceSum 12 =! 3
        Day03.spiralManhattanDistanceSum 23 =! 2
        Day03.spiralManhattanDistanceSum 1024 =! 31

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day03.spiralAdjacentSumBiggerThan 1 =! 2
        Day03.spiralAdjacentSumBiggerThan 2 =! 4
        Day03.spiralAdjacentSumBiggerThan 3 =! 4
        Day03.spiralAdjacentSumBiggerThan 4 =! 5
        Day03.spiralAdjacentSumBiggerThan 5 =! 10
        Day03.spiralAdjacentSumBiggerThan 20 =! 23
        Day03.spiralAdjacentSumBiggerThan 100 =! 122
        Day03.spiralAdjacentSumBiggerThan 500 =! 747