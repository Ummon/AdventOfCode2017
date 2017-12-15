namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day09 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day09.score "{}" |> fst =! 1
        Day09.score "{{{}}}" |> fst =! 6
        Day09.score "{{},{}}" |> fst =! 5
        Day09.score "{{{},{},{{}}}}" |> fst =! 16
        Day09.score "{<a>,<a>,<a>,<a>}" |> fst =! 1
        Day09.score "{{<ab>},{<ab>},{<ab>},{<ab>}}" |> fst =! 9
        Day09.score "{{<!!>},{<!!>},{<!!>},{<!!>}}" |> fst =! 9
        Day09.score "{{<a!>},{<a!>},{<a!>},{<ab>}}" |> fst =! 3

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day09.score "<>" |> snd =! 0
        Day09.score "<random characters>" |> snd =! 17
        Day09.score "<<<<>" |> snd =! 3
        Day09.score "<{!>}>" |> snd =! 2
        Day09.score "<!!>" |> snd =! 0
        Day09.score "<!!!>>" |> snd =! 0
        Day09.score """<{o"i!a,<{i<a>""" |> snd =! 10