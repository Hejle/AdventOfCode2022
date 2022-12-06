open System.IO 

type Assignment(assignment :string) =
    let x = assignment.Split '-'
    member this.Beginning = x[0]
    member this.End = x[1]
    override this.ToString() = $"{this.Beginning}-{this.End}"

type AssignmentPair(assignment1: Assignment, assignment2: Assignment) =
    member this.Assignment1 = assignment1
    member this.Assignment2 = assignment2
    override this.ToString() = $"{this.Assignment1.Beginning}-{this.Assignment1.End},{this.Assignment2.Beginning}-{this.Assignment2.End}"

let AssignmentContains (assignment: Assignment) (otherAssignment: Assignment)  =
    assignment.Beginning <= otherAssignment.Beginning && assignment.End >= otherAssignment.End

let AssignmentPairContains (assignmentPair: AssignmentPair) =
    if 
        AssignmentContains assignmentPair.Assignment1 assignmentPair.Assignment2 || 
        AssignmentContains assignmentPair.Assignment2 assignmentPair.Assignment1 
    then
        1
    else
        0

let ConvertToAssignmentPairs (assignment: string) =
    let assignmentPairArray = assignment.Split ','
    let assignment1 = new Assignment(assignmentPairArray[0])
    let assignment2 = new Assignment(assignmentPairArray[1])
    let assignmentPair = new AssignmentPair(assignment1, assignment2)
    assignmentPair

let input = File.ReadAllLines "input.txt"

let Pairs = input |> Array.map ConvertToAssignmentPairs |> Array.map AssignmentPairContains


input
|> Array.map ConvertToAssignmentPairs
|> Array.map AssignmentPairContains
|> Array.sum
|> printfn "Part 1: %i"