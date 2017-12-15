namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day08 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input =
            [|
                "b inc 5 if a > 1"
                "a inc 1 if b < 5"
                "c dec -10 if a >= 1"
                "c inc -20 if c == 10"
            |]
        let p1, _ = Day08.execute (Day08.parseInput input)
        p1 = 1

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input =
            [|
                "b inc 5 if a > 1"
                "a inc 1 if b < 5"
                "c dec -10 if a >= 1"
                "c inc -20 if c == 10"
            |]
        let _, p2 = Day08.execute (Day08.parseInput input)
        p2 = 10