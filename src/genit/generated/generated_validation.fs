module generated_validation

open generated_forms
open validators

let validation_registerForm (registerForm : RegisterForm) =
  [
    validate_required "First Name" registerForm.FirstName
    validate_required "Last Name" registerForm.LastName
    validate_email "Email" registerForm.Email
    validate_required "Email" registerForm.Email
    validate_password "Password" registerForm.Password
    validate_required "Password" registerForm.Password
    validate_password "Confirm Password" registerForm.ConfirmPassword
    validate_equal "Password" "Confirm Password" registerForm.Password registerForm.ConfirmPassword
    validate_required "Confirm Password" registerForm.ConfirmPassword
  ] |> List.choose id
  
let validation_loginForm (loginForm : LoginForm) =
  [
    validate_email "Email" loginForm.Email
    validate_required "Email" loginForm.Email
    validate_password "Password" loginForm.Password
    validate_required "Password" loginForm.Password
  ] |> List.choose id
  
let validation_orderForm (orderForm : OrderForm) =
  [
    validate_required "Name" orderForm.Name
    validate_double "Tip" orderForm.Tip
    validate_datetime "Delivery Date" orderForm.DeliveryDate
    validate_required "Delivery Date" orderForm.DeliveryDate
    validate_required "Phone Number" orderForm.PhoneNumber
  ] |> List.choose id
  
let validation_reserverationForm (reserverationForm : ReserverationForm) =
  [
    validate_required "Name" reserverationForm.Name
    validate_datetime "Date" reserverationForm.Date
    validate_required "Date" reserverationForm.Date
    validate_required "Phone Number" reserverationForm.PhoneNumber
  ] |> List.choose id
  