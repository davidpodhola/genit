module generated_forms

open Suave.Model.Binding
open Suave.Form
open generated_types
open generated_data_access

type GroupForm =
  {
    GroupID : string
    Name : string
  }

let groupForm : Form<GroupForm> = Form ([],[])

let convert_groupForm (groupForm : GroupForm) : Group =
  {
    GroupID = int64 groupForm.GroupID
    Name = groupForm.Name
  }
  
type SupplierForm =
  {
    SupplierID : string
    Name : string
    Address : string
    Email : string
    PhoneNumber : string
  }

let supplierForm : Form<SupplierForm> = Form ([],[])

let convert_supplierForm (supplierForm : SupplierForm) : Supplier =
  {
    SupplierID = int64 supplierForm.SupplierID
    Name = supplierForm.Name
    Address = supplierForm.Address
    Email = supplierForm.Email
    PhoneNumber = supplierForm.PhoneNumber
  }
  
type SupplierInGroupForm =
  {
    SupplierInGroupID : string
    Group : string
    Supplier : string
  }

let supplierInGroupForm : Form<SupplierInGroupForm> = Form ([],[])

let convert_supplierInGroupForm (supplierInGroupForm : SupplierInGroupForm) : SupplierInGroup =
  {
    SupplierInGroupID = int64 supplierInGroupForm.SupplierInGroupID
    Group = get_groupBySId(supplierInGroupForm.Group)
    Supplier = get_supplierBySId(supplierInGroupForm.Supplier)
  }
  