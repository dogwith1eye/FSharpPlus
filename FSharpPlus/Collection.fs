﻿#nowarn "77"
// Warn FS0077 -> Member constraints with the name 'get_Item' are given special status by the F# compiler as certain .NET types are implicitly augmented with this member. This may result in runtime failures if you attempt to invoke the member constraint from your own code.
// Those .NET types are string and array but they are explicitely handled here.

namespace FsControl

open System
open System.Text
open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open FSharpPlus
open FsControl.Internals


[<Extension;Sealed>]
type Nth =
    inherit Default1
    [<Extension>]static member inline Nth (x:'Foldable'T   , n, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.skip n |> Seq.head :'T
    [<Extension>]static member        Nth (x:string        , n, [<Optional>]_impl:Nth     ) = x.[n]
    [<Extension>]static member        Nth (x:StringBuilder , n, [<Optional>]_impl:Nth     ) = x.ToString().[n]
    [<Extension>]static member        Nth (x:'a []         , n, [<Optional>]_impl:Nth     ) = x.[n] : 'a
    [<Extension>]static member        Nth (x:'a ResizeArray, n, [<Optional>]_impl:Nth     ) = x.[n]
    [<Extension>]static member        Nth (x:list<'a>      , n, [<Optional>]_impl:Nth     ) = x.[n]
    [<Extension>]static member        Nth (x:'a Id         , _, [<Optional>]_impl:Nth     ) = x.getValue

    static member inline Invoke (n:int) (source:'Collection'T)  :'T =
        let inline call_2 (a:^a, b:^b, n) = ((^a or ^b) : (static member Nth: _*_*_ -> _) b, n, a)
        let inline call (a:'a, b:'b, n) = call_2 (a, b, n)
        call (Unchecked.defaultof<Nth>, source, n)

[<Extension;Sealed>]
type Skip =
    inherit Default1
    [<Extension>]static member inline Skip (x:'Foldable'T   , n, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.skip n |> OfSeq.Invoke :'Foldable'T
    [<Extension>]static member        Skip (x:string        , n, [<Optional>]_impl:Skip    ) = x.[n..]
    [<Extension>]static member        Skip (x:StringBuilder , n, [<Optional>]_impl:Skip    ) = new StringBuilder(x.ToString().[n..])
    [<Extension>]static member        Skip (x:'a []         , n, [<Optional>]_impl:Skip    ) = x.[n..] : 'a []
    [<Extension>]static member        Skip (x:'a ResizeArray, n, [<Optional>]_impl:Skip    ) = ResizeArray<'a> (Seq.skip n x)
    [<Extension>]static member        Skip (x:list<'a>      , n, [<Optional>]_impl:Skip    ) = List.skip n x
    [<Extension>]static member        Skip (x:'a Id         , _, [<Optional>]_impl:Skip    ) = x

    static member inline Invoke (n:int) (source:'Collection'T)  :'Collection'T =
        let inline call_2 (a:^a, b:^b, n) = ((^a or ^b) : (static member Skip: _*_*_ -> _) b, n, a)
        let inline call (a:'a, b:'b, n) = call_2 (a, b, n)
        call (Unchecked.defaultof<Skip>, source, n)


[<Extension;Sealed>]
type Take =
    inherit Default1
    [<Extension>]static member inline Take (x:'Foldable'T   , n, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.take n |> OfSeq.Invoke :'Foldable'T
    [<Extension>]static member        Take (x:string        , n, [<Optional>]_impl:Take    ) = x.[..n-1]
    [<Extension>]static member        Take (x:StringBuilder , n, [<Optional>]_impl:Take    ) = new StringBuilder(x.ToString().[..n-1])
    [<Extension>]static member        Take (x:'a []         , n, [<Optional>]_impl:Take    ) = x.[..n-1] : 'a []
    [<Extension>]static member        Take (x:'a ResizeArray, n, [<Optional>]_impl:Take    ) = ResizeArray<'a> (Seq.take n x)
    [<Extension>]static member        Take (x:list<'a>      , n, [<Optional>]_impl:Take    ) = List.take n x
    [<Extension>]static member        Take (x:'a Id         , _, [<Optional>]_impl:Take    ) = x

    static member inline Invoke (n:int) (source:'Collection'T)  :'Collection'T =
        let inline call_2 (a:^a, b:^b, n) = ((^a or ^b) : (static member Take: _*_*_ -> _) b, n, a)
        let inline call (a:'a, b:'b, n) = call_2 (a, b, n)
        call (Unchecked.defaultof<Take>, source, n)


[<Extension;Sealed>]
type Drop =
    inherit Default1
    [<Extension>]static member inline Drop (x:'Foldable'T   , n, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.drop n |> OfSeq.Invoke :'Foldable'T
    [<Extension>]static member        Drop (x:string        , n, [<Optional>]_impl:Drop) = if n > 0 then (if x.Length > n then x.[n..] else "") else x
    [<Extension>]static member        Drop (x:StringBuilder , n, [<Optional>]_impl:Drop) = if n > 0 then (if x.Length > n then new StringBuilder(x.ToString().[n..]) else new StringBuilder()) else new StringBuilder(x.ToString())
    [<Extension>]static member        Drop (x:'a []         , n, [<Optional>]_impl:Drop) = if n > 0 then (if x.Length > n then x.[n..] else [||]) else x : 'a []
    [<Extension>]static member        Drop (x:'a ResizeArray, n, [<Optional>]_impl:Drop) = ResizeArray<'a> (Seq.drop n x)
    [<Extension>]static member        Drop (x:list<'a>      , n, [<Optional>]_impl:Drop) = List.drop n x
    [<Extension>]static member        Drop (x:'a Id         , _, [<Optional>]_impl:Drop) = x

    static member inline Invoke (n:int) (source:'Collection'T)  :'Collection'T =
        let inline call_2 (a:^a, b:^b, n) = ((^a or ^b) : (static member Drop: _*_*_ -> _) b, n, a)
        let inline call (a:'a, b:'b, n) = call_2 (a, b, n)
        call (Unchecked.defaultof<Drop>, source, n)



[<Extension;Sealed>]
type Limit =
    inherit Default1
    [<Extension>]static member inline Limit (x:'Foldable'T   , n, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.truncate n |> OfSeq.Invoke :'Foldable'T
    [<Extension>]static member        Limit (x:string        , n, [<Optional>]_impl:Limit) = if n < 1 then "" elif n < x.Length then x.[..n-1] else x
    [<Extension>]static member        Limit (x:StringBuilder , n, [<Optional>]_impl:Limit) = new StringBuilder(x.ToString().[..n-1])
    [<Extension>]static member        Limit (x:'a []         , n, [<Optional>]_impl:Limit) = if n < 1 then [||] elif n < x.Length then x.[..n-1] else x : 'a []
    [<Extension>]static member        Limit (x:'a ResizeArray, n, [<Optional>]_impl:Limit) = ResizeArray<'a> (Seq.truncate n x)
    [<Extension>]static member        Limit (x:list<'a>      , n, [<Optional>]_impl:Limit) = Seq.truncate n x |> Seq.toList
    [<Extension>]static member        Limit (x:'a Id         , _, [<Optional>]_impl:Limit) = x

    static member inline Invoke (n:int) (source:'Collection'T)  :'Collection'T =
        let inline call_2 (a:^a, b:^b, n) = ((^a or ^b) : (static member Limit: _*_*_ -> _) b, n, a)
        let inline call (a:'a, b:'b, n) = call_2 (a, b, n)
        call (Unchecked.defaultof<Limit>, source, n)
 


type Choose =
    static member Choose (_:Id<'T>  , _:_->'U option, [<Optional>]_impl:Choose) = invalidOp "Choose on ID" :Id<'U>
    static member Choose (x:seq<'T> , f:_->'U option, [<Optional>]_impl:Choose) = Seq.choose   f x
    static member Choose (x:list<'T>, f:_->'U option, [<Optional>]_impl:Choose) = List.choose  f x
    static member Choose (x:'T []   , f:_->'U option, [<Optional>]_impl:Choose) = Array.choose f x

    static member inline Invoke (chooser:'T->'U option)   (source:'Collection'T)        =
        let inline call_3 (a:^a, b:^b, _:^c, f) = ((^a or ^b or ^c) : (static member Choose: _*_*_ -> _) b, f, a)
        let inline call (a:'a, b:'b, c) = call_3 (a, b, Unchecked.defaultof<'r>, c) :'r
        call (Unchecked.defaultof<Choose>, source, chooser)  :'Collection'U


[<Extension;Sealed>]
type Distinct =
    inherit Default1
    [<Extension>]static member inline Distinct (x:'Foldable'T, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.distinct |> OfSeq.Invoke :'Foldable'T
    [<Extension>]static member        Distinct (x:list<'T>   , [<Optional>]_impl:Distinct) = Seq.distinct x |> Seq.toList
    [<Extension>]static member        Distinct (x:'T []      , [<Optional>]_impl:Distinct) = Seq.distinct x |> Seq.toArray

    static member inline Invoke                         (source:'Collection'T)        =
        let inline call_2 (a:^a, b:^b) = ((^a or ^b) : (static member Distinct: _*_ -> _) b, a)
        let inline call (a:'a, b:'b) = call_2 (a, b)
        call (Unchecked.defaultof<Distinct>, source)  :'Collection'T


type DistinctBy =
    inherit Default1
    static member inline DistinctBy (x:'Foldable'T, f, [<Optional>]_impl:Default1  ) = x |> ToSeq.Invoke |> Seq.distinctBy f |> OfSeq.Invoke :'Foldable'T
    static member        DistinctBy (x:list<'T>   , f, [<Optional>]_impl:DistinctBy) = Seq.distinctBy f x |> Seq.toList
    static member        DistinctBy (x:'T []      , f, [<Optional>]_impl:DistinctBy) = Seq.distinctBy f x |> Seq.toArray

    static member inline Invoke (projection:'T->'Key) (source:'Collection'T)        =
        let inline call_2 (a:^a, b:^b, p) = ((^a or ^b) : (static member DistinctBy: _*_*_ -> _) b, p, a)
        let inline call (a:'a, b:'b, p) = call_2 (a, b, p)
        call (Unchecked.defaultof<DistinctBy>, source, projection)    :'Collection'T


type GroupBy =
    static member GroupBy (x:Id<'T>  , f:'T->'Key, _:Id<'Key*Id<'T>>    , [<Optional>]_impl:GroupBy) = let a = Id.run x in Id.create (f a, x)
    static member GroupBy (x:seq<'T> , f:'T->'Key, _:seq<'Key*seq<'T>>  , [<Optional>]_impl:GroupBy) = Seq.groupBy f x
    static member GroupBy (x:list<'T>, f:'T->'Key, _:list<'Key*list<'T>>, [<Optional>]_impl:GroupBy) = Seq.groupBy f x |> Seq.map (fun (x,y) -> x, Seq.toList  y) |> Seq.toList
    static member GroupBy (x:'T []   , f:'T->'Key, _:('Key*('T [])) []  , [<Optional>]_impl:GroupBy) = Seq.groupBy f x |> Seq.map (fun (x,y) -> x, Seq.toArray y) |> Seq.toArray

    static member inline Invoke    (projection:'T->'Key) (source:'Collection'T) : 'Collection'KeyX'Collection'T = 
        let inline call_3 (a:^a, b:^b, c:^c, p) = ((^a or ^b or ^c) : (static member GroupBy: _*_*_*_ -> _) b, p, c, a)
        let inline call (a:'a, b:'b, p) = call_3 (a, b, Unchecked.defaultof<'r>, p) :'r
        call (Unchecked.defaultof<GroupBy>, source, projection)


type ChunkBy =
    static member ChunkBy (x:Id<'T>  , f:'T->'Key, _:Id<'Key*Id<'T>>    , [<Optional>]_impl:ChunkBy) = let a = Id.run x in Id.create (f a, x)
    static member ChunkBy (x:seq<'T> , f:'T->'Key, _:seq<'Key*seq<'T>>  , [<Optional>]_impl:ChunkBy) = Seq.chunkBy f x |> Seq.map (fun (x,y) -> x, y :> _ seq)
    static member ChunkBy (x:list<'T>, f:'T->'Key, _:list<'Key*list<'T>>, [<Optional>]_impl:ChunkBy) = Seq.chunkBy f x |> Seq.map (fun (x,y) -> x, Seq.toList  y) |> Seq.toList
    static member ChunkBy (x:'T []   , f:'T->'Key, _:('Key*('T [])) []  , [<Optional>]_impl:ChunkBy) = Seq.chunkBy f x |> Seq.map (fun (x,y) -> x, Seq.toArray y) |> Seq.toArray

    static member inline Invoke (projection:'T->'Key) (source:'Collection'T) : 'Collection'KeyX'Collection'T = 
        let inline call_3 (a:^a, b:^b, c:^c, p) = ((^a or ^b or ^c) : (static member ChunkBy: _*_*_*_ -> _) b, p, c, a)
        let inline call (a:'a, b:'b, p) = call_3 (a, b, Unchecked.defaultof<'r>, p) :'r
        call (Unchecked.defaultof<ChunkBy>, source, projection)


[<Extension;Sealed>]
type Length =
    inherit Default1
    [<Extension>]static member inline Length (x:'Foldable'T, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.length   
    [<Extension>]static member Length (_:Id<'T>  , [<Optional>]_impl:Length) = 1
    [<Extension>]static member Length (x:seq<'T> , [<Optional>]_impl:Length) = Seq.length   x
    [<Extension>]static member Length (x:list<'T>, [<Optional>]_impl:Length) = List.length  x
    [<Extension>]static member Length (x:'T []   , [<Optional>]_impl:Length) = Array.length x

    static member inline Invoke (source:'Collection'T)                                  =
        let inline call_2 (a:^a, b:^b) = ((^a or ^b) : (static member Length: _*_ -> _) b, a)
        let inline call (a:'a, b:'b) = call_2 (a, b)
        call (Unchecked.defaultof<Length>, source)            :int



[<Extension;Sealed>]
type Max =
    inherit Default1
    [<Extension>]static member inline Max (x:'Foldable'T, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.max :'T
    [<Extension>]static member Max (x:Id<'T>  , [<Optional>]_impl:Max) = x.getValue
    [<Extension>]static member Max (x:seq<'T> , [<Optional>]_impl:Max) = Seq.max   x
    [<Extension>]static member Max (x:list<'T>, [<Optional>]_impl:Max) = List.max  x
    [<Extension>]static member Max (x:'T []   , [<Optional>]_impl:Max) = Array.max x

    static member inline Invoke (source:'Collection'T)                                  =
        let inline call_2 (a:^a, b:^b) = ((^a or ^b) : (static member Max: _*_ -> _) b, a)
        let inline call (a:'a, b:'b) = call_2 (a, b)
        call (Unchecked.defaultof<Max>, source)                  :'T


type MaxBy =
    inherit Default1
    static member inline MaxBy (x:'Foldable'T, f, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.maxBy f :'T
    static member MaxBy (x:Id<'T>  , _:'T->'U, [<Optional>]_impl:MaxBy) = x.getValue
    static member MaxBy (x:seq<'T> , f       , [<Optional>]_impl:MaxBy) = Seq.maxBy   f x
    static member MaxBy (x:list<'T>, f       , [<Optional>]_impl:MaxBy) = List.maxBy  f x
    static member MaxBy (x:'T []   , f       , [<Optional>]_impl:MaxBy) = Array.maxBy f x

    static member inline Invoke (projection:'T->'U) (source:'Collection'T)               =
        let inline call_2 (a:^a, b:^b, f) = ((^a or ^b) : (static member MaxBy: _*_*_ -> _) b, f, a)
        let inline call (a:'a, b:'b, f) = call_2 (a, b, f)
        call (Unchecked.defaultof<MaxBy>, source, projection)      :'T


[<Extension;Sealed>]
type Min =
    inherit Default1
    [<Extension>]static member inline Min (x:'Foldable'T, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.min :'T
    [<Extension>]static member Min (x:Id<'T>  , [<Optional>]_impl:Min) = x.getValue
    [<Extension>]static member Min (x:seq<'T> , [<Optional>]_impl:Min) = Seq.min   x
    [<Extension>]static member Min (x:list<'T>, [<Optional>]_impl:Min) = List.min  x
    [<Extension>]static member Min (x:'T []   , [<Optional>]_impl:Min) = Array.min x

    static member inline Invoke (source:'Collection'T)                                  =
        let inline call_2 (a:^a, b:^b) = ((^a or ^b) : (static member Min: _*_ -> _) b, a)
        let inline call (a:'a, b:'b) = call_2 (a, b)
        call (Unchecked.defaultof<Min>, source)                  :'T


type MinBy =
    inherit Default1
    static member inline MinBy (x:'Foldable'T, f, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.minBy f :'T
    static member MinBy (x:Id<'T>  , _:'T->'U, [<Optional>]_impl:MinBy) = x.getValue
    static member MinBy (x:seq<'T> , f       , [<Optional>]_impl:MinBy) = Seq.minBy   f x
    static member MinBy (x:list<'T>, f       , [<Optional>]_impl:MinBy) = List.minBy  f x
    static member MinBy (x:'T []   , f       , [<Optional>]_impl:MinBy) = Array.minBy f x

    static member inline Invoke (projection:'T->'U) (source:'Collection'T)               =
        let inline call_2 (a:^a, b:^b, f) = ((^a or ^b) : (static member MinBy: _*_*_ -> _) b, f, a)
        let inline call (a:'a, b:'b, f) = call_2 (a, b, f)
        call (Unchecked.defaultof<MinBy>, source, projection)      :'T


[<Extension;Sealed>]
type Replace =
    inherit Default1
                 static member inline Replace (x:'Collection  , o:'Collection  , n:'Collection  , [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.replace (ToSeq.Invoke o) (ToSeq.Invoke n) |> OfSeq.Invoke : 'Collection
                 static member        Replace (x:Id<'T>       , o:Id<'T>       , n:Id<'T>       , [<Optional>]_impl:Default1) = if x = o then n else x
    [<Extension>]static member        Replace (x:list<'T>     , o:list<'T>     , n:list<'T>     , [<Optional>]_impl:Replace ) = x |> List.toSeq   |> Seq.replace o n |> Seq.toList
    [<Extension>]static member        Replace (x:'T []        , o:'T []        , n:'T []        , [<Optional>]_impl:Replace ) = x |> Array.toSeq  |> Seq.replace o n |> Seq.toArray
    [<Extension>]static member        Replace (x:string       , o:string       , n:string       , [<Optional>]_impl:Replace ) = if o.Length = 0 then x else x.Replace(o, n)
    [<Extension>]static member        Replace (x:StringBuilder, o:StringBuilder, n:StringBuilder, [<Optional>]_impl:Replace ) = if o.Length = 0 then x else StringBuilder(x.ToString().Replace(o.ToString(), n.ToString()))
 
    static member inline Invoke      (o:'Collection) (n:'Collection) (source:'Collection) =
        let inline call_2 (a:^a, b:^b) = ((^a or ^b) : (static member Replace: _*_*_*_ -> _) b, o, n, a)
        let inline call (a:'a, b:'b) = call_2 (a, b)
        call (Unchecked.defaultof<Replace>, source) :'Collection


[<Extension;Sealed>]
type Rev =
    inherit Default1
    [<Extension>]static member inline Rev (x:'Foldable'T, [<Optional>]_impl:Default1) = x |> ToSeq.Invoke |> Seq.toArray |> Array.rev |> Array.toSeq |> OfSeq.Invoke :'Foldable'T
    [<Extension>]static member        Rev (x:list<'a>   , [<Optional>]_impl:Rev     ) = List.rev  x
    [<Extension>]static member        Rev (x:'a []      , [<Optional>]_impl:Rev     ) = Array.rev x

    static member inline Invoke  (source:'Collection'T)                                    =
        let inline call_2 (a:^a, b:^b) = ((^a or ^b) : (static member Rev: _*_ -> _) b, a)
        let inline call (a:'a, b:'b) = call_2 (a, b)
        call (Unchecked.defaultof<Rev>, source)                   :'Collection'T


type Scan =
    static member Scan (x:Id<'T>  , f ,z:'S, [<Optional>]_output:Id<'S>  , [<Optional>]_impl:Scan) = Id.create (f z x.getValue)
    static member Scan (x:seq<'T> , f ,z:'S, [<Optional>]_output:seq<'S> , [<Optional>]_impl:Scan) = Seq.scan   f z x
    static member Scan (x:list<'T>, f ,z:'S, [<Optional>]_output:list<'S>, [<Optional>]_impl:Scan) = List.scan  f z x
    static member Scan (x:'T []   , f ,z:'S, [<Optional>]_output:'S []   , [<Optional>]_impl:Scan) = Array.scan f z x

    static member inline Invoke (folder:'State'->'T->'State) (state:'State) (source:'Collection'T) =
        let inline call_3 (a:^a, b:^b, c:^c, f, z) = ((^a or ^b or ^c) : (static member Scan: _*_*_*_*_ -> _) b, f, z, c, a)
        let inline call (a:'a, b:'b, f, z) = call_3 (a, b, Unchecked.defaultof<'r>, f, z) :'r
        call (Unchecked.defaultof<Scan>, source, folder, state) :'Collection'State


[<Extension;Sealed>]
type Sort =
    inherit Default1
    [<Extension>]static member inline Sort (x:'Foldable'T, [<Optional>]_impl:Default2) = x |> ToSeq.Invoke |> Seq.sort |> OfSeq.Invoke :'Foldable'T
    [<Extension>]static member inline Sort (x:^Foldable'T, [<Optional>]_impl:Default1) = ((^Foldable'T) : (static member Sort: _->_) x) : ^Foldable'T
    [<Extension>]static member        Sort (x:list<'a>   , [<Optional>]_impl:Sort    ) = List.sort  x
    [<Extension>]static member        Sort (x:'a []      , [<Optional>]_impl:Sort    ) = Array.sort x

    static member inline Invoke (source:'Collection'T)                                    =
        let inline call_2 (a:^a, b:^b) = ((^a or ^b) : (static member Sort: _*_ -> _) b, a)
        let inline call (a:'a, b:'b) = call_2 (a, b)
        call (Unchecked.defaultof<Sort>, source)                 :'Collection'T


type SortBy =
    inherit Default1

    static member        SortBy (x:list<'a>   , f      , [<Optional>]_impl:SortBy  ) = List.sortBy  f x
    static member        SortBy (x:'a []      , f      , [<Optional>]_impl:SortBy  ) = Array.sortBy f x

    static member inline Invoke (projection:'T->'Key) (source:'Collection'T) : 'Collection'T =
        let inline call_2 (a:^a, b:^b, f) = ((^a or ^b) : (static member SortBy: _*_*_ -> _) b, f, a)
        let inline call (a:'a, b:'b, f) = call_2 (a, b, f)
        call (Unchecked.defaultof<SortBy>, source, projection)
    static member inline InvokeOnInstance (projection:'T->'Key) (source:'Collection'T) : 'Collection'T = (^Collection'T : (static member SortBy: _*_->_) projection, source) : ^Collection'T

    static member inline SortBy (x:'Foldable'T, f      , [<Optional>]_impl:Default2) = x |> ToSeq.Invoke |> Seq.sortBy f |> OfSeq.Invoke :'Foldable'T
    static member inline SortBy (x:^Foldable'T, f      , [<Optional>]_impl:Default1) = ((^Foldable'T) : (static member SortBy: _*_->_) f, x) : ^Foldable'T
    static member inline SortBy (_ : ^t when ^t : null and ^t : struct, _ : 'T -> 'U, _mthd : Default1) = id


[<Extension;Sealed>]
type Split =
    inherit Default1
    [<Extension>]static member        Split (x:seq<'T>      , e:seq<seq<'T>>      , [<Optional>]_impl:Split) = x |>                 Seq.split StringSplitOptions.None e
    [<Extension>]static member        Split (x:list<'T>     , e:seq<list<'T>>     , [<Optional>]_impl:Split) = x |> List.toSeq   |> Seq.split StringSplitOptions.None e |> Seq.map Seq.toList
    [<Extension>]static member        Split (x:'T []        , e:seq<'T []>        , [<Optional>]_impl:Split) = x |> Array.toSeq  |> Seq.split StringSplitOptions.None e |> Seq.map Seq.toArray
    [<Extension>]static member        Split (x:string       , e:seq<string>       , [<Optional>]_impl:Split) = x.Split(Seq.toArray e, StringSplitOptions.None) :> seq<_>
    [<Extension>]static member        Split (x:StringBuilder, e:seq<StringBuilder>, [<Optional>]_impl:Split) = x.ToString().Split(e |> Seq.map (fun x -> x.ToString()) |> Seq.toArray, StringSplitOptions.None) |> Array.map StringBuilder :> seq<_>
 
    static member inline Invoke      (sep:seq<'Collection>)        (source:'Collection)       =
        let inline call_2 (a:^a, b:^b, s) = ((^a or ^b) : (static member Split: _*_*_ -> _) b, s, a)
        let inline call (a:'a, b:'b, s) = call_2 (a, b, s)
        call (Unchecked.defaultof<Split>, source,sep) :seq<'Collection>


[<Extension;Sealed>]
type Unzip =
    [<Extension>]static member Unzip (source:seq<'T * 'U> , [<Optional>]_output:seq<'T> * seq<'U>  , [<Optional>]_impl:Unzip) = Seq.map fst source, Seq.map snd source
    [<Extension>]static member Unzip (source:list<'T * 'U>, [<Optional>]_output:list<'T> * list<'U>, [<Optional>]_impl:Unzip) = List.unzip  source
    [<Extension>]static member Unzip (source:('T * 'U) [] , [<Optional>]_output:'T [] * 'U []      , [<Optional>]_impl:Unzip) = Array.unzip source

    static member inline Invoke (source:'``Collection<'T1 * 'T2>``)  =
        let inline call_3 (a:^a, b:^b, d:^d) = ((^a or ^b or ^d) : (static member Unzip: _*_*_ -> _) b, d, a)
        let inline call (a:'a, b:'b) = call_3 (a, b, Unchecked.defaultof<'r>) :'r
        call (Unchecked.defaultof<Unzip>, source) :'``Collection<'T1>`` * '``Collection<'T2>``
                
        
[<Extension;Sealed>]
type Zip =
    [<Extension>]static member Zip (x:Id<'T>  , y:Id<'U>  , [<Optional>]_output:Id<'T*'U>  , [<Optional>]_impl:Zip) = Id.create(x.getValue,y.getValue)
    [<Extension>]static member Zip (x:seq<'T> , y:seq<'U> , [<Optional>]_output:seq<'T*'U> , [<Optional>]_impl:Zip) = Seq.zip   x y
    [<Extension>]static member Zip (x:list<'T>, y:list<'U>, [<Optional>]_output:list<'T*'U>, [<Optional>]_impl:Zip) = List.zip  x y
    [<Extension>]static member Zip (x:'T []   , y:'U []   , [<Optional>]_output:('T*'U) [] , [<Optional>]_impl:Zip) = Array.zip x y

    static member inline Invoke (source1:'Collection'T1) (source2:'Collection'T2)          =
        let inline call_4 (a:^a, b:^b, c:^c, d:^d) = ((^a or ^b or ^c or ^d) : (static member Zip: _*_*_*_ -> _) b, c, d, a)
        let inline call (a:'a, b:'b, c:'c) = call_4 (a, b, c, Unchecked.defaultof<'r>) :'r
        call (Unchecked.defaultof<Zip>, source1, source2)           :'Collection'T1'T2