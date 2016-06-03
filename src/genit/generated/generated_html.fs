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
              li [ aHref "/register" [text "Register"] ]
              li [ aHref "/login" [text "Login"] ]
              li [ aHref "/order/create" [text "Create Order"] ]
              li [ aHref "/order/list" [text "List Orders"] ]
              li [ aHref "/order/search" [text "Search Orders"] ]
              li [ aHref "/reserveration/create" [text "Create Reserveration"] ]
              li [ aHref "/reserveration/list" [text "List Reserverations"] ]
              li [ aHref "/reserveration/search" [text "Search Reserverations"] ]
            ]
          ]
        ]
      ]
    ]
  ]

  