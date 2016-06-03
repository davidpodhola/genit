module generated_handlers

open System.Web
open Suave
open Suave.Authentication
open Suave.State.CookieStateStore
open Suave.Filters
open Suave.Successful
open Suave.Redirection
open Suave.Operators
open generated_views
open generated_forms
open generated_types
open generated_validation
open generated_data_access
open generated_fake_data
open generated_bundles
open helper_html
open helper_handler
open Nessos.FsPickler
open Nessos.FsPickler.Json
open forms


let home = GET >=> OK view_jumbo_home

let create_group =
  choose
    [
      GET >=> request (fun req -> createOrGenerateGET req bundle_group)
      POST >=> bindToForm groupForm (fun form -> createPOST form bundle_group)
    ]

let view_group id =
  GET >=> warbler (fun _ -> viewGET id bundle_group)

let edit_group id =
  choose
    [
      GET >=> warbler (fun _ -> editGET id bundle_group)
      POST >=> bindToForm groupForm (fun groupForm -> editPOST id groupForm bundle_group)
    ]

let list_group =
  GET >=> warbler (fun _ -> getMany_group () |> view_list_group |> OK)

let search_group =
  choose
    [
      GET >=> request (fun req -> searchGET req bundle_group)
      POST >=> bindToForm searchForm (fun searchForm -> searchPOST searchForm bundle_group)
    ]

let create_supplier =
  choose
    [
      GET >=> request (fun req -> createOrGenerateGET req bundle_supplier)
      POST >=> bindToForm supplierForm (fun form -> createPOST form bundle_supplier)
    ]

let view_supplier id =
  GET >=> warbler (fun _ -> viewGET id bundle_supplier)

let edit_supplier id =
  choose
    [
      GET >=> warbler (fun _ -> editGET id bundle_supplier)
      POST >=> bindToForm supplierForm (fun supplierForm -> editPOST id supplierForm bundle_supplier)
    ]

let list_supplier =
  GET >=> warbler (fun _ -> getMany_supplier () |> view_list_supplier |> OK)

let search_supplier =
  choose
    [
      GET >=> request (fun req -> searchGET req bundle_supplier)
      POST >=> bindToForm searchForm (fun searchForm -> searchPOST searchForm bundle_supplier)
    ]

let create_supplierInGroup =
  choose
    [
      GET >=> request (fun req -> createOrGenerateGET req bundle_supplierInGroup)
      POST >=> bindToForm supplierInGroupForm (fun form -> createPOST form bundle_supplierInGroup)
    ]

let view_supplierInGroup id =
  GET >=> warbler (fun _ -> viewGET id bundle_supplierInGroup)

let edit_supplierInGroup id =
  choose
    [
      GET >=> warbler (fun _ -> editGET id bundle_supplierInGroup)
      POST >=> bindToForm supplierInGroupForm (fun supplierInGroupForm -> editPOST id supplierInGroupForm bundle_supplierInGroup)
    ]

let list_supplierInGroup =
  GET >=> warbler (fun _ -> getMany_supplierInGroup () |> view_list_supplierInGroup |> OK)

let search_supplierInGroup =
  choose
    [
      GET >=> request (fun req -> searchGET req bundle_supplierInGroup)
      POST >=> bindToForm searchForm (fun searchForm -> searchPOST searchForm bundle_supplierInGroup)
    ]

let api_group id =
  GET >=> request (fun req ->
    let data = tryById_group id
    match data with
    | None -> OK error_404
    | Some(data) ->
      match (getQueryStringValue req "format").ToLower() with
      | "xml" ->
         let serializer = FsPickler.CreateXmlSerializer(indent = true)
         Writers.setMimeType "application/xml"
         >=> OK (serializer.PickleToString(data))
      | "json" | _ ->
         let serializer = FsPickler.CreateJsonSerializer(indent = true)
         Writers.setMimeType "application/json"
         >=> OK (serializer.PickleToString(data)))