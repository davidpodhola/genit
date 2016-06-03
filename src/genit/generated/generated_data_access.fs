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



[<Literal>]
let sql_insert_register = "
INSERT INTO users
    (
      first_name,
    last_name,
    email,
    password
    ) VALUES (
      @first_name,
    @last_name,
    @email,
    @password
    ); SELECT SCOPE_IDENTITY()
  "
let insert_register (register : Register) =
  
  let bCryptScheme = getBCryptScheme currentBCryptScheme
  let salt = BCrypt.GenerateSalt(bCryptScheme.WorkFactor)
  let password = BCrypt.HashPassword(register.Password, salt)
    
    use command = new SqlCommandProvider<sql_insert_register, connectionString>(connectionString)
    command.Execute(  register.FirstName,
  register.LastName,
  register.Email,
  password password) |> Seq.head |> Option.get |> int64
    

[<Literal>]
let loginQuerySQL = "DECLARE @id int = @p0; SELECT TOP 500 * FROM s WHERE user_id=(CASE WHEN @id=0 THEN user_id ELSE @id END )"
type loginQuery = SqlCommandProvider< loginQuerySQL, connectionString>
  
let tologin (a:loginQuery.Record seq )  : Login list =
  a |> Seq.map( fun record -> 
  { 
          UserID = int64 record.user_id;
      Email =  record.email;
      Password =  record.password;
  } ) 
  |> Seq.toList
    

[<Literal>]
let sql_authenticate = "
SELECT * FROM users
WHERE email = @email
"
let authenticate (login : Login) =
  use cmd = new SqlCommandProvider<sql_authenticate, connectionString>(connectionString)
  
  let user =
    cmd.Execute(login.Email)
    |> toLogin
    |> Seq.tryHead
  match user with
    | None -> None
    | Some(user) ->
      let verified = BCrypt.Verify(login.Password, user.Password)
      if verified
      then Some(user)
      else None
  

[<Literal>]
let orderQuerySQL = "DECLARE @id int = @p0; SELECT TOP 500 * FROM orders WHERE order_id=(CASE WHEN @id=0 THEN order_id ELSE @id END )"
type orderQuery = SqlCommandProvider< orderQuerySQL, connectionString>
  
let toorder (a:orderQuery.Record seq )  : Order list =
  a |> Seq.map( fun record -> 
  { 
          OrderID = int64 record.order_id;
      Name =  record.name;
      Food =  record.food;
      Drinks =  record.drinks;
      Tip =  record.tip;
      Notes =  record.notes;
      DeliveryDate =  record.delivery_date;
      PhoneNumber =  record.phone_number;
      Address =  record.address;
      City =  record.city;
      State =  record.state;
      Zip =  record.zip;
      FreeSoda =  record.free_soda;
  } ) 
  |> Seq.toList
    


[<Literal>]
let sql_insert_order = "
INSERT INTO orders
    (
      name,
    food,
    drinks,
    tip,
    notes,
    delivery_date,
    phone_number,
    address,
    city,
    state,
    zip,
    free_soda
    ) VALUES (
      @name,
    @food,
    @drinks,
    @tip,
    @notes,
    @delivery_date,
    @phone_number,
    @address,
    @city,
    @state,
    @zip,
    @free_soda
    ); SELECT SCOPE_IDENTITY()
  "
let insert_order (order : Order) =
  
    use command = new SqlCommandProvider<sql_insert_order, connectionString>(connectionString)
    command.Execute(  order.Name,
  order.Food,
  order.Drinks,
  order.Tip,
  order.Notes,
  order.DeliveryDate,
  order.PhoneNumber,
  order.Address,
  order.City,
  order.State,
  order.Zip,
  order.FreeSoda) |> Seq.head |> Option.get |> int64
    

[<Literal>]
let sql_update_order = "
  DECLARE @id int = @order_id;
  UPDATE orders
  SET
    name = @name,
  food = @food,
  drinks = @drinks,
  tip = @tip,
  notes = @notes,
  delivery_date = @delivery_date,
  phone_number = @phone_number,
  address = @address,
  city = @city,
  state = @state,
  zip = @zip,
  free_soda = @free_soda
  WHERE order_id = @id;
  "
