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
            let a = line.Split ([| ' '; ',' |], StringSplitOptions.RemoveEmptyEntries)
            yield { Name = a.[0]; Neighbors = List<Graph> () }, a.[2 .. a.Length - 1]
    ]

let f (input : (Graph * string[]) list) =
    let toVisit = Dictionary<string, Graph> ()

    for g, names in input do
        toVisit.Add (g.Name, g)
        for name in names do
            for g', _ in input do
                if g'.Name = name then
                    g'.Neighbors.Add (g)
                    g.Neighbors.Add (g')

    let visited = List<Dictionary<string, Graph>> ()

    let rec visit (g : Graph) (dic : Dictionary<string, Graph>) =
        if dic.ContainsKey g.Name |> not then
            toVisit.Remove g.Name |> ignore
            dic.Add (g.Name, g)
            for n in g.Neighbors do
                visit n dic

    while toVisit.Count > 0 do
        let dic = Dictionary<string, Graph> ()
        visited.Add dic
        visit (toVisit.First().Value) dic

    visited.First().Count, visited.Count

