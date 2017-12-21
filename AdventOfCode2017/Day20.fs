module AdventOfCode2017.Day20

open System

type Vec =
    { X : float; Y : float; Z : float }
    with
        member this.SquareNorm = this.X ** 2. + this.Y ** 2. + this.Z ** 2.

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
    particules |> Array.indexed |> Array.minBy (fun (_, p) -> p.A.SquareNorm, p.V.SquareNorm, p.Pos.SquareNorm) |> fst

let collide (p1 : Particule) (p2 : Particule) : int64 option =
    let t a b c d e f =
        let denom = 2. * (c - f)
        if denom = 0. then
            (d - a) / (b - e)
        else
            let root = (2. * b + c - 2. * e - f) ** 2. - 8. * (a - d) * (c - f)
            if root < 0. then
                Double.PositiveInfinity
            else
                let f sign = (-2. * b - c + 2. * e + f + sign * sqrt root) / denom
                max (f 1.) (f -1.)

    let ts =
        [
            t p1.Pos.X p1.V.X p1.A.X p2.Pos.X p2.V.X p2.A.X
            t p1.Pos.Y p1.V.Y p1.A.Y p2.Pos.Y p2.V.Y p2.A.Y
            t p1.Pos.Z p1.V.Z p1.A.Z p2.Pos.Z p2.V.Z p2.A.Z
        ]
        |> List.filter (Double.IsNaN >> not)

    if ts |> List.isEmpty then
        Some 0L
    elif ts |> List.exists (fun t -> Double.IsInfinity t || t < 0.) then
        None
    else
        let tsInt = ts |> List.map (fun t -> t * 10. |> int64) // Rounding.
        let h = tsInt |> List.head
        if tsInt |> List.tail |> List.forall ((=) h) then
            Some h
        else
            None

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
