namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day1 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day1.solveCaptcha1 (Day1.parseInput "1122") =! 3
        Day1.solveCaptcha1 (Day1.parseInput "1111") =! 4
        Day1.solveCaptcha1 (Day1.parseInput "1234") =! 0
        Day1.solveCaptcha1 (Day1.parseInput "91212129") =! 9

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day1.solveCaptcha2 (Day1.parseInput "1212") =! 6
        Day1.solveCaptcha2 (Day1.parseInput "1221") =! 0
        Day1.solveCaptcha2 (Day1.parseInput "123425") =! 4
        Day1.solveCaptcha2 (Day1.parseInput "123123") =! 12
        Day1.solveCaptcha2 (Day1.parseInput "12131415") =! 4
