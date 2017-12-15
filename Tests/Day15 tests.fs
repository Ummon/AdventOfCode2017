namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day15 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let a, b = 65L, 8921L
        Day15.nbSimilarities1 a b =! 588

    [<Fact>]
    let ``(Part2) From web page`` () =
        let a, b = 65L, 8921L
        Day15.nbSimilarities2 a b =! 309