module generated_views

open Suave.Html
open helper_html
open helper_bootstrap
open generated_html
open generated_forms
open generated_data_access
open generated_types
open generator
open helper_general

let brand = "Bob's Burgers"

let view_jumbo_home =
  base_html
    "Home"
    [
      base_header brand
      divClass "container" [
        divClass "jumbotron" [
          h1 (sprintf "Welcome to Bob's Burgers!")
        ]
      ]
    ]
    scripts.common

let view_register =
  base_html
    "Register"
    [
      base_header brand
      common_register_form
        "Register"
        [
          hiddenInput "UserID" "-1"
          icon_label_text "First Name" "" "user"
          icon_label_text "Last Name" "" "user"
          icon_label_text "Email" "" "envelope"
          icon_password_text "Password" "" "lock"
          icon_password_text "Confirm Password" "" "lock"
        ]
    ]
    scripts.common

let view_errored_register errors (registerForm : RegisterForm) =
  base_html
    "Register"
    [
      base_header brand
      common_register_form
        "Register"
        [
          hiddenInput "UserID" registerForm.UserID 
          errored_icon_label_text "First Name" registerForm.FirstName "user" errors
          errored_icon_label_text "Last Name" registerForm.LastName "user" errors
          errored_icon_label_text "Email" registerForm.Email "envelope" errors
          errored_icon_password_text "Password" registerForm.Password "lock" errors
          errored_icon_password_text "Confirm Password" registerForm.ConfirmPassword "lock" errors
        ]
    ]
    scripts.common

let view_login error email =
  let errorTag =
    if error
    then stand_alone_error "Invalid email or password"
    else emptyText

  base_html
    "Login"
    [
      base_header brand
      common_register_form
        "Login"
        [
          errorTag
          hiddenInput "UserID" "-1"
          icon_label_text "Email" email "envelope"
          icon_password_text "Password" "" "lock"
        ]
    ]
    scripts.common

let view_errored_login errors (loginForm : LoginForm) =
  base_html
    "Login"
    [
      base_header brand
      common_register_form
        "Login"
        [
          hiddenInput "UserID" loginForm.UserID 
          errored_icon_label_text "Email" loginForm.Email "envelope" errors
          errored_icon_password_text "Password" loginForm.Password "lock" errors
        ]
    ]
    scripts.common

let view_create_order =
  base_html
    "Create Order"
    [
      base_header brand
      common_form
        "Create Order"
        [
          hiddenInput "OrderID" "-1"
          label_text "Name" ""
          label_text "Food" ""
          label_text "Drinks" ""
          label_text "Tip" ""
          label_textarea "Notes" ""
          label_datetime "Delivery Date" ""
          label_text "Phone Number" ""
          label_text "Address" ""
          label_text "City" ""
          label_text "State" ""
          label_text "Zip" ""
          label_select "Free Soda" [("0", ""); ("1", "Cola"); ("2", "Orange"); ("3", "Root Beer")]
        ]
    ]
    scripts.common

let view_create_errored_order errors (orderForm : OrderForm) =
  base_html
    "Create Order"
    [
      base_header brand
      common_form
        "Create Order"
        [
          hiddenInput "OrderID" orderForm.OrderID 
          errored_label_text "Name" (string orderForm.Name) errors
          errored_label_text "Food" (string orderForm.Food) errors
          errored_label_text "Drinks" (string orderForm.Drinks) errors
          errored_label_text "Tip" (string orderForm.Tip) errors
          errored_label_textarea "Notes" (string orderForm.Notes) errors
          errored_label_datetime "Delivery Date" (string orderForm.DeliveryDate) errors
          errored_label_text "Phone Number" (string orderForm.PhoneNumber) errors
          errored_label_text "Address" (string orderForm.Address) errors
          errored_label_text "City" (string orderForm.City) errors
          errored_label_text "State" (string orderForm.State) errors
          errored_label_text "Zip" (string orderForm.Zip) errors
          errored_label_select "Free Soda" [("0", ""); ("1", "Cola"); ("2", "Orange"); ("3", "Root Beer")] (Some orderForm.FreeSoda) errors
        ]
    ]
    scripts.common

let view_view_order (order : Order) =
  let button = [ button_small_success (sprintf "/order/edit/%i" order.OrderID) [ text "Edit"] ]
  base_html
    "Order"
    [
      base_header brand
      common_static_form button
        "Order"
        [
          
          label_static "Name" order.Name 
          label_static "Food" order.Food 
          label_static "Drinks" order.Drinks 
          label_static "Tip" order.Tip 
          label_static "Notes" order.Notes 
          label_static "Delivery Date" order.DeliveryDate 
          label_static "Phone Number" order.PhoneNumber 
          label_static "Address" order.Address 
          label_static "City" order.City 
          label_static "State" order.State 
          label_static "Zip" order.Zip 
          label_static "Free Soda" order.FreeSoda 
        ]
    ]
    scripts.common