let update_order (order : Order) =
    use command = new SqlCommandProvider<sql_update_order, connectionString>(connectionString)
    command.Execute(int   order.OrderID,
  order.Name,
  order.Food,
  order.Drinks,
  order.Tip,
  order.Notes,
  order.DeliveryDate,
  order.PhoneNumber,
  order.Address,
  order.City,
  order.State,
  order.Zip,
  order.FreeSoda) |> ignore
    


let tryById_order (id:int64) =
  use cmd = new SqlCommandProvider<orderQuerySQL, connectionString>(connectionString)
  cmd.Execute(int id) |> toorder |> List.tryHead    
  
let get_orderById (id:int) =
  (tryById_order (int64 id)).Value
  
let get_orderBySId (id:string) =
  (tryById_order (int64 (System.Int32.Parse(id)))).Value

    

let getMany_order ()=
  use cmd = new SqlCommandProvider<orderQuerySQL, connectionString>(connectionString)
  cmd.Execute(0) |> toorder

let getMany_order_Names =
  getMany_order () |> List.map ( fun p-> p.ToString() ) 
    

let getManyWhere_order field how value =
  getMany_order ()
  

[<Literal>]
let reserverationQuerySQL = "DECLARE @id int = @p0; SELECT TOP 500 * FROM reserverations WHERE reserveration_id=(CASE WHEN @id=0 THEN reserveration_id ELSE @id END )"
type reserverationQuery = SqlCommandProvider< reserverationQuerySQL, connectionString>
  
let toreserveration (a:reserverationQuery.Record seq )  : Reserveration list =
  a |> Seq.map( fun record -> 
  { 
          ReserverationID = int64 record.reserveration_id;
      Name =  record.name;
      Date =  record.date;
      PhoneNumber =  record.phone_number;
  } ) 
  |> Seq.toList
    


[<Literal>]
let sql_insert_reserveration = "
INSERT INTO reserverations
    (
      name,
    date,
    phone_number
    ) VALUES (
      @name,
    @date,
    @phone_number
    ); SELECT SCOPE_IDENTITY()
  "
let insert_reserveration (reserveration : Reserveration) =
  
    use command = new SqlCommandProvider<sql_insert_reserveration, connectionString>(connectionString)
    command.Execute(  reserveration.Name,
  reserveration.Date,
  reserveration.PhoneNumber) |> Seq.head |> Option.get |> int64
    

[<Literal>]
let sql_update_reserveration = "
  DECLARE @id int = @reserveration_id;
  UPDATE reserverations
  SET
    name = @name,
  date = @date,
  phone_number = @phone_number
  WHERE reserveration_id = @id;
  "
let update_reserveration (reserveration : Reserveration) =
    use command = new SqlCommandProvider<sql_update_reserveration, connectionString>(connectionString)
    command.Execute(int   reserveration.ReserverationID,
  reserveration.Name,
  reserveration.Date,
  reserveration.PhoneNumber) |> ignore
    


let tryById_reserveration (id:int64) =
  use cmd = new SqlCommandProvider<reserverationQuerySQL, connectionString>(connectionString)
  cmd.Execute(int id) |> toreserveration |> List.tryHead    
  
let get_reserverationById (id:int) =
  (tryById_reserveration (int64 id)).Value
  
let get_reserverationBySId (id:string) =
  (tryById_reserveration (int64 (System.Int32.Parse(id)))).Value

    

let getMany_reserveration ()=
  use cmd = new SqlCommandProvider<reserverationQuerySQL, connectionString>(connectionString)
  cmd.Execute(0) |> toreserveration

let getMany_reserveration_Names =
  getMany_reserveration () |> List.map ( fun p-> p.ToString() ) 
    

let getManyWhere_reserveration field how value =
  getMany_reserveration ()
  