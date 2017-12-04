module AdventOfCode2017.Day4

open System

let forallDistinctPairs (f : string -> string -> bool) (pp : string) =
    let words = pp.Split ' '
    [
        for a = 0 to words.Length - 1 do
            for b in a + 1 .. words.Length - 1 -> f words.[a] words.[b]
    ] |> List.forall not

let passphraseValid = forallDistinctPairs (=)

let isAnagram (w1 : string) (w2 : string) =
    (w1.ToCharArray () |> Array.sort) = (w2.ToCharArray () |> Array.sort)

let passphraseValidAnagram = forallDistinctPairs isAnagram

let nbPassphrasesValid (f : string -> bool) =
    Seq.map f >> Seq.sumBy (fun v -> if v then 1 else 0)