namespace AdventOfCode2017.Tests

open System
open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day19 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input =
            [|
                "     |           "
                "     |  +--+     "
                "     A  |  C     "
                " F---|----E|--+  "
                "     |  |  |  D  "
                "     +B-+  +--+  "
                "                 "
            |]

        Day19.followThePath input |> fst =! "ABCDEF"

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input =
            [|
                "     |           "
                "     |  +--+     "
                "     A  |  C     "
                " F---|----E|--+  "
                "     |  |  |  D  "
                "     +B-+  +--+  "
                "                 "
            |]

        Day19.followThePath input |> snd =! 38