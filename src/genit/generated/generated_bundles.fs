module generated_bundles

open forms
open helper_general
open generated_fake_data
open generated_types
open generated_views
open generated_data_access
open generated_forms
open generated_validation

let bundle_order : Bundle<Order, OrderForm> =
    {
      validateForm = Some validation_orderForm
      convertForm = Some convert_orderForm
      fake_single = Some fake_order
      fake_many = Some fake_many_order
      tryById = Some tryById_order
      getMany = Some getMany_order
      getManyWhere = Some getManyWhere_order
      insert = Some insert_order
      update = Some update_order
      view_list = Some view_list_order
      view_edit = Some view_edit_order
      view_create = Some view_create_order
      view_view = Some view_view_order
      view_search = Some view_search_order
      view_edit_errored = Some view_edit_errored_order
      view_create_errored = Some view_create_errored_order
      href_create = "/order/create"
      href_search = "/order/search"
      href_view = "/order/view/%i"
      href_edit = "/order/edit/%i"
    }
    
let bundle_reserveration : Bundle<Reserveration, ReserverationForm> =
    {
      validateForm = Some validation_reserverationForm
      convertForm = Some convert_reserverationForm
      fake_single = Some fake_reserveration
      fake_many = Some fake_many_reserveration
      tryById = Some tryById_reserveration
      getMany = Some getMany_reserveration
      getManyWhere = Some getManyWhere_reserveration
      insert = Some insert_reserveration
      update = Some update_reserveration
      view_list = Some view_list_reserveration
      view_edit = Some view_edit_reserveration
      view_create = Some view_create_reserveration
      view_view = Some view_view_reserveration
      view_search = Some view_search_reserveration
      view_edit_errored = Some view_edit_errored_reserveration
      view_create_errored = Some view_create_errored_reserveration
      href_create = "/reserveration/create"
      href_search = "/reserveration/search"
      href_view = "/reserveration/view/%i"
      href_edit = "/reserveration/edit/%i"
    }
    
  