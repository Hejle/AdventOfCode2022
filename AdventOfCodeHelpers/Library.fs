namespace AdventOfCodeHelpers

open System.Net.Http

module AocDownloader =

    let client = new HttpClient();


    let getContentAsync (url:string) = 
        async {
            let! response = client.GetAsync(url) |> Async.AwaitTask
            response.EnsureSuccessStatusCode () |> ignore
            let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
            return content
        }