let view_edit_order (order : Order) =
  base_html
    "Edit Order"
    [
      base_header brand
      common_form
        "Edit Order"
        [
          hiddenInput "OrderID" order.OrderID 
          label_text "Name" order.Name
          label_text "Food" (option2Val order.Food)
          label_text "Drinks" (option2Val order.Drinks)
          label_text "Tip" (option2Val order.Tip)
          label_textarea "Notes" (option2Val order.Notes)
          label_datetime "Delivery Date" order.DeliveryDate
          label_text "Phone Number" order.PhoneNumber
          label_text "Address" (option2Val order.Address)
          label_text "City" (option2Val order.City)
          label_text "State" (option2Val order.State)
          label_text "Zip" (option2Val order.Zip)
          label_select_selected "Free Soda" [("0", ""); ("1", "Cola"); ("2", "Orange"); ("3", "Root Beer")] (Some order.FreeSoda)
        ]
    ]
    scripts.common

let view_edit_errored_order errors (orderForm : OrderForm) =
  base_html
    "Edit Order"
    [
      base_header brand
      common_form
        "Edit Order"
        [
          hiddenInput "OrderID" orderForm.OrderID 
          errored_label_text "Name" (string orderForm.Name) errors
          errored_label_text "Food" (string orderForm.Food) errors
          errored_label_text "Drinks" (string orderForm.Drinks) errors
          errored_label_text "Tip" (string orderForm.Tip) errors
          errored_label_textarea "Notes" (string orderForm.Notes) errors
          errored_label_datetime "Delivery Date" (string orderForm.DeliveryDate) errors
          errored_label_text "Phone Number" (string orderForm.PhoneNumber) errors
          errored_label_text "Address" (string orderForm.Address) errors
          errored_label_text "City" (string orderForm.City) errors
          errored_label_text "State" (string orderForm.State) errors
          errored_label_text "Zip" (string orderForm.Zip) errors
          errored_label_select "Free Soda" [("0", ""); ("1", "Cola"); ("2", "Orange"); ("3", "Root Beer")] (Some orderForm.FreeSoda) errors
        ]
    ]
    scripts.common

let view_list_order orders =
  let toTr (order : Order) inner =
    trLink (sprintf "/order/view/%i" order.OrderID) inner

  let toTd (order : Order) =
    [
        td [ text (string order.OrderID) ]
        td [ text (string order.Name) ]
        td [ text (string order.Food) ]
        td [ text (string order.Drinks) ]
        td [ text (string order.Tip) ]
        td [ text (string order.Notes) ]
        td [ text (string order.DeliveryDate) ]
        td [ text (string order.PhoneNumber) ]
        td [ text (string order.Address) ]
        td [ text (string order.City) ]
        td [ text (string order.State) ]
        td [ text (string order.Zip) ]
        td [ text (string order.FreeSoda) ]
    ]

  base_html
    "List Order"
    [
      base_header brand
      container [
        row [
          mcontent [
            block_flat [
              header [ h3Inner "List Orders" [ pull_right [ button_small_success "/order/create" [ text "Create"] ] ] ]
              content [
                table_bordered_linked_tr
                  [
                    "Order ID"
                    "Name"
                    "Food"
                    "Drinks"
                    "Tip"
                    "Notes"
                    "Delivery Date"
                    "Phone Number"
                    "Address"
                    "City"
                    "State"
                    "Zip"
                    "Free Soda"
                  ]
                  orders toTd toTr
              ]
            ]
          ]
        ]
      ]
    ]
    scripts.datatable_bundle

let view_search_order field how value orders =
  let fields = ["Name", "Name"; "Food","Food"; "City", "City"]
  let hows = ["Equals", "Equals"; "Begins With","Begins With"]
  let toTr (order : Order) inner =
    trLink (sprintf "/order/view/%i" order.OrderID) inner

  let toTd (order : Order) =
    [
        td [ text (string order.OrderID) ]
        td [ text (string order.Name) ]
        td [ text (string order.Food) ]
        td [ text (string order.Drinks) ]
        td [ text (string order.Tip) ]
        td [ text (string order.Notes) ]
        td [ text (string order.DeliveryDate) ]
        td [ text (string order.PhoneNumber) ]
        td [ text (string order.Address) ]
        td [ text (string order.City) ]
        td [ text (string order.State) ]
        td [ text (string order.Zip) ]
        td [ text (string order.FreeSoda) ]
    ]

  base_html
    "Search Order"
    [
      base_header brand
      container [
        row [
          mcontent [
            block_flat [
              header [
                h3Inner "Search Orders" [ ]
              ]
              div [
                form_inline [
                  content [
                    inline_label_select_selected "Field" fields field
                    inline_label_select_selected"How" hows how
                    inline_label_text "Value" value
                    pull_right [ button_submit ]
                  ]
                ]
              ]
              content [
                table_bordered_linked_tr
                  [
                    "Order ID"
                    "Name"
                    "Food"
                    "Drinks"
                    "Tip"
                    "Notes"
                    "Delivery Date"
                    "Phone Number"
                    "Address"
                    "City"
                    "State"
                    "Zip"
                    "Free Soda"
                  ]
                  orders toTd toTr
              ]
            ]
          ]
        ]
      ]
    ]
    scripts.datatable_bundle

