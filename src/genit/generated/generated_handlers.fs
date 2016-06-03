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

let register =
  choose
    [
      GET >=> OK view_register
      POST >=> bindToForm registerForm (fun registerForm ->
        let validation = validation_registerForm registerForm
        if validation = [] then
          let converted = convert_registerForm registerForm
          let id = insert_register converted
          setAuthCookieAndRedirect id "/"
        else
          OK (view_errored_register validation registerForm))
    ]

let login =
  choose
    [
      GET >=> (OK <| view_login false "")
      POST >=> request (fun req ->
        bindToForm loginForm (fun loginForm ->
        let validation = validation_loginForm loginForm
        if validation = [] then
          let converted = convert_loginForm loginForm
          let loginAttempt = authenticate converted
          match loginAttempt with
            | Some(loginAttempt) ->
              let returnPath = getQueryStringValue req "returnPath"
              let returnPath = if returnPath = "" then "/" else returnPath
              setAuthCookieAndRedirect id returnPath
            | None -> OK <| view_login true loginForm.Email
        else
          OK (view_errored_login validation loginForm)))
    ]

let create_order =
  choose
    [
      GET >=> request (fun req -> createOrGenerateGET req bundle_order)
      POST >=> bindToForm orderForm (fun form -> createPOST form bundle_order)
    ]

let view_order id =
  GET >=> warbler (fun _ -> viewGET id bundle_order)

let edit_order id =
  choose
    [
      GET >=> warbler (fun _ -> editGET id bundle_order)
      POST >=> bindToForm orderForm (fun orderForm -> editPOST id orderForm bundle_order)
    ]

let list_order =
  GET >=> warbler (fun _ -> getMany_order () |> view_list_order |> OK)

let search_order =
  choose
    [
      GET >=> request (fun req -> searchGET req bundle_order)
      POST >=> bindToForm searchForm (fun searchForm -> searchPOST searchForm bundle_order)
    ]

let create_reserveration =
  choose
    [
      GET >=> request (fun req -> createOrGenerateGET req bundle_reserveration)
      POST >=> bindToForm reserverationForm (fun form -> createPOST form bundle_reserveration)
    ]

let view_reserveration id =
  GET >=> warbler (fun _ -> viewGET id bundle_reserveration)

let edit_reserveration id =
  choose
    [
      GET >=> warbler (fun _ -> editGET id bundle_reserveration)
      POST >=> bindToForm reserverationForm (fun reserverationForm -> editPOST id reserverationForm bundle_reserveration)
    ]

let list_reserveration =
  GET >=> warbler (fun _ -> getMany_reserveration () |> view_list_reserveration |> OK)

let search_reserveration =
  choose
    [
      GET >=> request (fun req -> searchGET req bundle_reserveration)
      POST >=> bindToForm searchForm (fun searchForm -> searchPOST searchForm bundle_reserveration)
    ]

let api_order id =
  GET >=> request (fun req ->
    let data = tryById_order id
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