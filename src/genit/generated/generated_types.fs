module generated_types

type Register =
  {
    UserID : int64
    FirstName : string
    LastName : string
    Email : string
    Password : string
  }
  
type Login =
  {
    UserID : int64
    Email : string
    Password : string
  }
  
type Order =
  {
    OrderID : int64
    Name : string
    Food : string option
    Drinks : string option
    Tip : decimal option
    Notes : string option
    DeliveryDate : System.DateTime
    PhoneNumber : string
    Address : string option
    City : string option
    State : string option
    Zip : string option
    FreeSoda : int16 option
  }
  
type Reserveration =
  {
    ReserverationID : int64
    Name : string
    Date : System.DateTime
    PhoneNumber : string
  }
  