module AdventOfCode2017.Main

open System.IO
open System

let day1 () =
    let captcha = File.ReadAllText "Data/day1.input" |> Day1.parseInput
    sprintf "part1 = %A, part2 = %A" (Day1.solveCaptcha1 captcha) (Day1.solveCaptcha2 captcha)

let day2 () =
    let array = File.ReadAllText "Data/day2.input" |> Day2.parseInput
    sprintf "part1 = %A, part2 = %A" (Day2.checksum1 array) (Day2.checksum2 array)

let day3 () =
    let input = 325489
    sprintf "part1 = %A, part2 = %A" (Day3.spiralManhattanDistanceSum input) (Day3.spiralAdjacentSumBiggerThan input)

let day4 () =
    let input = File.ReadAllLines "Data/day4.input"
    sprintf "part1 = %A, part2 = %A" (Day4.nbPassphrasesValid Day4.passphraseValid input) (Day4.nbPassphrasesValid Day4.passphraseValidAnagram input)

let day5 () =
    let input = File.ReadAllText "Data/day5.input"
    sprintf "part1 = %A, part2 = %A" (Day5.nbSteps1 (Day5.parseInput input)) (Day5.nbSteps2 (Day5.parseInput input))

let doDay (n : int) =
    let result =
        match n with
        | 1 -> day1 ()
        | 2 -> day2 ()
        | 3 -> day3 ()
        | 4 -> day4 ()
        | 5 -> day5 ()
        | _ -> raise <| NotImplementedException ()
    printfn "Result of day %i: %s" n result

[<EntryPoint>]
let main argv =
    printfn "https://adventofcode.com/2017"

    if argv.Length > 0 then
        doDay (int argv.[0])
    else
        for d = 1 to 25 do
            doDay d
    0
