module Tests

open Xunit

[<Fact>]
let ``EfSharpFeaturesTest`` () =
    let sumOfSquares list =
        list 
        |> List.map (fun x -> x * x)
        |> List.sum

    let sum = sumOfSquares [ 1..10 ]
    printf "%d" sum
    printf "%A" [ 1..100 ]


    Assert.True(true)
