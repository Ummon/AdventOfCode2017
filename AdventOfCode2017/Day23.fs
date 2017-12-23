module AdventOfCode2017.Day23

open System

type From =
    | FromReg of char
    | FromValue of int64

type Instruction =
    | Set of char * From
    | Sub of char * From
    | Mul of char * From
    | Jump of From * From

let parseInput (lines : string[]) : Instruction[] =
    let readFrom (str : string) = if Char.IsLetter str.[0] then FromReg str.[0] else FromValue (int64 str)
    lines
    |> Array.map (
        fun line ->
            match line.Split ' ' with
            | [| "set"; reg; v |] -> Set (reg.[0], readFrom v)
            | [| "sub"; reg; v |] -> Sub (reg.[0], readFrom v)
            | [| "mul"; reg; v |] -> Mul (reg.[0], readFrom v)
            | [| "jnz"; v1; v2 |] -> Jump (readFrom v1, readFrom v2)
            | _ -> failwithf "Can't parse line: %s" line
    )

type Register = Map<char, int64>

let run (instructions : Instruction[]) : int =
    let rec exec (register : Register) (cursor : int) (nbMul : int) : int  =
        let get = function FromReg reg -> register |> Map.tryFind reg |> Option.defaultValue 0L | FromValue v -> v
        let set (reg : char) (v : int64) = register |> Map.add reg v

        if cursor < 0 || cursor >= instructions.Length then
            nbMul
        else
            match instructions.[cursor] with
            | Set (reg, from) -> exec (set reg (get from)) (cursor + 1) nbMul
            | Sub (reg, from) -> exec (set reg (get (FromReg reg) - get from)) (cursor + 1) nbMul
            | Mul (reg, from) -> exec (set reg (get (FromReg reg) * get from)) (cursor + 1) (nbMul + 1)
            | Jump (from1, from2) -> exec register (cursor + if get from1 <> 0L then get from2 |> int else 1) nbMul
    exec Map.empty 0 0

let debug () =
    let mutable b = 99 * 100 + 100000
    let c = b + 17000
    let mutable h = 0

    let mutable ``end`` = false
    while not ``end`` do
        let mutable f = 1
        let mutable d = 2
        let mutable loop = true
        while loop do
            f <- if b % d = 0 then 0 else f
            d <- d + 1
            loop <- d <> b

        if f = 0 then
            h <- h + 1

        ``end`` <- b = c

        b <- b + 17
    h


