module generated_paths

open Suave
open Suave.Filters
open Suave.Successful
open Suave.Operators
open Suave.Model.Binding
open Suave.Form
open Suave.ServerErrors
open forms
open helper_handler
open generated_handlers

type Int64Path = PrintfFormat<(int64 -> string),unit,string,string,int64>

let path_home = "/"
let path_register = "/register"
let path_login = "/login"
let path_create_order = "/order/create"
let path_view_order : Int64Path = "/order/view/%i"
let path_edit_order : Int64Path = "/order/edit/%i"
let path_list_order = "/order/list"
let path_search_order = "/order/search"
let path_create_reserveration = "/reserveration/create"
let path_view_reserveration : Int64Path = "/reserveration/view/%i"
let path_edit_reserveration : Int64Path = "/reserveration/edit/%i"
let path_list_reserveration = "/reserveration/list"
let path_search_reserveration = "/reserveration/search"
let path_api_order : Int64Path = "/api/order/view/%i"

let generated_routes =
  [
    path path_home >=> home
    path path_register >=> register
    path path_login >=> login
    path path_create_order >=> create_order
    pathScan path_view_order view_order
    pathScan path_edit_order edit_order
    path path_list_order >=> list_order
    path path_search_order >=> search_order
    path path_create_reserveration >=> loggedOn path_login create_reserveration
    pathScan path_view_reserveration (fun id -> loggedOn path_login (view_reserveration id))
    pathScan path_edit_reserveration (fun id -> loggedOn path_login (edit_reserveration id))
    path path_list_reserveration >=> loggedOn path_login list_reserveration
    path path_search_reserveration >=> loggedOn path_login search_reserveration
    pathScan path_api_order api_order
  ]