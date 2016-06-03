module generated_views

open Suave.Html
open helper_html
open helper_bootstrap
open generated_html
open generated_forms
open generated_data_access
open generated_types
open generator

let brand = "Office Suppliers Details"

let view_jumbo_home =
  base_html
    "Home"
    [
      base_header brand
      divClass "container" [
        divClass "jumbotron" [
          h1 (sprintf "Welcome to Office Suppliers Details!")
        ]
      ]
    ]
    scripts.common

let view_create_group =
  base_html
    "Create Group"
    [
      base_header brand
      common_form
        "Create Group"
        [
          hiddenInput "GroupID" "-1"
          label_text "Name" ""
        ]
    ]
    scripts.common

let view_create_errored_group errors (groupForm : GroupForm) =
  base_html
    "Create Group"
    [
      base_header brand
      common_form
        "Create Group"
        [
          hiddenInput "GroupID" groupForm.GroupID 
          errored_label_text "Name" (string groupForm.Name) errors
        ]
    ]
    scripts.common

let view_view_group (group : Group) =
  let button = [ button_small_success (sprintf "/group/edit/%i" group.GroupID) [ text "Edit"] ]
  base_html
    "Group"
    [
      base_header brand
      common_static_form button
        "Group"
        [
          
          label_static "Name" group.Name 
        ]
    ]
    scripts.common

let view_edit_group (group : Group) =
  base_html
    "Edit Group"
    [
      base_header brand
      common_form
        "Edit Group"
        [
          hiddenInput "GroupID" group.GroupID 
          label_text "Name" group.Name
        ]
    ]
    scripts.common

let view_edit_errored_group errors (groupForm : GroupForm) =
  base_html
    "Edit Group"
    [
      base_header brand
      common_form
        "Edit Group"
        [
          hiddenInput "GroupID" groupForm.GroupID 
          errored_label_text "Name" (string groupForm.Name) errors
        ]
    ]
    scripts.common

let view_list_group groups =
  let toTr (group : Group) inner =
    trLink (sprintf "/group/view/%i" group.GroupID) inner

  let toTd (group : Group) =
    [
        td [ text (string group.GroupID) ]
        td [ text (string group.Name) ]
    ]

  base_html
    "List Group"
    [
      base_header brand
      container [
        row [
          mcontent [
            block_flat [
              header [ h3Inner "List Groups" [ pull_right [ button_small_success "/group/create" [ text "Create"] ] ] ]
              content [
                table_bordered_linked_tr
                  [
                    "Group ID"
                    "Name"
                  ]
                  groups toTd toTr
              ]
            ]
          ]
        ]
      ]
    ]
    scripts.datatable_bundle

let view_search_group field how value groups =
  let fields = ["Name", "Name"; "Food","Food"; "City", "City"]
  let hows = ["Equals", "Equals"; "Begins With","Begins With"]
  let toTr (group : Group) inner =
    trLink (sprintf "/group/view/%i" group.GroupID) inner

  let toTd (group : Group) =
    [
        td [ text (string group.GroupID) ]
        td [ text (string group.Name) ]
    ]

  base_html
    "Search Group"
    [
      base_header brand
      container [
        row [
          mcontent [
            block_flat [
              header [
                h3Inner "Search Groups" [ ]
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
                    "Group ID"
                    "Name"
                  ]
                  groups toTd toTr
              ]
            ]
          ]
        ]
      ]
    ]
    scripts.datatable_bundle

let view_create_supplier =
  base_html
    "Create Supplier"
    [
      base_header brand
      common_form
        "Create Supplier"
        [
          hiddenInput "SupplierID" "-1"
          label_text "Name" ""
          label_textarea "Address" ""
          icon_label_text "Email" "" "envelope"
          label_text "Phone Number" ""
        ]
    ]
    scripts.common

let view_create_errored_supplier errors (supplierForm : SupplierForm) =
  base_html
    "Create Supplier"
    [
      base_header brand
      common_form
        "Create Supplier"
        [
          hiddenInput "SupplierID" supplierForm.SupplierID 
          errored_label_text "Name" (string supplierForm.Name) errors
          errored_label_textarea "Address" (string supplierForm.Address) errors
          errored_icon_label_text "Email" supplierForm.Email "envelope" errors
          errored_label_text "Phone Number" (string supplierForm.PhoneNumber) errors
        ]
    ]
    scripts.common

