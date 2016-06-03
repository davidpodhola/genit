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
    Food : string
    Drinks : string
    Tip : double
    Notes : string
    DeliveryDate : System.DateTime
    PhoneNumber : string
    Address : string
    City : string
    State : string
    Zip : string
    FreeSoda : int16
  }
  
type Reserveration =
  {
    ReserverationID : int64
    Name : string
    Date : System.DateTime
    PhoneNumber : string
  }
  