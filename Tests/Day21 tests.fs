namespace AdventOfCode2017.Tests

open System
open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day21 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``From web page`` () =
        let input =
            [|
                "../.# => ##./#../..."
                ".#./..#/### => #..#/..../..../#..#"
            |] |> Day21.parseInput
        Day21.fractalArt input 2 =! 12