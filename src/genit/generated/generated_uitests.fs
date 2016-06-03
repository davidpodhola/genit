module generated_uitests

open generated_forms
open generated_validation
open canopy

let run () =
  start firefox

  context "Group"

  once (fun _ -> url "http://localhost:8083/group/create"; click ".btn") 

  "Name is required" &&& fun _ ->
    displayed "Name is required"
    
    
  context "Supplier"

  once (fun _ -> url "http://localhost:8083/supplier/create"; click ".btn") 

  "Name is required" &&& fun _ ->
    displayed "Name is required"
    
  "Address is required" &&& fun _ ->
    displayed "Address is required"
    
  "Email is required" &&& fun _ ->
    displayed "Email is required"
    
  "Email must be a valid email" &&& fun _ ->
    displayed "Email is not a valid email"
    
  "Phone Number is required" &&& fun _ ->
    displayed "Phone Number is required"
    
    
  context "SupplierInGroup"

  once (fun _ -> url "http://localhost:8083/supplierInGroup/create"; click ".btn") 


    

  canopy.runner.run()

  quit()
