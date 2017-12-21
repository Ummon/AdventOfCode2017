namespace AdventOfCode2017.Tests

open System
open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day20 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input =
            [|
                "p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>"
                "p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>"
            |] |> Day20.parseInput

        Day20.nearestZero input =! 0

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input =
            [|
                "p=<-6,0,0>, v=< 3,0,0>, a=< 0,0,0>"
                "p=<-4,0,0>, v=< 2,0,0>, a=< 0,0,0>"
                "p=<-2,0,0>, v=< 1,0,0>, a=< 0,0,0>"
                "p=< 3,0,0>, v=<-1,0,0>, a=< 0,0,0>"
            |] |> Day20.parseInput

        Day20.nbAlive input =! 1