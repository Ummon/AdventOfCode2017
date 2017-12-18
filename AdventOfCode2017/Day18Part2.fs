module AdventOfCode2017.Day18Part2

open System
open System.Threading

type From =
    | FromReg of char
    | FromValue of int64

type Instruction =
    | Receive of char
    | Send of From
    | Set of char * From
    | Add of char * From
    | Mul of char * From
    | Mod of char * From
    | Jump of From * From

let parseInput (lines : string[]) : Instruction[] =
    let readFrom (str : string) = if Char.IsLetter str.[0] then FromReg str.[0] else FromValue (int64 str)
    lines
    |> Array.map (
        fun line ->
            match line.Split ' ' with
            | [| "snd"; v |]      -> Send (readFrom v)
            | [| "set"; reg; v |] -> Set (reg.[0], readFrom v)
            | [| "add"; reg; v |] -> Add (reg.[0], readFrom v)
            | [| "mul"; reg; v |] -> Mul (reg.[0], readFrom v)
            | [| "mod"; reg; v |] -> Mod (reg.[0], readFrom v)
            | [| "rcv"; reg |]    -> Receive reg.[0]
            | [| "jgz"; v1; v2 |] -> Jump (readFrom v1, readFrom v2)
            | _ -> failwithf "Can't parse line: %s" line
    )

type Register = Map<char, int64>

type Agent (instructions : Instruction[], id : int) as this =
    let mutable nbSent = 0
    let finishedEvent = new AutoResetEvent false
    let mailbox =
        new MailboxProcessor<int64> (
            fun inbox ->
                let rec exec (register : Register) (cursor : int) : Async<unit> =
                    let get = function FromReg reg -> register |> Map.tryFind reg |> Option.defaultValue 0L | FromValue v -> v
                    let set (reg : char) (v : int64) = register |> Map.add reg v
                    async {
                        match instructions.[cursor] with
                        | Send from ->
                            nbSent <- nbSent + 1
                            this.Other.Value.Post (get from)
                            return! exec register (cursor + 1)
                        | Set (reg, from) -> return! exec (set reg (get from)) (cursor + 1)
                        | Add (reg, from) -> return! exec (set reg (get (FromReg reg) + get from)) (cursor + 1)
                        | Mul (reg, from) -> return! exec (set reg (get (FromReg reg) * get from)) (cursor + 1)
                        | Mod (reg, from) -> return! exec (set reg (get (FromReg reg) % get from)) (cursor + 1)
                        | Receive reg ->
                            let! value = inbox.TryReceive 100
                            match value with
                            | Some value -> return! exec (set reg value) (cursor + 1)
                            | None -> finishedEvent.Set () |> ignore
                        | Jump (from1, from2) ->
                            return! exec register (cursor + if get from1 > 0L then get from2 |> int else 1)
                    }
                exec (Map.ofList [ 'p', int64 id ]) 0
        )

    member val Other : MailboxProcessor<int64> option = None with get, set
    member this.Start () = mailbox.Start ()
    member this.Mailbox = mailbox
    member this.NbSent =
        finishedEvent.WaitOne () |> ignore
        nbSent

let run (instructions : Instruction[]) =
    let agent0 = Agent (instructions, 0)
    let agent1 = Agent (instructions, 1)

    agent0.Other <- Some agent1.Mailbox
    agent1.Other <- Some agent0.Mailbox

    agent0.Start ()
    agent1.Start ()

    agent1.NbSent