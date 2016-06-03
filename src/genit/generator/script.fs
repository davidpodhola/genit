module script

open dsl
open generator

let someSite () =

  site "Office Suppliers Details"

  basic home

  page "Group" CVELS
    [
      text      "Name"          Required
    ]

  api "Group"

  page "Supplier" CVELS
    [
      text  "Name"         Required
      paragraph "Address"  Required
      email  "Email"
      phone "Phone Number" Required
    ]

  page "SupplierInGroup" CVELS
    [
      reference  "Group"    true
      reference "Supplier"  true
    ]


  currentSite
