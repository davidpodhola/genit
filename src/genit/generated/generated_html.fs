module generated_html

open System
open Suave.Html
open helper_html
open helper_bootstrap

let base_header brand =
  navClass "navbar navbar-default" [
    container [
      navbar_header [
        buttonAttr
          ["type","button"; "class","navbar-toggle collapsed"; "data-toggle","collapse"; "data-target","#navbar"; "aria-expanded","false"; "aria-controls","navbar" ]
          [
            spanClass "sr-only" [text "Toggle navigation"]
            spanClass "icon-bar" [emptyText]
            spanClass "icon-bar" [emptyText]
            spanClass "icon-bar" [emptyText]
          ]
        navbar_brand [ text brand ]
      ]
      navbar [
        navbar_nav [
          dropdown [
            dropdown_toggle [text "Pages "; caret]
            dropdown_menu [
              li [ aHref "/" [text "Home"] ]
              li [ aHref "/group/create" [text "Create Group"] ]
              li [ aHref "/group/list" [text "List Groups"] ]
              li [ aHref "/group/search" [text "Search Groups"] ]
              li [ aHref "/supplier/create" [text "Create Supplier"] ]
              li [ aHref "/supplier/list" [text "List Suppliers"] ]
              li [ aHref "/supplier/search" [text "Search Suppliers"] ]
              li [ aHref "/supplierInGroup/create" [text "Create SupplierInGroup"] ]
              li [ aHref "/supplierInGroup/list" [text "List SupplierInGroups"] ]
              li [ aHref "/supplierInGroup/search" [text "Search SupplierInGroups"] ]
            ]
          ]
        ]
      ]
    ]
  ]

  