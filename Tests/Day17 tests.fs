namespace AdventOfCode2017.Tests

open System
open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day17 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day17.spinLock1 3 =! 638

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day17.spinLock2 3 =! 1222153