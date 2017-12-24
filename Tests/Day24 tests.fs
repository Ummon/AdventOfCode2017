namespace AdventOfCode2017.Tests

open System
open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day24 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input =
            [|
                "0/2"
                "2/2"
                "2/3"
                "3/4"
                "3/5"
                "0/1"
                "10/1"
                "9/10"
            |] |> Day24.parseInput
        let bridges = Day24.bridges input
        Day24.maxBridge bridges =! 31

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input =
            [|
                "0/2"
                "2/2"
                "2/3"
                "3/4"
                "3/5"
                "0/1"
                "10/1"
                "9/10"
            |] |> Day24.parseInput
        let bridges = Day24.bridges input
        Day24.longestBridge bridges =! 19