let view_view_supplier (supplier : Supplier) =
  let button = [ button_small_success (sprintf "/supplier/edit/%i" supplier.SupplierID) [ text "Edit"] ]
  base_html
    "Supplier"
    [
      base_header brand
      common_static_form button
        "Supplier"
        [
          
          label_static "Name" supplier.Name 
          label_static "Address" supplier.Address 
          label_static "Email" supplier.Email 
          label_static "Phone Number" supplier.PhoneNumber 
        ]
    ]
    scripts.common

let view_edit_supplier (supplier : Supplier) =
  base_html
    "Edit Supplier"
    [
      base_header brand
      common_form
        "Edit Supplier"
        [
          hiddenInput "SupplierID" supplier.SupplierID 
          label_text "Name" supplier.Name
          label_textarea "Address" supplier.Address
          icon_label_text "Email" supplier.Email "envelope"
          label_text "Phone Number" supplier.PhoneNumber
        ]
    ]
    scripts.common

let view_edit_errored_supplier errors (supplierForm : SupplierForm) =
  base_html
    "Edit Supplier"
    [
      base_header brand
      common_form
        "Edit Supplier"
        [
          hiddenInput "SupplierID" supplierForm.SupplierID 
          errored_label_text "Name" (string supplierForm.Name) errors
          errored_label_textarea "Address" (string supplierForm.Address) errors
          errored_icon_label_text "Email" supplierForm.Email "envelope" errors
          errored_label_text "Phone Number" (string supplierForm.PhoneNumber) errors
        ]
    ]
    scripts.common

let view_list_supplier suppliers =
  let toTr (supplier : Supplier) inner =
    trLink (sprintf "/supplier/view/%i" supplier.SupplierID) inner

  let toTd (supplier : Supplier) =
    [
        td [ text (string supplier.SupplierID) ]
        td [ text (string supplier.Name) ]
        td [ text (string supplier.Address) ]
        td [ text (string supplier.Email) ]
        td [ text (string supplier.PhoneNumber) ]
    ]

  base_html
    "List Supplier"
    [
      base_header brand
      container [
        row [
          mcontent [
            block_flat [
              header [ h3Inner "List Suppliers" [ pull_right [ button_small_success "/supplier/create" [ text "Create"] ] ] ]
              content [
                table_bordered_linked_tr
                  [
                    "Supplier ID"
                    "Name"
                    "Address"
                    "Email"
                    "Phone Number"
                  ]
                  suppliers toTd toTr
              ]
            ]
          ]
        ]
      ]
    ]
    scripts.datatable_bundle

let view_search_supplier field how value suppliers =
  let fields = ["Name", "Name"; "Food","Food"; "City", "City"]
  let hows = ["Equals", "Equals"; "Begins With","Begins With"]
  let toTr (supplier : Supplier) inner =
    trLink (sprintf "/supplier/view/%i" supplier.SupplierID) inner

  let toTd (supplier : Supplier) =
    [
        td [ text (string supplier.SupplierID) ]
        td [ text (string supplier.Name) ]
        td [ text (string supplier.Address) ]
        td [ text (string supplier.Email) ]
        td [ text (string supplier.PhoneNumber) ]
    ]

  base_html
    "Search Supplier"
    [
      base_header brand
      container [
        row [
          mcontent [
            block_flat [
              header [
                h3Inner "Search Suppliers" [ ]
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
                    "Supplier ID"
                    "Name"
                    "Address"
                    "Email"
                    "Phone Number"
                  ]
                  suppliers toTd toTr
              ]
            ]
          ]
        ]
      ]
    ]
    scripts.datatable_bundle

let view_create_supplierInGroup =
  base_html
    "Create SupplierInGroup"
    [
      base_header brand
      common_form
        "Create SupplierInGroup"
        [
          hiddenInput "SupplierInGroupID" "-1"
          label_select "Group" (zipOptions getMany_group_Names)
          label_select "Supplier" (zipOptions getMany_supplier_Names)
        ]
    ]
    scripts.common

