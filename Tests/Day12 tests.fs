namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day12 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input =
            [|
                "0 <-> 2"
                "1 <-> 1"
                "2 <-> 0, 3, 4"
                "3 <-> 2, 4"
                "4 <-> 2, 3, 6"
                "5 <-> 6"
                "6 <-> 4, 5"
            |]
        Day12.parseInput input |> Day12.graphCount |> fst =! 6

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input =
            [|
                "0 <-> 2"
                "1 <-> 1"
                "2 <-> 0, 3, 4"
                "3 <-> 2, 4"
                "4 <-> 2, 3, 6"
                "5 <-> 6"
                "6 <-> 4, 5"
            |]
        Day12.parseInput input |> Day12.graphCount |> snd =! 2