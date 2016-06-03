module generated_data_access

open generated_types
open helper_general
open helper_ado
open FSharp.Data
open dsl
open BCrypt.Net

type BCryptScheme =
  {
    Id : int
    WorkFactor : int
  }

let bCryptSchemes : BCryptScheme list = [ { Id = 1; WorkFactor = 8; } ]
let getBCryptScheme id = bCryptSchemes |> List.find (fun scheme -> scheme.Id = id)
let currentBCryptScheme = 1

[<Literal>]
let connectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bobs_burgers;Integrated Security=True"

