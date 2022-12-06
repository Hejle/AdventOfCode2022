open System.IO

let mutable messageSize: int = 1

let GetMarkerStart (message: string) =
    let mutable messageList = Seq.toList message
    let mutable result = 0
    let mutable running = true
    let mutable i = 0
    while running do
        let marker =  List.take messageSize messageList
        let distinctMarker = List.distinct marker
        if marker.Length = distinctMarker.Length then
            running <- false
            result <- i+messageSize
        messageList <- List.removeAt 0 messageList
        i <- i+1
    result

let PrintForAllInList (inputs) =
    for input in inputs do
        input |> printfn "Start Marker is: %i"
    ()


let input = File.ReadAllLines "input.txt"

printfn $"Part 1"
messageSize <- 4

input 
|> Array.toList
|> List.map GetMarkerStart
|> PrintForAllInList
|> ignore

printfn $"Part 2"
messageSize <- 14

input 
|> Array.toList
|> List.map GetMarkerStart
|> PrintForAllInList
|> ignore