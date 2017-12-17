namespace AdventOfCode2017.Tests

open System
open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day16 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input = "s1,x3/4,pe/b"
        Day16.dance 5 1 (Day16.parseInput input) =! "baedc"

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input = "s1,x3/4,pe/b"
        Day16.dance 5 2 (Day16.parseInput input) =! "ceadb"