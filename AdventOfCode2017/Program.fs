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
    let input = File.ReadAllText "Data/day5.input" |> Day5.parseInput
    sprintf "part1 = %A, part2 = %A" (Day5.nbSteps1 input) (Day5.nbSteps2 input)

let day6 () =
    let input = File.ReadAllText "Data/day6.input" |> Day6.parseInput
    let part1, part2 = Day6.nbRedistribution input
    sprintf "part1 = %A, part2 = %A" part1 part2

let day7 () =
    let input = File.ReadAllLines "Data/day7.input" |> List.ofArray |> Day7.parseInput
    let tower = Day7.buildTower input
    sprintf "part1 = %A, part2 = %A" tower.Name (Day7.findUnbalanced tower |> Option.map (fun (t, w) -> t.Name, w))

let day8 () =
    let input = File.ReadAllLines "Data/day8.input" |> Day8.parseInput
    let part1, part2 = Day8.execute input
    sprintf "part1 = %A, part2 = %A" part1 part2

let day9 () =
    let input = File.ReadAllText "Data/day9.input"
    let part1, part2 = Day9.score input
    sprintf "part1 = %A, part2 = %A" part1 part2

let day10 () =
    let input = "83,0,193,1,254,237,187,40,88,27,2,255,149,29,42,100"
    sprintf "part1 = %A, part2 = %A" (Day10.knotHash1 input 256) (Day10.knotHash2 input)

let day11 () =
    let input = File.ReadAllText "Data/day11.input"
    let part1, part2 = Day11.distanceInHex input
    sprintf "part1 = %A, part2 = %A" part1 part2

let day12 () =
    let input = File.ReadAllLines "Data/day12.input" |> Day12.parseInput
    let part1, part2 = Day12.graphCount input
    sprintf "part1 = %A, part2 = %A" part1 part2

let day13 () =
    let input = File.ReadAllLines "Data/day13.input" |> Day13.parseInput
    let part1, part2 = Day13.severity input
    sprintf "part1 = %A, part2 = %A" part1 part2

let day14 () =
    let input = File.ReadAllText "Data/day14.input"
    sprintf "part1 = %A, part2 = %A" (Day14.nbOfUsedSquares input) (Day14.nbOfConnectedRegions input)

let day15 () =
    let input = File.ReadAllText "Data/day15.input"
    sprintf "part1 = %A, part2 = %A" () ()

let doDay (n : int) =
    let sw = Diagnostics.Stopwatch ()
    sw.Start ()
    let result =
        match n with
        | 1 -> day1 ()
        | 2 -> day2 ()
        | 3 -> day3 ()
        | 4 -> day4 ()
        | 5 -> day5 ()
        | 6 -> day6 ()
        | 7 -> day7 ()
        | 8 -> day8 ()
        | 9 -> day9 ()
        | 10 -> day10 ()
        | 11 -> day11 ()
        | 12 -> day12 ()
        | 13 -> day13 ()
        | 14 -> day14 ()
        | 15 -> day15 ()
        | _ -> raise <| NotImplementedException ()
    printfn "Result of day %i: %s (time : %i ms)" n result sw.ElapsedMilliseconds

[<EntryPoint>]
let main argv =
    printfn "https://adventofcode.com/2017"

    if argv.Length > 0 then
        doDay (int argv.[0])
    else
        for d = 1 to 25 do
            doDay d

    Console.ReadKey () |> ignore
    0