let view_create_reserveration =
  base_html
    "Create Reserveration"
    [
      base_header brand
      common_form
        "Create Reserveration"
        [
          hiddenInput "ReserverationID" "-1"
          label_text "Name" ""
          label_datetime "Date" ""
          label_text "Phone Number" ""
        ]
    ]
    scripts.common

let view_create_errored_reserveration errors (reserverationForm : ReserverationForm) =
  base_html
    "Create Reserveration"
    [
      base_header brand
      common_form
        "Create Reserveration"
        [
          hiddenInput "ReserverationID" reserverationForm.ReserverationID 
          errored_label_text "Name" (string reserverationForm.Name) errors
          errored_label_datetime "Date" (string reserverationForm.Date) errors
          errored_label_text "Phone Number" (string reserverationForm.PhoneNumber) errors
        ]
    ]
    scripts.common

let view_view_reserveration (reserveration : Reserveration) =
  let button = [ button_small_success (sprintf "/reserveration/edit/%i" reserveration.ReserverationID) [ text "Edit"] ]
  base_html
    "Reserveration"
    [
      base_header brand
      common_static_form button
        "Reserveration"
        [
          
          label_static "Name" reserveration.Name 
          label_static "Date" reserveration.Date 
          label_static "Phone Number" reserveration.PhoneNumber 
        ]
    ]
    scripts.common

let view_edit_reserveration (reserveration : Reserveration) =
  base_html
    "Edit Reserveration"
    [
      base_header brand
      common_form
        "Edit Reserveration"
        [
          hiddenInput "ReserverationID" reserveration.ReserverationID 
          label_text "Name" reserveration.Name
          label_datetime "Date" reserveration.Date
          label_text "Phone Number" reserveration.PhoneNumber
        ]
    ]
    scripts.common

let view_edit_errored_reserveration errors (reserverationForm : ReserverationForm) =
  base_html
    "Edit Reserveration"
    [
      base_header brand
      common_form
        "Edit Reserveration"
        [
          hiddenInput "ReserverationID" reserverationForm.ReserverationID 
          errored_label_text "Name" (string reserverationForm.Name) errors
          errored_label_datetime "Date" (string reserverationForm.Date) errors
          errored_label_text "Phone Number" (string reserverationForm.PhoneNumber) errors
        ]
    ]
    scripts.common

let view_list_reserveration reserverations =
  let toTr (reserveration : Reserveration) inner =
    trLink (sprintf "/reserveration/view/%i" reserveration.ReserverationID) inner

  let toTd (reserveration : Reserveration) =
    [
        td [ text (string reserveration.ReserverationID) ]
        td [ text (string reserveration.Name) ]
        td [ text (string reserveration.Date) ]
        td [ text (string reserveration.PhoneNumber) ]
    ]

  base_html
    "List Reserveration"
    [
      base_header brand
      container [
        row [
          mcontent [
            block_flat [
              header [ h3Inner "List Reserverations" [ pull_right [ button_small_success "/reserveration/create" [ text "Create"] ] ] ]
              content [
                table_bordered_linked_tr
                  [
                    "Reserveration ID"
                    "Name"
                    "Date"
                    "Phone Number"
                  ]
                  reserverations toTd toTr
              ]
            ]
          ]
        ]
      ]
    ]
    scripts.datatable_bundle

let view_search_reserveration field how value reserverations =
  let fields = ["Name", "Name"; "Food","Food"; "City", "City"]
  let hows = ["Equals", "Equals"; "Begins With","Begins With"]
  let toTr (reserveration : Reserveration) inner =
    trLink (sprintf "/reserveration/view/%i" reserveration.ReserverationID) inner

  let toTd (reserveration : Reserveration) =
    [
        td [ text (string reserveration.ReserverationID) ]
        td [ text (string reserveration.Name) ]
        td [ text (string reserveration.Date) ]
        td [ text (string reserveration.PhoneNumber) ]
    ]

  base_html
    "Search Reserveration"
    [
      base_header brand
      container [
        row [
          mcontent [
            block_flat [
              header [
                h3Inner "Search Reserverations" [ ]
              ]
              div [
                form_inline [
                  content [
                    inline_label_select_selected "Field" fields field
                    inline_label_select_selected"How" hows how
                    inline_label_text "Value" value
                    pull_right [ button_submit ]
                  ]
                ]
              ]
              content [
                table_bordered_linked_tr
                  [
                    "Reserveration ID"
                    "Name"
                    "Date"
                    "Phone Number"
                  ]
                  reserverations toTd toTr
              ]
            ]
          ]
        ]
      ]
    ]
    scripts.datatable_bundle