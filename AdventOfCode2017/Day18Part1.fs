module AdventOfCode2017.Day18Part1

open System

type From =
    | FromReg of char
    | FromValue of int64

type Instruction =
    | Sound of From
    | Set of char * From
    | Add of char * From
    | Mul of char * From
    | Mod of char * From
    | Recover of char
    | Jump of From * From

let parseInput (lines : string[]) : Instruction[] =
    let readFrom (str : string) = if Char.IsLetter str.[0] then FromReg str.[0] else FromValue (int64 str)
    lines
    |> Array.map (
        fun line ->
            match line.Split ' ' with
            | [| "snd"; v |]    -> Sound (readFrom v)
            | [| "set"; reg; v |] -> Set (reg.[0], readFrom v)
            | [| "add"; reg; v |] -> Add (reg.[0], readFrom v)
            | [| "mul"; reg; v |] -> Mul (reg.[0], readFrom v)
            | [| "mod"; reg; v |] -> Mod (reg.[0], readFrom v)
            | [| "rcv"; reg |]    -> Recover reg.[0]
            | [| "jgz"; v1; v2 |] -> Jump (readFrom v1, readFrom v2)
            | _ -> failwithf "Can't parse line: %s" line
    )

type Register = Map<char, int64>

let run (instructions : Instruction[]) =
    let rec exec (register : Register) (cursor : int) (lastSoundPlayed : int64) : int64 =
        let get = function FromReg reg -> register |> Map.tryFind reg |> Option.defaultValue 0L | FromValue v -> v
        let set (reg : char) (v : int64) = register |> Map.add reg v

        match instructions.[cursor] with
        | Sound from -> exec register (cursor + 1) (get from)
        | Set (reg, from) -> exec (set reg (get from)) (cursor + 1) lastSoundPlayed
        | Add (reg, from) -> exec (set reg (get (FromReg reg) + get from)) (cursor + 1) lastSoundPlayed
        | Mul (reg, from) -> exec (set reg (get (FromReg reg) * get from)) (cursor + 1) lastSoundPlayed
        | Mod (reg, from) -> exec (set reg (get (FromReg reg) % get from)) (cursor + 1) lastSoundPlayed
        | Recover reg ->
            if lastSoundPlayed <> 0L && get (FromReg reg) <> 0L then
                lastSoundPlayed
            else
                exec register (cursor + 1) lastSoundPlayed
        | Jump (from1, from2) -> exec register (cursor + if get from1 > 0L then get from2 |> int else 1) lastSoundPlayed

    exec Map.empty 0 0L
