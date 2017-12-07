module AdventOfCode2017.Day7

open System
open System.Linq
open System.Collections.Generic

type Tower =
    {
        Name : string
        Weight : int
        Above : List<Tower>
    }

type Input = (Tower * string list) list

let parseInput (lines : string list) : Input =
    lines
    |> List.map (
        fun line ->
            let items = line.Split ([| '\r'; '\t'; ' '; ','; ')'; '(' |], StringSplitOptions.RemoveEmptyEntries)
            {
                Name = items.[0]
                Weight = int items.[1]
                Above = List<Tower> ()
            },
            [ for i in 3 .. items.Length - 1 -> items.[i] ]
    )

let buildTower (input : Input) : Tower =
    let rootTowers = Dictionary<string, Tower> ()

    for tower, _ in input do
        rootTowers.Add (tower.Name, tower)

    for tower, towersAbove in input do
        for towerAbove in towersAbove do
            tower.Above.Add rootTowers.[towerAbove]
            rootTowers.Remove towerAbove |> ignore

    rootTowers.First().Value

// Returns the tower and its corrected weight.
let rec findUnbalanced (tower : Tower) : (Tower * int) option =
    let rec weight tower =
        tower.Weight + (tower.Above |> Seq.map weight |> Seq.sum)

    let towersByWeight = tower.Above |> Seq.groupBy weight

    if towersByWeight |> Seq.length > 1 then
        let unbalanced = towersByWeight |> Seq.minBy (snd >> Seq.length)
        let others = towersByWeight |> Seq.maxBy (snd >> Seq.length)
        let delta = fst others - fst unbalanced
        let unbalanced' = unbalanced |> snd |> Seq.head
        findUnbalanced unbalanced' |> Option.orElse (Some (unbalanced', unbalanced'.Weight + delta))
    else
        tower.Above |> Seq.tryPick (fun t -> findUnbalanced t)
