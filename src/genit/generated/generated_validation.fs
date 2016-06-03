module generated_validation

open generated_forms
open validators

let validation_groupForm (groupForm : GroupForm) =
  [
    validate_required "Name" groupForm.Name
  ] |> List.choose id
  
let validation_supplierForm (supplierForm : SupplierForm) =
  [
    validate_required "Name" supplierForm.Name
    validate_required "Address" supplierForm.Address
    validate_email "Email" supplierForm.Email
    validate_required "Email" supplierForm.Email
    validate_required "Phone Number" supplierForm.PhoneNumber
  ] |> List.choose id
  
let validation_supplierInGroupForm (supplierInGroupForm : SupplierInGroupForm) =
  [
    validate_reference "Group" "Group" supplierInGroupForm.Group true
    validate_reference "Supplier" "Supplier" supplierInGroupForm.Supplier true
  ] |> List.choose id
  