open System.IO 

let scissorsPoint = 3
let paperPoint = 2
let rockPoint = 1
let winPoint = 6
let losePoint = 0
let drawPoint = 3

let GetScorePart1 (lines): int =
    let mutable score: int = 0
    for line in lines do
        match line with
        | "A X" -> score <- score + drawPoint + rockPoint
        | "A Y" -> score <- score + winPoint + paperPoint
        | "A Z" -> score <- score + losePoint + scissorsPoint
        | "B X" -> score <- score + losePoint + rockPoint
        | "B Y" -> score <- score + drawPoint + paperPoint
        | "B Z" -> score <- score + winPoint + scissorsPoint
        | "C X" -> score <- score + winPoint + rockPoint
        | "C Y" -> score <- score + losePoint + paperPoint
        | "C Z" -> score <- score + drawPoint + scissorsPoint
        | _ -> ()
    score

let GetScorePart2 (lines): int =
    let mutable score: int = 0
    for line in lines do
        match line with
        | "A X" -> score <- score + losePoint + scissorsPoint
        | "A Y" -> score <- score + drawPoint + rockPoint
        | "A Z" -> score <- score + winPoint + paperPoint
        | "B X" -> score <- score + losePoint + rockPoint
        | "B Y" -> score <- score + drawPoint + paperPoint
        | "B Z" -> score <- score + winPoint + scissorsPoint
        | "C X" -> score <- score + losePoint + paperPoint
        | "C Y" -> score <- score + drawPoint + scissorsPoint
        | "C Z" -> score <- score + winPoint + rockPoint
        | _ -> ()
    score
        
let input = File.ReadAllLines "input.txt"
GetScorePart1 input |> printfn "Part 1 Score: %i"
GetScorePart2 input |> printfn "Part 2 Score: %i"