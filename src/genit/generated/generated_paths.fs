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
let path_create_group = "/group/create"
let path_view_group : Int64Path = "/group/view/%i"
let path_edit_group : Int64Path = "/group/edit/%i"
let path_list_group = "/group/list"
let path_search_group = "/group/search"
let path_create_supplier = "/supplier/create"
let path_view_supplier : Int64Path = "/supplier/view/%i"
let path_edit_supplier : Int64Path = "/supplier/edit/%i"
let path_list_supplier = "/supplier/list"
let path_search_supplier = "/supplier/search"
let path_create_supplierInGroup = "/supplierInGroup/create"
let path_view_supplierInGroup : Int64Path = "/supplierInGroup/view/%i"
let path_edit_supplierInGroup : Int64Path = "/supplierInGroup/edit/%i"
let path_list_supplierInGroup = "/supplierInGroup/list"
let path_search_supplierInGroup = "/supplierInGroup/search"
let path_api_group : Int64Path = "/api/group/view/%i"

let generated_routes =
  [
    path path_home >=> home
    path path_create_group >=> create_group
    pathScan path_view_group view_group
    pathScan path_edit_group edit_group
    path path_list_group >=> list_group
    path path_search_group >=> search_group
    path path_create_supplier >=> create_supplier
    pathScan path_view_supplier view_supplier
    pathScan path_edit_supplier edit_supplier
    path path_list_supplier >=> list_supplier
    path path_search_supplier >=> search_supplier
    path path_create_supplierInGroup >=> create_supplierInGroup
    pathScan path_view_supplierInGroup view_supplierInGroup
    pathScan path_edit_supplierInGroup edit_supplierInGroup
    path path_list_supplierInGroup >=> list_supplierInGroup
    path path_search_supplierInGroup >=> search_supplierInGroup
    pathScan path_api_group api_group
  ]