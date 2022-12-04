open System.IO 
open System.Collections.Generic

let ScoreMap =
    let lowercaseScore = List.zip [ 'a'.. 'z' ] [ 1..26 ]
    let uppercaseScore = List.zip [ 'A'.. 'Z' ] [ 27..52 ]
    let result = lowercaseScore |> List.append uppercaseScore
    Map result

let ScoreOfChars(charCollection) =
    let mutable score = 0
    for characther in charCollection do
        score <- score + ScoreMap[characther]
    score

let FindSameChars (input: string list): char list =
    let compartmentOneSet = Seq.toList input[0] |> Set.ofList
    let compartmentTwoSet = Seq.toList input[1] |> Set.ofList
    let dublicateSet = new HashSet<char>()
    for characther in compartmentTwoSet do
        if compartmentOneSet.Contains characther then dublicateSet.Add characther |> ignore
    Seq.toList dublicateSet

let CompartmentPart1 (line: string) =
    let compartmentSize = line.Length/2
    let compartment1 = line.Substring(0, compartmentSize)
    let compartment2 = line.Substring(compartmentSize, line.Length-compartmentSize)
    [compartment1; compartment2]

let CompartmentPart2 (bags: string[]) =
    Array.map (fun x -> Seq.toList x) bags 
    |> Array.map (fun x -> Set.ofList x)
    |> Set.intersectMany
    
let input = File.ReadAllLines "input.txt"

input
|> Array.map CompartmentPart1
|> Array.map FindSameChars
|> Array.map ScoreOfChars
|> Array.sum
|> printfn "Part 1: %i"

input
|> Array.chunkBySize 3
|> Array.map CompartmentPart2
|> Array.map ScoreOfChars
|> Array.sum
|> printfn "Part 2: %i"
