(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr;;

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

let e4 = Prim("max", CstI 4, CstI 3);;

let e5 = Prim("min", CstI 4, CstI 3);;

let e6 = Prim("==", CstI 4, CstI 4);;


(* Evaluation within an environment *)

//Changed eval function

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim(ope, e1, e2) ->
      let i1 = eval e1 env
      let i2 = eval e2 env
      match ope with 
      | "+" -> i1 + i2
      | "-" -> i1 - i2
      | "*" -> i1 * i2
      | "max" -> if i1 > i2 then i1 else i2
      | "min" -> if i1 < i2 then i1 else i2
      | "==" -> if i1 = i2 then 1 else 0
    | If (e1, e2, e3) -> 
      let i1 = eval e1 env
      match i1 with
      | 0 -> eval e3 env
      | _ -> eval e2 env 
    (*| Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim ("max", e1, e2)   ->  if eval e1 env > eval e2 env then eval e1 env else eval e2 env
    | Prim ("min", e1, e2) -> if eval e1 env < eval e2 env then eval e1 env else eval e2 env
    | Prim ("==", e1, e2) -> if eval e1 env = eval e2 env then 1 else 0*)

let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

let e4v = eval e4 env 

let e5v = eval e5 env

let e6v = eval e6 env


type aexpr = 
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr



// Sub(Var "v", Add(Var "w", Var "z"))
// Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z"))
// Add(Add(Var "z", Var "v", Add(Var "x", Var "y"))

//added fmt function

let rec fmt ae = 
  match ae with
  | CstI i -> (string) i
  | Var x -> x
  | Add (ae1, ae2) -> fmt ae1 + "+" + fmt ae2
  | Mul (ae1, ae2) -> fmt ae1 + "*" + fmt ae2
  | Sub (ae1, ae2) -> fmt ae1 + "-" + fmt ae2


//added simplify function

let rec simplify ae =
  match ae with
  | Add (ae1, ae2) -> 
      let i1 = ae1 
      let i2 = ae2
      match i1 with
      | CstI 0 -> i2
      | _ -> match i2 with
              | CstI 0 -> i1
              | _ -> ae 
  | Sub (ae1, ae2) ->
      let i1 = ae1 
      let i2 = ae2
      match i1 with
        | i2 when i1=i2 -> CstI 0
        | _ -> match i2 with
                | CstI 0 -> i1
                | _ -> ae   
  | Mul (ae1, ae2) ->
      let i1 = ae1 
      let i2 = ae2
      match i1 with 
        | CstI 1 -> i2
        | CstI 0 -> CstI 0
        | _ -> match i2 with
                | CstI 1 -> i1
                | CstI 0 -> CstI 0
                | _ -> ae
  | _ -> failwith "cannot simplify further"


//Added function symbdiff

let rec symbdiff e s  =
    match e with
    | CstI i -> CstI 0
    | Var x when x = s -> CstI 1
    | Var x -> CstI 0
    | Add(ae1, ae2) -> Add (symbdiff ae1 s, symbdiff ae2 s)
    | Mul (ae1, ae2) -> Add(Mul ((symbdiff ae1 s), ae2),Mul ((symbdiff ae2 s), ae1))
    | Sub (ae1, ae2) -> Sub (symbdiff ae1 s, symbdiff ae2 s)

