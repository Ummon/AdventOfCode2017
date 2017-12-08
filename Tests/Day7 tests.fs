namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day7 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input =
            [
                "pbga (66)"
                "xhth (57)"
                "ebii (61)"
                "havc (66)"
                "ktlj (57)"
                "fwft (72) -> ktlj, cntj, xhth"
                "qoyq (66)"
                "padx (45) -> pbga, havc, qoyq"
                "tknk (41) -> ugml, padx, fwft"
                "jptl (61)"
                "ugml (68) -> gyxo, ebii, jptl"
                "gyxo (61)"
                "cntj (57)"
            ]
        let tower = Day7.buildTower (Day7.parseInput input)
        tower.Name =! "tknk"

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input =
            [
                "pbga (66)"
                "xhth (57)"
                "ebii (61)"
                "havc (66)"
                "ktlj (57)"
                "fwft (72) -> ktlj, cntj, xhth"
                "qoyq (66)"
                "padx (45) -> pbga, havc, qoyq"
                "tknk (41) -> ugml, padx, fwft"
                "jptl (61)"
                "ugml (68) -> gyxo, ebii, jptl"
                "gyxo (61)"
                "cntj (57)"
            ]
        let tower = Day7.buildTower (Day7.parseInput input)

        match Day7.findUnbalanced tower with
        | Some (tower, weight) ->
            tower.Name =! "ugml"
            weight =! 60
        | None -> failwith "no tower found"

    [<Fact>]
    let ``(Part2) A balanced tree`` () =
        let input =
            [
                "pbga (66)"
                "xhth (57)"
                "ebii (61)"
                "havc (66)"
                "ktlj (57)"
                "fwft (72) -> ktlj, cntj, xhth"
                "qoyq (66)"
                "padx (45) -> pbga, havc, qoyq"
                "tknk (41) -> ugml, padx, fwft"
                "jptl (61)"
                "ugml (60) -> gyxo, ebii, jptl"
                "gyxo (61)"
                "cntj (57)"
            ]
        let tower = Day7.buildTower (Day7.parseInput input)

        Day7.findUnbalanced tower =! None