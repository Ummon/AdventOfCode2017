module AdventOfCode2017.Day1

let readDigit d = int d - 48

let solveCaptchaPart1 (captcha : string) =
    let numbers = captcha.ToCharArray () |> List.ofArray |> List.map readDigit
    (List.last numbers :: numbers) |> List.pairwise |> List.map (fun (a, b) -> if a = b then a else 0) |> List.sum

let solveCaptchaPart2 (captcha : string) =
    let numbers = captcha.ToCharArray () |> Array.map readDigit
    let l = numbers.Length
    [ for i in 0 .. l - 1 -> if numbers.[i] = numbers.[(i + l / 2) % l] then numbers.[i] else 0 ] |> List.sum
