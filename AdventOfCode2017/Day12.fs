module AdventOfCode2017.Day12

open System
open System.Linq
open System.Collections.Generic

type Graph =
    {
        Name : string
        Neighbors : List<Graph>
    }

let parseInput (lines : string[]) : (Graph * string[]) list =
    [
        for line in lines do
            let splitLine = line.Split ([| ' '; ',' |], StringSplitOptions.RemoveEmptyEntries)
            yield { Name = splitLine.[0]; Neighbors = List<Graph> () }, splitLine.[2 .. splitLine.Length - 1]
    ]

let graphCount (input : (Graph * string[]) list) =
    let toVisit = Dictionary<string, Graph> ()

    for g, _ in input do
        toVisit.Add (g.Name, g)

    for g, neighbors in input do
        for neighbor in neighbors do
            let g' = toVisit.[neighbor]
            g'.Neighbors.Add g
            g.Neighbors.Add g'

    let visitedGroups = List<Dictionary<string, Graph>> ()

    let rec visit (g : Graph) (dic : Dictionary<string, Graph>) =
        if dic.ContainsKey g.Name |> not then
            toVisit.Remove g.Name |> ignore
            dic.Add (g.Name, g)
            for n in g.Neighbors do
                visit n dic

    while toVisit.Count > 0 do
        let dic = Dictionary<string, Graph> ()
        visitedGroups.Add dic
        visit (toVisit.First().Value) dic

    visitedGroups.First().Count, visitedGroups.Count

