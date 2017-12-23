namespace AdventOfCode2017.Tests

open System
open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day22 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input =
            [|
                "..#"
                "#.."
                "..."
            |] |> Day22.parseInput
        Day22.infection1 input =! 5587

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input =
            [|
                "..#"
                "#.."
                "..."
            |] |> Day22.parseInput
        Day22.infection2 input =! 2511944