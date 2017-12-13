namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day13 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input =
            [|
                "0: 3"
                "1: 2"
                "4: 4"
                "6: 4"
            |]
        Day13.severity (Day13.parseInput input) |> fst =! 24


    [<Fact>]
    let ``(Part2) From web page`` () =
        let input =
            [|
                "0: 3"
                "1: 2"
                "4: 4"
                "6: 4"
            |]
        Day13.severity (Day13.parseInput input) |> snd =! 10