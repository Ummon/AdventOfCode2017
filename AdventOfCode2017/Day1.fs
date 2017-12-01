module AdventOfCode2017.Day1

let readDigit d = int d - int '0'

let solveCaptcha (shift : int) (captcha : string) =
    let ns = captcha.ToCharArray () |> Array.map readDigit
    let l = ns.Length
    [ for i in 0 .. l - 1 -> if ns.[i] = ns.[(i + shift) % l] then ns.[i] else 0 ] |> List.sum

let solveCaptcha1 = solveCaptcha 1
let solveCaptcha2 captcha = solveCaptcha (String.length captcha / 2) captcha
