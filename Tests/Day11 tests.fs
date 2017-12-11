namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day11 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day11.distanceInHex (Day11.parseInput "ne,ne,ne") |> fst =! 3
        Day11.distanceInHex (Day11.parseInput "ne,ne,sw,sw") |> fst =! 0
        Day11.distanceInHex (Day11.parseInput "ne,ne,s,s") |> fst =! 2
        Day11.distanceInHex (Day11.parseInput "se,sw,se,sw,sw") |> fst =! 3

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day11.distanceInHex (Day11.parseInput "ne,ne,ne") |> snd =! 3
        Day11.distanceInHex (Day11.parseInput "ne,ne,sw,sw") |> snd =! 2
        Day11.distanceInHex (Day11.parseInput "ne,ne,s,s") |> snd =! 2
        Day11.distanceInHex (Day11.parseInput "se,sw,se,sw,sw") |> snd =! 3