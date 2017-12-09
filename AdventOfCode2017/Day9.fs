module AdventOfCode2017.Day9

let score (input : string) =
    let rec next (l : int) (lSum : int) (gb : bool) (gbSize : int) =
        function
        | '{' :: tail when not gb -> next (l + 1) (lSum + l) gb gbSize tail
        | '}' :: tail when not gb -> next (l - 1) lSum gb gbSize tail
        | '<' :: tail when not gb -> next l lSum true gbSize tail
        | '!' :: _ :: tail when gb -> next l lSum gb gbSize tail
        | '>' :: tail when gb -> next l lSum false gbSize tail
        | a :: tail -> next l lSum gb (gbSize + if gb then 1 else 0) tail
        | [] -> lSum, gbSize
    List.ofSeq input |> next 1 0 false 0