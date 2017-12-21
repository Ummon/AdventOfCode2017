module AdventOfCode2017.Day20

open System

type Vec =
    { X : float; Y : float; Z : float }
    with
        member this.ManhattanNorm = abs this.X  + abs this.Y + abs this.Z

type Particule =
    { Pos : Vec; V : Vec; A : Vec }

let parseInput (input : string[]) : Particule[] =
    input
    |> Array.map (
        fun line ->
            let raw = line.Split ([| 'p'; 'v'; 'a'; '='; '<'; '>'; ' '; ',' |], StringSplitOptions.RemoveEmptyEntries)
            {
                Pos = { X = float raw.[0]; Y = float raw.[1]; Z = float raw.[2] }
                V   = { X = float raw.[3]; Y = float raw.[4]; Z = float raw.[5] }
                A   = { X = float raw.[6]; Y = float raw.[7]; Z = float raw.[8] }
            }
    )

let nearestZero (particules : Particule[]) : int =
    particules |> Array.indexed |> Array.minBy (fun (_, p) -> p.A.ManhattanNorm, p.V.ManhattanNorm, p.Pos.ManhattanNorm) |> fst

let collide (p1 : Particule) (p2 : Particule) : int option =
    // https://www.wolframalpha.com/input/?i=solve+a%2B(b%2Bc%2F2)*t%2B1%2F2*c*t%5E2+-+d-(e%2Bf%2F2)*t-1%2F2*f*t%5E2+%3D+0
    let t a b c d e f =
        let denom = 2. * (c - f)
        if denom = 0. then
            [ (d - a) / (b - e) ] // 0 / 0 -> NaN (particules have the same properties), n / 0 -> infinite (particules don't collide)
        else
            let root = (2. * b + c - 2. * e - f) ** 2. - 8. * (a - d) * (c - f)
            if root < 0. then
                [ Double.PositiveInfinity ]
            else
                let f sign = (-2. * b - c + 2. * e + f + sign * sqrt root) / denom
                [ f 1.; f -1. ] |> List.filter ((<=) 0.)

    let ts =
        [
            yield! t p1.Pos.X p1.V.X p1.A.X p2.Pos.X p2.V.X p2.A.X
            yield! t p1.Pos.Y p1.V.Y p1.A.Y p2.Pos.Y p2.V.Y p2.A.Y
            yield! t p1.Pos.Z p1.V.Z p1.A.Z p2.Pos.Z p2.V.Z p2.A.Z
        ]

    let nbOfNaN = ts |> List.sumBy (fun t -> if Double.IsNaN t then 1 else 0)

    let tsInt =
        ts |> List.choose (
            fun t ->
                let tRound = Math.Round (t, 4) * 10000. |> int
                if tRound % 10000 = 0 then Some tRound else None
        )

    tsInt |> List.groupBy id |> List.tryPick (fun (t, ts) -> if List.length ts = (3 - nbOfNaN) then Some t else None)

let nbAlive (particules : Particule[]) : int =
    let nbDestroyed =
        [
            for i = 0 to particules.Length - 1 do
                for j = i + 1 to particules.Length - 1 do
                    let p1, p2 = particules.[i], particules.[j]
                    match collide p1 p2 with
                    | Some t ->
                        yield t, i
                        yield t, j
                    | _ -> ()
        ]
        |> List.groupBy (fun (t, _) -> t)
        |> List.sortBy (fun (t, _) -> t)
        |> List.map snd
        |> List.fold (
            fun destroyedParticules particules ->
                let collidedParticules = (particules |> List.map snd |> Set.ofList) - destroyedParticules
                if collidedParticules |> Set.count > 1 then
                    destroyedParticules + collidedParticules
                else
                    destroyedParticules
        ) Set.empty
        |> Set.count
    particules.Length - nbDestroyed
