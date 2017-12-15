namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day01 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day01.solveCaptcha1 (Day01.parseInput "1122") =! 3
        Day01.solveCaptcha1 (Day01.parseInput "1111") =! 4
        Day01.solveCaptcha1 (Day01.parseInput "1234") =! 0
        Day01.solveCaptcha1 (Day01.parseInput "91212129") =! 9

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day01.solveCaptcha2 (Day01.parseInput "1212") =! 6
        Day01.solveCaptcha2 (Day01.parseInput "1221") =! 0
        Day01.solveCaptcha2 (Day01.parseInput "123425") =! 4
        Day01.solveCaptcha2 (Day01.parseInput "123123") =! 12
        Day01.solveCaptcha2 (Day01.parseInput "12131415") =! 4
