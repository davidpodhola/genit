module generated_types

type Group =
  {
    GroupID : int64
    Name : string
  }
  
type Supplier =
  {
    SupplierID : int64
    Name : string
    Address : string
    Email : string
    PhoneNumber : string
  }
  
type SupplierInGroup =
  {
    SupplierInGroupID : int64
    Group : Group
    Supplier : Supplier
  }
  