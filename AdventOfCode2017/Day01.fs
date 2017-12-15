module AdventOfCode2017.Day01

let readDigit d = int d - int '0'

let parseInput (str : string) : int[] = str.ToCharArray () |> Array.map readDigit

let solveCaptcha (shift : int) (captcha : int[]) =
    let l = captcha.Length
    [ for i in 0 .. l - 1 -> if captcha.[i] = captcha.[(i + shift) % l] then captcha.[i] else 0 ] |> List.sum

let solveCaptcha1 = solveCaptcha 1
let solveCaptcha2 (captcha : int[]) = solveCaptcha (captcha.Length / 2) captcha
