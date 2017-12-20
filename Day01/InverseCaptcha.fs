namespace InverseCaptcha
open System

module InverseCaptcha =

    let digits string = Seq.map (Char.ToString >> Int32.Parse) string |> Seq.toList

    let withTail list = Seq.last list :: list

    let compute num = num
                      |> digits
                      |> withTail
                      |> Seq.windowed 2
                      |> Seq.filter(fun a -> a.[0] = a.[1])
                      |> Seq.sumBy Seq.head 