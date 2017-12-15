namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day02 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input =
            "5 1 9 5
             7 5 3
             2 4 6 8"
        Day02.checksum1 (Day02.parseInput input) =! 18

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input =
            "5 9 2 8
             9 4 7 3
             3 8 6 5"
        Day02.checksum2 (Day02.parseInput input) =! 9