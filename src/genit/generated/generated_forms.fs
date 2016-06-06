module generated_forms

open Suave.Model.Binding
open Suave.Form
open generated_types
open generated_data_access

type RegisterForm =
  {
    UserID : string
    FirstName : string
    LastName : string
    Email : string
    Password : string
    ConfirmPassword : string
  }

let registerForm : Form<RegisterForm> = Form ([],[])

let convert_registerForm (registerForm : RegisterForm) : Register =
  {
    UserID = int64 registerForm.UserID
    FirstName = registerForm.FirstName
    LastName = registerForm.LastName
    Email = registerForm.Email
    Password = registerForm.Password
  }
  
type LoginForm =
  {
    UserID : string
    Email : string
    Password : string
  }

let loginForm : Form<LoginForm> = Form ([],[])

let convert_loginForm (loginForm : LoginForm) : Login =
  {
    UserID = int64 loginForm.UserID
    Email = loginForm.Email
    Password = loginForm.Password
  }
  
type OrderForm =
  {
    OrderID : string
    Name : string
    Food : string
    Drinks : string
    Tip : string
    Notes : string
    DeliveryDate : string
    PhoneNumber : string
    Address : string
    City : string
    State : string
    Zip : string
    FreeSoda : string
  }

let orderForm : Form<OrderForm> = Form ([],[])

let convert_orderForm (orderForm : OrderForm) : Order =
  {
    OrderID = int64 orderForm.OrderID
    Name = orderForm.Name
    Food = Some(orderForm.Food)
    Drinks = Some(orderForm.Drinks)
    Tip = decimal Some(orderForm.Tip)
    Notes = Some(orderForm.Notes)
    DeliveryDate = System.DateTime.Parse(orderForm.DeliveryDate)
    PhoneNumber = orderForm.PhoneNumber
    Address = Some(orderForm.Address)
    City = Some(orderForm.City)
    State = Some(orderForm.State)
    Zip = Some(orderForm.Zip)
    FreeSoda = int16 Some(orderForm.FreeSoda)
  }
  
type ReserverationForm =
  {
    ReserverationID : string
    Name : string
    Date : string
    PhoneNumber : string
  }

let reserverationForm : Form<ReserverationForm> = Form ([],[])

let convert_reserverationForm (reserverationForm : ReserverationForm) : Reserveration =
  {
    ReserverationID = int64 reserverationForm.ReserverationID
    Name = reserverationForm.Name
    Date = System.DateTime.Parse(reserverationForm.Date)
    PhoneNumber = reserverationForm.PhoneNumber
  }
  