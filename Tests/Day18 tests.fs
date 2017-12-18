namespace AdventOfCode2017.Tests

open System
open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day18 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input =
            [|
                "set a 1"
                "add a 2"
                "mul a a"
                "mod a 5"
                "snd a"
                "set a 0"
                "rcv a"
                "jgz a -1"
                "set a 1"
                "jgz a -2"
            |]
        Day18Part1.run (Day18Part1.parseInput input) =! 4L

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input =
            [|
                "snd 1"
                "snd 2"
                "snd p"
                "rcv a"
                "rcv b"
                "rcv c"
                "rcv d"
            |]
        Day18Part2.run (Day18Part2.parseInput input) =! 3