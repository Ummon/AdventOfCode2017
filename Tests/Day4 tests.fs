namespace AdventOfCode2017.Tests

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2017

type ``Day4 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Assert.True (Day4.passphraseValid "aa bb cc dd ee")
        Assert.False (Day4.passphraseValid "aa bb cc dd aa")
        Assert.True (Day4.passphraseValid "aa bb cc dd aaa")

    [<Fact>]
    let ``(Part2) From web page`` () =
        Assert.True (Day4.passphraseValidAnagram "abcde fghij")
        Assert.False (Day4.passphraseValidAnagram "abcde xyz ecdab")
        Assert.True (Day4.passphraseValidAnagram "a ab abc abd abf abj")
        Assert.True (Day4.passphraseValidAnagram "iiii oiii ooii oooi oooo")
        Assert.False (Day4.passphraseValidAnagram "oiii ioii iioi iiio")