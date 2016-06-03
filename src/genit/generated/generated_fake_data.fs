module generated_fake_data

open generated_types
open generated_data_access
open helper_general

let fake_group () =
  {
    GroupID = -1L 
    Name = (randomItem firstNames) + " " + (randomItem lastNames) 
  }

let fake_many_group number =
  [| 1..number |]
  |> Array.map (fun _ -> fake_group ()) //no parallel cause of RNG
  |> Array.Parallel.map insert_group
  |> ignore
 
 
let fake_supplier () =
  {
    SupplierID = -1L 
    Name = (randomItem firstNames) + " " + (randomItem lastNames) 
    Address = randomItems 40 words 
    Email = sprintf "%s@%s.com" (randomItem words) (randomItem words) 
    PhoneNumber = sprintf "%i-%i-%i" (random.Next(200,800)) (random.Next(200,800)) (random.Next(2000,8000)) 
  }

let fake_many_supplier number =
  [| 1..number |]
  |> Array.map (fun _ -> fake_supplier ()) //no parallel cause of RNG
  |> Array.Parallel.map insert_supplier
  |> ignore
 
 
let fake_supplierInGroup () =
  {
    SupplierInGroupID = -1L 
    Group = unbox null 
    Supplier = unbox null 
  }

let fake_many_supplierInGroup number =
  [| 1..number |]
  |> Array.map (fun _ -> fake_supplierInGroup ()) //no parallel cause of RNG
  |> Array.Parallel.map insert_supplierInGroup
  |> ignore
 
 
  