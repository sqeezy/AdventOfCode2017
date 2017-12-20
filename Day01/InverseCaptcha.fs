namespace InverseCaptcha
open System

module InverseCaptcha =

    let digits string = Seq.map (Char.ToString >> Int32.Parse) string |> Seq.toList

    let withTail list = Seq.last list :: list

    let equalNeighbours : seq<int> -> seq<int[]> = Seq.windowed 2 >> Seq.filter(fun a -> a.[0] = a.[1])


    let splitInHalfs (list : list<int>) = (List.take (list.Length/2) list, List.skip (list.Length/2) list)
    let computeSameHalfWayArround num =
        let (l,r)=num 
                 |> digits 
                 |> splitInHalfs

        List.zip l r
          |> Seq.filter (fun (x,y)-> x=y)
          |> Seq.sumBy (fun (x,y)->x+y)

    let computeSameNeighbourSum num = num
                                      |> digits
                                      |> withTail
                                      |> Seq.windowed 2
                                      |> Seq.filter(fun a -> a.[0] = a.[1])
                                      |> Seq.sumBy Seq.head 