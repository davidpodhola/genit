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
let connectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=office_suppliers_details;Integrated Security=True"


[<Literal>]
let groupQuerySQL = "DECLARE @id int = @p0; SELECT TOP 500 * FROM groups WHERE group_id=(CASE WHEN @id=0 THEN group_id ELSE @id END )"
type groupQuery = SqlCommandProvider< groupQuerySQL, connectionString>
  
let togroup (a:groupQuery.Record seq )  : Group list =
  a |> Seq.map( fun record -> 
  { 
          GroupID = int64 record.group_id;
      Name =  record.name;
  } ) 
  |> Seq.toList
    


[<Literal>]
let sql_insert_group = "
INSERT INTO groups
    (
      name
    ) VALUES (
      @name
    ); SELECT SCOPE_IDENTITY()
  "
let insert_group (group : Group) =
  
    use command = new SqlCommandProvider<sql_insert_group, connectionString>(connectionString)
    command.Execute(  group.Name) |> Seq.head |> Option.get |> int64
    

[<Literal>]
let sql_update_group = "
  DECLARE @id int = @group_id;
  UPDATE groups
  SET
    name = @name
  WHERE group_id = @id;
  "
let update_group (group : Group) =
    use command = new SqlCommandProvider<sql_update_group, connectionString>(connectionString)
    command.Execute(int   group.GroupID,
  group.Name) |> ignore
    


let tryById_group (id:int64) =
  use cmd = new SqlCommandProvider<groupQuerySQL, connectionString>(connectionString)
  cmd.Execute(int id) |> togroup |> List.tryHead    
  
let get_groupById (id:int) =
  (tryById_group (int64 id)).Value
  
let get_groupBySId (id:string) =
  (tryById_group (int64 (System.Int32.Parse(id)))).Value

    

let getMany_group ()=
  use cmd = new SqlCommandProvider<groupQuerySQL, connectionString>(connectionString)
  cmd.Execute(0) |> togroup

let getMany_group_Names =
  getMany_group () |> List.map ( fun p-> p.ToString() ) 
    

let getManyWhere_group field how value =
  getMany_group ()
  

[<Literal>]
let supplierQuerySQL = "DECLARE @id int = @p0; SELECT TOP 500 * FROM suppliers WHERE supplier_id=(CASE WHEN @id=0 THEN supplier_id ELSE @id END )"
type supplierQuery = SqlCommandProvider< supplierQuerySQL, connectionString>
  
let tosupplier (a:supplierQuery.Record seq )  : Supplier list =
  a |> Seq.map( fun record -> 
  { 
          SupplierID = int64 record.supplier_id;
      Name =  record.name;
      Address =  record.address;
      Email =  record.email;
      PhoneNumber =  record.phone_number;
  } ) 
  |> Seq.toList
    


[<Literal>]
let sql_insert_supplier = "
INSERT INTO suppliers
    (
      name,
    address,
    email,
    phone_number
    ) VALUES (
      @name,
    @address,
    @email,
    @phone_number
    ); SELECT SCOPE_IDENTITY()
  "
let insert_supplier (supplier : Supplier) =
  
    use command = new SqlCommandProvider<sql_insert_supplier, connectionString>(connectionString)
    command.Execute(  supplier.Name,
  supplier.Address,
  supplier.Email,
  supplier.PhoneNumber) |> Seq.head |> Option.get |> int64
    

[<Literal>]
let sql_update_supplier = "
  DECLARE @id int = @supplier_id;
  UPDATE suppliers
  SET
    name = @name,
  address = @address,
  email = @email,
  phone_number = @phone_number
  WHERE supplier_id = @id;
  "
let update_supplier (supplier : Supplier) =
    use command = new SqlCommandProvider<sql_update_supplier, connectionString>(connectionString)
    command.Execute(int   supplier.SupplierID,
  supplier.Name,
  supplier.Address,
  supplier.Email,
  supplier.PhoneNumber) |> ignore
    


let tryById_supplier (id:int64) =
  use cmd = new SqlCommandProvider<supplierQuerySQL, connectionString>(connectionString)
  cmd.Execute(int id) |> tosupplier |> List.tryHead    
  
let get_supplierById (id:int) =
  (tryById_supplier (int64 id)).Value
  
let get_supplierBySId (id:string) =
  (tryById_supplier (int64 (System.Int32.Parse(id)))).Value

    

let getMany_supplier ()=
  use cmd = new SqlCommandProvider<supplierQuerySQL, connectionString>(connectionString)
  cmd.Execute(0) |> tosupplier

let getMany_supplier_Names =
  getMany_supplier () |> List.map ( fun p-> p.ToString() ) 
    

let getManyWhere_supplier field how value =
  getMany_supplier ()
  

[<Literal>]
let supplierInGroupQuerySQL = "DECLARE @id int = @p0; SELECT TOP 500 * FROM supplieringroups WHERE supplieringroup_id=(CASE WHEN @id=0 THEN supplieringroup_id ELSE @id END )"
type supplierInGroupQuery = SqlCommandProvider< supplierInGroupQuerySQL, connectionString>
  
let tosupplierInGroup (a:supplierInGroupQuery.Record seq )  : SupplierInGroup list =
  a |> Seq.map( fun record -> 
  { 
          SupplierInGroupID = int64 record.supplieringroup_id;
      Group = get_groupById record.group_id;
      Supplier = get_supplierById record.supplier_id;
  } ) 
  |> Seq.toList
    


[<Literal>]
let sql_insert_supplierInGroup = "
INSERT INTO supplieringroups
    (
      group_id,
    supplier_id
    ) VALUES (
      @group_id,
    @supplier_id
    ); SELECT SCOPE_IDENTITY()
  "
let insert_supplierInGroup (supplierInGroup : SupplierInGroup) =
  
    use command = new SqlCommandProvider<sql_insert_supplierInGroup, connectionString>(connectionString)
    command.Execute(  int supplierInGroup.Group.GroupID,
  int supplierInGroup.Supplier.SupplierID) |> Seq.head |> Option.get |> int64
    

[<Literal>]
let sql_update_supplierInGroup = "
  DECLARE @id int = @supplieringroup_id;
  UPDATE supplieringroups
  SET
    group_id = @group_id,
  supplier_id = @supplier_id
  WHERE supplieringroup_id = @id;
  "
let update_supplierInGroup (supplierInGroup : SupplierInGroup) =
    use command = new SqlCommandProvider<sql_update_supplierInGroup, connectionString>(connectionString)
    command.Execute(int   supplierInGroup.SupplierInGroupID,
  int supplierInGroup.Group.GroupID,
  int supplierInGroup.Supplier.SupplierID) |> ignore
    


let tryById_supplierInGroup (id:int64) =
  use cmd = new SqlCommandProvider<supplierInGroupQuerySQL, connectionString>(connectionString)
  cmd.Execute(int id) |> tosupplierInGroup |> List.tryHead    
  
let get_supplierInGroupById (id:int) =
  (tryById_supplierInGroup (int64 id)).Value
  
let get_supplierInGroupBySId (id:string) =
  (tryById_supplierInGroup (int64 (System.Int32.Parse(id)))).Value

    

let getMany_supplierInGroup ()=
  use cmd = new SqlCommandProvider<supplierInGroupQuerySQL, connectionString>(connectionString)
  cmd.Execute(0) |> tosupplierInGroup

let getMany_supplierInGroup_Names =
  getMany_supplierInGroup () |> List.map ( fun p-> p.ToString() ) 
    

let getManyWhere_supplierInGroup field how value =
  getMany_supplierInGroup ()
  