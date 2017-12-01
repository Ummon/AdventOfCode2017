module AdventOfCode2017.Day1

let readDigit d = int d - 48

let solveCaptcha (captcha : string) =
    let numbers = captcha.ToCharArray () |> List.ofArray |> List.map readDigit
    (List.last numbers :: numbers) |> List.pairwise |> List.map (fun (a, b) -> if a = b then a else 0) |> List.sum

