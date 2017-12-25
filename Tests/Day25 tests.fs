namespace AdventOfCode2017.Tests

open System
open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day25 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input =
            [|
                "Begin in state A."
                "Perform a diagnostic checksum after 6 steps."
                ""
                "In state A:"
                "  If the current value is 0:"
                "    - Write the value 1."
                "    - Move one slot to the right."
                "    - Continue with state B."
                "  If the current value is 1:"
                "    - Write the value 0."
                "    - Move one slot to the left."
                "    - Continue with state B."
                ""
                "In state B:"
                "  If the current value is 0:"
                "    - Write the value 1."
                "    - Move one slot to the left."
                "    - Continue with state A."
                "  If the current value is 1:"
                "    - Write the value 1."
                "    - Move one slot to the right."
                "    - Continue with state A."
            |] |> Day25.parseInput
        Day25.checksum input =! 3

    [<Fact>]
    let ``(Part2) From web page`` () =
        ()