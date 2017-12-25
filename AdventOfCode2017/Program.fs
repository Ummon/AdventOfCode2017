module AdventOfCode2017.Main

open System.IO
open System

let day01 () =
    let captcha = File.ReadAllText "Data/day01.input" |> Day01.parseInput
    sprintf "part1 = %A, part2 = %A" (Day01.solveCaptcha1 captcha) (Day01.solveCaptcha2 captcha)

let day02 () =
    let array = File.ReadAllText "Data/day02.input" |> Day02.parseInput
    sprintf "part1 = %A, part2 = %A" (Day02.checksum1 array) (Day02.checksum2 array)

let day03 () =
    let input = File.ReadAllText "Data/day03.input" |> int
    sprintf "part1 = %A, part2 = %A" (Day03.spiralManhattanDistanceSum input) (Day03.spiralAdjacentSumBiggerThan input)

let day04 () =
    let input = File.ReadAllLines "Data/day04.input"
    sprintf "part1 = %A, part2 = %A" (Day04.nbPassphrasesValid Day04.passphraseValid input) (Day04.nbPassphrasesValid Day04.passphraseValidAnagram input)

let day05 () =
    let input = File.ReadAllText "Data/day05.input" |> Day05.parseInput
    sprintf "part1 = %A, part2 = %A" (Day05.nbSteps1 input) (Day05.nbSteps2 input)

let day06 () =
    let input = File.ReadAllText "Data/day06.input" |> Day06.parseInput
    let part1, part2 = Day06.nbRedistribution input
    sprintf "part1 = %A, part2 = %A" part1 part2

let day07 () =
    let input = File.ReadAllLines "Data/day07.input" |> List.ofArray |> Day07.parseInput
    let tower = Day07.buildTower input
    sprintf "part1 = %A, part2 = %A" tower.Name (Day07.findUnbalanced tower |> Option.map (fun (t, w) -> t.Name, w))

let day08 () =
    let input = File.ReadAllLines "Data/day08.input" |> Day08.parseInput
    let part1, part2 = Day08.execute input
    sprintf "part1 = %A, part2 = %A" part1 part2

let day09 () =
    let input = File.ReadAllText "Data/day09.input"
    let part1, part2 = Day09.score input
    sprintf "part1 = %A, part2 = %A" part1 part2

let day10 () =
    let input = File.ReadAllText "Data/day10.input"
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
    let input = File.ReadAllLines "Data/day15.input"
    let genA, genB = int64 input.[0], int64 input.[1]
    sprintf "part1 = %A, part2 = %A" (Day15.nbSimilarities1 genA genB) (Day15.nbSimilarities2 genA genB)

let day16 () =
    let input = File.ReadAllText "Data/day16.input" |> Day16.parseInput
    sprintf "part1 = %A, part2 = %A" (Day16.dance 16 1 input) (Day16.dance 16 1_000_000_000 input)

let day17 () =
    let input = File.ReadAllText "Data/day17.input" |> int
    sprintf "part1 = %A, part2 = %A" (Day17.spinLock1 input) (Day17.spinLock2 input)

let day18 () =
    let input = File.ReadAllLines "Data/day18.input"
    sprintf "part1 = %A, part2 = %A" (Day18Part1.run (Day18Part1.parseInput input)) (Day18Part2.run (Day18Part2.parseInput input))

let day19 () =
    let input = File.ReadAllLines "Data/day19.input"
    let word, length = Day19.followThePath input
    sprintf "part1 = %A, part2 = %A" word length

let day20 () =
    let input = File.ReadAllLines "Data/day20.input" |> Day20.parseInput
    sprintf "part1 = %A, part2 = %A" (Day20.nearestZero input) (Day20.nbAlive input)

let day21 () =
    let input = File.ReadAllLines "Data/day21.input" |> Day21.parseInput
    sprintf "part1 = %A, part2 = %A" (Day21.fractalArt input 5) (Day21.fractalArt input 18)

let day22 () =
    let input = File.ReadAllLines "Data/day22.input" |> Day22.parseInput
    sprintf "part1 = %A, part2 = %A" (Day22.infection1 input) (Day22.infection2 input)

let day23 () =
    let input = File.ReadAllLines "Data/day23.input" |> Day23.parseInput
    sprintf "part1 = %A, part2 = %A" (Day23.run input) (Day23.debug ())

let day24 () =
    let input = File.ReadAllLines "Data/day24.input" |> Day24.parseInput
    let bridges = Day24.bridges input
    sprintf "part1 = %A, part2 = %A" (Day24.maxBridge bridges) (Day24.longestBridge bridges)

let day25 () =
    let input = File.ReadAllLines "Data/day25.input" |> Day25.parseInput
    sprintf "part1 = %A, part2 = %A" (Day25.checksum input) ()

let doDay (n : int) =
    let sw = Diagnostics.Stopwatch ()
    sw.Start ()
    let result =
        match n with
        |  1 -> day01 ()
        |  2 -> day02 ()
        |  3 -> day03 ()
        |  4 -> day04 ()
        |  5 -> day05 ()
        |  6 -> day06 ()
        |  7 -> day07 ()
        |  8 -> day08 ()
        |  9 -> day09 ()
        | 10 -> day10 ()
        | 11 -> day11 ()
        | 12 -> day12 ()
        | 13 -> day13 ()
        | 14 -> day14 ()
        | 15 -> day15 ()
        | 16 -> day16 ()
        | 17 -> day17 ()
        | 18 -> day18 ()
        | 19 -> day19 ()
        | 20 -> day20 ()
        | 21 -> day21 ()
        | 22 -> day22 ()
        | 23 -> day23 ()
        | 24 -> day24 ()
        | 25 -> day25 ()
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
