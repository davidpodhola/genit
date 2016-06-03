module generated_bundles

open forms
open helper_general
open generated_fake_data
open generated_types
open generated_views
open generated_data_access
open generated_forms
open generated_validation

let bundle_group : Bundle<Group, GroupForm> =
    {
      validateForm = Some validation_groupForm
      convertForm = Some convert_groupForm
      fake_single = Some fake_group
      fake_many = Some fake_many_group
      tryById = Some tryById_group
      getMany = Some getMany_group
      getManyWhere = Some getManyWhere_group
      insert = Some insert_group
      update = Some update_group
      view_list = Some view_list_group
      view_edit = Some view_edit_group
      view_create = Some view_create_group
      view_view = Some view_view_group
      view_search = Some view_search_group
      view_edit_errored = Some view_edit_errored_group
      view_create_errored = Some view_create_errored_group
      href_create = "/group/create"
      href_search = "/group/search"
      href_view = "/group/view/%i"
      href_edit = "/group/edit/%i"
    }
    
let bundle_supplier : Bundle<Supplier, SupplierForm> =
    {
      validateForm = Some validation_supplierForm
      convertForm = Some convert_supplierForm
      fake_single = Some fake_supplier
      fake_many = Some fake_many_supplier
      tryById = Some tryById_supplier
      getMany = Some getMany_supplier
      getManyWhere = Some getManyWhere_supplier
      insert = Some insert_supplier
      update = Some update_supplier
      view_list = Some view_list_supplier
      view_edit = Some view_edit_supplier
      view_create = Some view_create_supplier
      view_view = Some view_view_supplier
      view_search = Some view_search_supplier
      view_edit_errored = Some view_edit_errored_supplier
      view_create_errored = Some view_create_errored_supplier
      href_create = "/supplier/create"
      href_search = "/supplier/search"
      href_view = "/supplier/view/%i"
      href_edit = "/supplier/edit/%i"
    }
    
let bundle_supplierInGroup : Bundle<SupplierInGroup, SupplierInGroupForm> =
    {
      validateForm = Some validation_supplierInGroupForm
      convertForm = Some convert_supplierInGroupForm
      fake_single = Some fake_supplierInGroup
      fake_many = Some fake_many_supplierInGroup
      tryById = Some tryById_supplierInGroup
      getMany = Some getMany_supplierInGroup
      getManyWhere = Some getManyWhere_supplierInGroup
      insert = Some insert_supplierInGroup
      update = Some update_supplierInGroup
      view_list = Some view_list_supplierInGroup
      view_edit = Some view_edit_supplierInGroup
      view_create = Some view_create_supplierInGroup
      view_view = Some view_view_supplierInGroup
      view_search = Some view_search_supplierInGroup
      view_edit_errored = Some view_edit_errored_supplierInGroup
      view_create_errored = Some view_create_errored_supplierInGroup
      href_create = "/supplierInGroup/create"
      href_search = "/supplierInGroup/search"
      href_view = "/supplierInGroup/view/%i"
      href_edit = "/supplierInGroup/edit/%i"
    }
    
  