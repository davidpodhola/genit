module generated_uitests

open generated_forms
open generated_validation
open canopy

let run () =
  start firefox

  context "Order"

  once (fun _ -> url "http://localhost:8083/order/create"; click ".btn") 

  "Name is required" &&& fun _ ->
    displayed "Name is required"
    
  "Tip must be a valid double" &&& fun _ ->
    displayed "Tip is not a valid number (decimal)"
    
  "Delivery Date is required" &&& fun _ ->
    displayed "Delivery Date is required"
    
  "Delivery Date must be a valid date" &&& fun _ ->
    displayed "Delivery Date is not a valid date"
    
  "Phone Number is required" &&& fun _ ->
    displayed "Phone Number is required"
    
    
  context "Reserveration"

  once (fun _ -> url "http://localhost:8083/reserveration/create"; click ".btn") 

  "Name is required" &&& fun _ ->
    displayed "Name is required"
    
  "Date is required" &&& fun _ ->
    displayed "Date is required"
    
  "Date must be a valid date" &&& fun _ ->
    displayed "Date is not a valid date"
    
  "Phone Number is required" &&& fun _ ->
    displayed "Phone Number is required"
    
    

  canopy.runner.run()

  quit()
