namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day04 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Assert.True (Day04.passphraseValid "aa bb cc dd ee")
        Assert.False (Day04.passphraseValid "aa bb cc dd aa")
        Assert.True (Day04.passphraseValid "aa bb cc dd aaa")

    [<Fact>]
    let ``(Part2) From web page`` () =
        Assert.True (Day04.passphraseValidAnagram "abcde fghij")
        Assert.False (Day04.passphraseValidAnagram "abcde xyz ecdab")
        Assert.True (Day04.passphraseValidAnagram "a ab abc abd abf abj")
        Assert.True (Day04.passphraseValidAnagram "iiii oiii ooii oooi oooo")
        Assert.False (Day04.passphraseValidAnagram "oiii ioii iioi iiio")