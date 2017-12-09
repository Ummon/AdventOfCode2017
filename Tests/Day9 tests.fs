namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day9 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day9.score "{}" |> fst =! 1
        Day9.score "{{{}}}" |> fst =! 6
        Day9.score "{{},{}}" |> fst =! 5
        Day9.score "{{{},{},{{}}}}" |> fst =! 16
        Day9.score "{<a>,<a>,<a>,<a>}" |> fst =! 1
        Day9.score "{{<ab>},{<ab>},{<ab>},{<ab>}}" |> fst =! 9
        Day9.score "{{<!!>},{<!!>},{<!!>},{<!!>}}" |> fst =! 9
        Day9.score "{{<a!>},{<a!>},{<a!>},{<ab>}}" |> fst =! 3

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day9.score "<>" |> snd =! 0
        Day9.score "<random characters>" |> snd =! 17
        Day9.score "<<<<>" |> snd =! 3
        Day9.score "<{!>}>" |> snd =! 2
        Day9.score "<!!>" |> snd =! 0
        Day9.score "<!!!>>" |> snd =! 0
        Day9.score """<{o"i!a,<{i<a>""" |> snd =! 10