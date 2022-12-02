open System.IO 

let doStuff lines =
    let mutable calories: int = 0
    let mutable output = []
    for line in lines do
        match line with
        | "" -> output <- calories :: output; calories <- 0
        | var -> calories <- calories + (int)var
    output
        
let input = File.ReadAllLines "input.txt"

let result = doStuff input

List.max result
|> printfn "Part 1: %i"

List.sortDescending result
|> List.take 3
|> List.sum
|> printfn "Part 2: %i"

