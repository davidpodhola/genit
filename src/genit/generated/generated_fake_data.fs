module generated_fake_data

open generated_types
open generated_data_access
open helper_general

let fake_order () =
  let cityStateZip = randomItem citiesSatesZips
  {
    OrderID = -1L 
    Name = (randomItem firstNames) + " " + (randomItem lastNames) 
    Food = Some(randomItems 6 words) 
    Drinks = Some(randomItems 6 words) 
    Tip = Some(random.Next(100) |> decimal) 
    Notes = Some(randomItems 40 words) 
    DeliveryDate = System.DateTime.Now 
    PhoneNumber = sprintf "%i-%i-%i" (random.Next(200,800)) (random.Next(200,800)) (random.Next(2000,8000)) 
    Address = Some((string (random.Next(100,9999))) + " " + (randomItem streetNames) + " " + (randomItem streetNameSuffixes)) 
    City = Some(cityStateZip.City) 
    State = Some(cityStateZip.State) 
    Zip = Some(cityStateZip.Zip) 
    FreeSoda = Some(1s) 
  }

let fake_many_order number =
  [| 1..number |]
  |> Array.map (fun _ -> fake_order ()) //no parallel cause of RNG
  |> Array.Parallel.map insert_order
  |> ignore
 
 
let fake_reserveration () =
  {
    ReserverationID = -1L 
    Name = (randomItem firstNames) + " " + (randomItem lastNames) 
    Date = System.DateTime.Now 
    PhoneNumber = sprintf "%i-%i-%i" (random.Next(200,800)) (random.Next(200,800)) (random.Next(2000,8000)) 
  }

let fake_many_reserveration number =
  [| 1..number |]
  |> Array.map (fun _ -> fake_reserveration ()) //no parallel cause of RNG
  |> Array.Parallel.map insert_reserveration
  |> ignore
 
 
  