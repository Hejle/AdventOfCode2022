open System.IO 
open System.Collections.Generic

let ScoreMap =
    let lowercaseScore = List.zip [ 'a'.. 'z' ] [ 1..26 ]
    let uppercaseScore = List.zip [ 'A'.. 'Z' ] [ 27..52 ]
    let result = lowercaseScore |> List.append uppercaseScore
    Map result

let MapGroup (input: char * seq<char>) =
    let stringValue = fst input |> string
    let stringLength = snd input |> Seq.length
    (stringValue, stringLength)

let TransformGroup (group: seq<char * seq<char>>) =
    let groupList = Seq.toList group |> List.map MapGroup
    groupList

let PrintCompartments (bag: string list) =
    let back = new Dictionary<string, int>()
    let compartment1 = new Dictionary<string, int>()
    let compartment2 = new Dictionary<string, int>()
    let compartmentOneValues = bag[0] |> Seq.toList |> Seq.groupBy (fun x -> x) |> TransformGroup
    let compartmentTwoValues = bag[1] |> Seq.toList |> Seq.groupBy (fun x -> x) |> TransformGroup
    0

let ScoreOfChars(charList) =
    let mutable score = 0
    for characther in charList do
        score <- score + ScoreMap[characther]
    score

let FindSameChars (input: string list): char list =
    let compartmentOneSet = new HashSet<char>()
    let compartmentTwoSet = new HashSet<char>()
    let dublicateList = new HashSet<char>()
    compartmentOneSet.UnionWith(Seq.toList input[0])
    compartmentTwoSet.UnionWith(Seq.toList input[1])
    for characther in compartmentTwoSet do
        if compartmentOneSet.Contains characther then dublicateList.Add characther |> ignore
    Seq.toList dublicateList

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
