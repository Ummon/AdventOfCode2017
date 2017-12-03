module AdventOfCode2017.Main

open System.IO

let day1 () =
    let captcha = File.ReadAllText "Data/day1" |> Day1.parseInput
    sprintf "part1 = %A, part2 = %A" (Day1.solveCaptcha1 captcha) (Day1.solveCaptcha2 captcha)

let day2 () =
    let array = File.ReadAllText "Data/day2" |> Day2.parseInput
    sprintf "part1 = %A, part2 = %A" (Day2.checksum1 array) (Day2.checksum2 array)

let day3 () =
    let input = 325489
    sprintf "part1 = %A, part2 = %A" (Day3.spiralManhattanDistanceSum input) (Day3.spiralAdjacentSumBiggerThan input)

let doDay (n : int) =
    let result =
        match n with
        | 2 -> day2 ()
        | 3 -> day3 ()
        | _ -> day1 ()
    printfn "Result of day %i: %s" n result

[<EntryPoint>]
let main argv =
    printfn "https://adventofcode.com/2017"

    if argv.Length > 0 then
        doDay (int argv.[0])
    else
        for d = 1 to 24 do
            doDay d
    0