let view_create_errored_supplierInGroup errors (supplierInGroupForm : SupplierInGroupForm) =
  base_html
    "Create SupplierInGroup"
    [
      base_header brand
      common_form
        "Create SupplierInGroup"
        [
          hiddenInput "SupplierInGroupID" supplierInGroupForm.SupplierInGroupID 
          errored_label_select "Group" (zipOptions getMany_group_Names) (Some supplierInGroupForm.Group) errors
          errored_label_select "Supplier" (zipOptions getMany_supplier_Names) (Some supplierInGroupForm.Supplier) errors
        ]
    ]
    scripts.common

let view_view_supplierInGroup (supplierInGroup : SupplierInGroup) =
  let button = [ button_small_success (sprintf "/supplierInGroup/edit/%i" supplierInGroup.SupplierInGroupID) [ text "Edit"] ]
  base_html
    "SupplierInGroup"
    [
      base_header brand
      common_static_form button
        "SupplierInGroup"
        [
          
          label_static "Group" supplierInGroup.Group 
          label_static "Supplier" supplierInGroup.Supplier 
        ]
    ]
    scripts.common

let view_edit_supplierInGroup (supplierInGroup : SupplierInGroup) =
  base_html
    "Edit SupplierInGroup"
    [
      base_header brand
      common_form
        "Edit SupplierInGroup"
        [
          hiddenInput "SupplierInGroupID" supplierInGroup.SupplierInGroupID 
          label_select_selected "Group" (zipOptions getMany_group_Names) (Some supplierInGroup.Group)
          label_select_selected "Supplier" (zipOptions getMany_supplier_Names) (Some supplierInGroup.Supplier)
        ]
    ]
    scripts.common

let view_edit_errored_supplierInGroup errors (supplierInGroupForm : SupplierInGroupForm) =
  base_html
    "Edit SupplierInGroup"
    [
      base_header brand
      common_form
        "Edit SupplierInGroup"
        [
          hiddenInput "SupplierInGroupID" supplierInGroupForm.SupplierInGroupID 
          errored_label_select "Group" (zipOptions getMany_group_Names) (Some supplierInGroupForm.Group) errors
          errored_label_select "Supplier" (zipOptions getMany_supplier_Names) (Some supplierInGroupForm.Supplier) errors
        ]
    ]
    scripts.common

let view_list_supplierInGroup supplierInGroups =
  let toTr (supplierInGroup : SupplierInGroup) inner =
    trLink (sprintf "/supplierInGroup/view/%i" supplierInGroup.SupplierInGroupID) inner

  let toTd (supplierInGroup : SupplierInGroup) =
    [
        td [ text (string supplierInGroup.SupplierInGroupID) ]
        td [ text (string supplierInGroup.Group) ]
        td [ text (string supplierInGroup.Supplier) ]
    ]

  base_html
    "List SupplierInGroup"
    [
      base_header brand
      container [
        row [
          mcontent [
            block_flat [
              header [ h3Inner "List SupplierInGroups" [ pull_right [ button_small_success "/supplierInGroup/create" [ text "Create"] ] ] ]
              content [
                table_bordered_linked_tr
                  [
                    "SupplierInGroup ID"
                    "Group"
                    "Supplier"
                  ]
                  supplierInGroups toTd toTr
              ]
            ]
          ]
        ]
      ]
    ]
    scripts.datatable_bundle

let view_search_supplierInGroup field how value supplierInGroups =
  let fields = ["Name", "Name"; "Food","Food"; "City", "City"]
  let hows = ["Equals", "Equals"; "Begins With","Begins With"]
  let toTr (supplierInGroup : SupplierInGroup) inner =
    trLink (sprintf "/supplierInGroup/view/%i" supplierInGroup.SupplierInGroupID) inner

  let toTd (supplierInGroup : SupplierInGroup) =
    [
        td [ text (string supplierInGroup.SupplierInGroupID) ]
        td [ text (string supplierInGroup.Group) ]
        td [ text (string supplierInGroup.Supplier) ]
    ]

  base_html
    "Search SupplierInGroup"
    [
      base_header brand
      container [
        row [
          mcontent [
            block_flat [
              header [
                h3Inner "Search SupplierInGroups" [ ]
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
                    "SupplierInGroup ID"
                    "Group"
                    "Supplier"
                  ]
                  supplierInGroups toTd toTr
              ]
            ]
          ]
        ]
      ]
    ]
    scripts.datatable_bundle