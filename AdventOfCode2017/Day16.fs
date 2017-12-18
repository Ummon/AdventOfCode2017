module AdventOfCode2017.Day16

open System
open Day06

type DanceMove =
    | Spin of int
    | Exchange of int * int
    | Partner of char * char

let parseInput (input : string) : DanceMove list =
    input.Split ','
    |> List.ofArray
    |> List.map (
        fun move ->
            if move.[0] = 's' then
                Spin (int move.[1..])
            elif move.[0] = 'x' then
                let pos = move.[1..].Split '/'
                Exchange (int pos.[0], int pos.[1])
            else
                Partner (move.[1], move.[3])
    )

let dance (size : int) (nb : int) (moves : DanceMove list) : string =
    let initialState = Array.init size (fun i -> char i + 'a')

    let applyMoves (danceFloor : char[]) =
        let find c = danceFloor |> Array.findIndex ((=) c)
        let swap p1 p2 =
            let tmp = danceFloor.[p1]
            danceFloor.[p1] <- danceFloor.[p2]
            danceFloor.[p2] <- tmp
        for move in moves do
            match move with
            | Spin s ->
                for i = 1 to s do
                    let last = danceFloor.[size - 1]
                    for j in size - 1 .. -1 .. 1 do
                        danceFloor.[j] <- danceFloor.[j - 1]
                    danceFloor.[0] <- last
            | Exchange (p1, p2) ->
                swap p1 p2
            | Partner (a, b) ->
                swap (find a) (find b)

    let cycle =
        ((0, initialState), Seq.initInfinite id)
        ||> Seq.scan (
            fun (_, previous) i ->
                let current = previous.[*]
                applyMoves current
                i + 1, current
        )
        |> Seq.takeWhile (fun (i, state) -> i = 0 || not (state |=| initialState))
        |> Seq.map snd
        |> Array.ofSeq

    cycle.[nb % cycle.Length] |> String