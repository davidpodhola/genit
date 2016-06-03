module mssql

open dsl
open helper_general
open System

let createTemplate (dbname:string) =
  String.Format("""
use master;
GO
ALTER DATABASE {0} SET SINGLE_USER
GO
DROP DATABASE {0}
GO
CREATE DATABASE {0};""", dbname )

let initialSetupTemplate (dbname : string) = System.String.Format("""
""" )

(*

CREATE TABLES

*)

let columnTypeTemplate field =
  match field.FieldType with
  | Id              -> "int IDENTITY (1,1)"
  | Text            -> "nvarchar(1024)"
  | Paragraph       -> "ntext"
  | Number          -> "int"
  | Decimal         -> "decimal(12, 2)"
  | Date            -> "datetime"
  | Phone           -> "varchar(15)"
  | Email           -> "varchar(128)"
  | Name            -> "varchar(128)"
  | Password        -> "varchar(60)"
  | ConfirmPassword -> ""
  | Dropdown (_)    -> "smallint"
  | Referenced      -> "int"

//http://www.postgresql.org/docs/9.5/static/ddl-constraints.html
let columnAttributesTemplate (field : Field) =
  match field.Attribute with
  | PK              -> "PRIMARY KEY NOT NULL"
  | Null            -> "NULL"
  | Required        -> "NOT NULL"
  | Min(min)        -> sprintf "CHECK (%s > %i)" field.AsDBColumn min
  | Max(max)        -> sprintf "CHECK (%s < %i)" field.AsDBColumn max
  | Range(min, max) -> sprintf "CHECK (%i < %s < %i)" min field.AsDBColumn max
  | Reference(table,required) -> sprintf "REFERENCES [%s] (%s) %s" (to_tableName table) field.AsDBColumn (if required then "NOT NULL" else "NULL")

let columnTemplate namePad typePad (field : Field) =
 sprintf "%s %s %s" (rightPad namePad field.AsDBColumn) (rightPad typePad (columnTypeTemplate field)) (columnAttributesTemplate field)

let createColumns (page : Page) =
  let maxName = page.Fields |> List.map (fun field -> field.AsDBColumn.Length) |> List.max
  let maxName = if maxName > 20 then maxName else 20
  let maxType = page.Fields |> List.map (fun field -> (columnTypeTemplate field).Length) |> List.max
  let maxType = if maxType > 20 then maxType else 20

  page.Fields
  |> List.filter (fun field -> field.FieldType <> ConfirmPassword)
  |> List.map (columnTemplate maxName maxType)
  |> List.map (pad 1)
  |> flattenWith ","

let createTableTemplate (dbname : string) (page : Page) =
  let columns = createColumns page
  sprintf """
CREATE TABLE %s.%s(
%s
);
  """ dbname page.AsTable columns

let shouldICreateTable page =
  match page.PageMode with
  | CVELS
  | CVEL
  | Create
  | Edit
  | View
  | List
  | Register    -> true
  | Login       -> false
  | Search      -> true
  | Jumbotron   -> false

let createTableTemplates (site : Site) =
  site.Pages
  |> List.filter (fun page -> shouldICreateTable page)
  |> List.filter (fun page -> page.CreateTable = CreateTable)
  |> List.map (createTableTemplate site.AsDatabase)
  |> flatten

let grantPrivileges (site : Site) =
  """
  """ 

let createTables guts1 guts2 =
  sprintf """
%s

%s
  """ guts1 guts2

(*

DATA READERS

*)

let readConversionTemplate field =
  match field.FieldType with
  | Id              -> "int64"
  | Text            -> ""
  | Paragraph       -> ""
  | Number          -> ""
  | Decimal         -> ""
  | Date            -> ""
  | Phone           -> ""
  | Email           -> ""
  | Name            -> ""
  | Password        -> ""
  | ConfirmPassword -> ""
  | Dropdown (_)    -> ""
  | Referenced      -> sprintf "get_%sById" (to_dbColumn field.Name)

let dataReaderPropertyTemplate field =
 sprintf """%s = %s record.%s;""" field.AsProperty (readConversionTemplate field)  field.AsDBColumn

let dataReaderPropertiesTemplate page =
  page.Fields
  |> List.filter (fun field -> field.FieldType <> ConfirmPassword)
  |> List.map (fun field -> dataReaderPropertyTemplate field)
  |> List.map (pad 3)
  |> flatten

let dataReaderTemplate page =
  let idField = page.Fields |> List.find (fun field -> field.FieldType = Id)
  System.String.Format(
    sprintf """
[<Literal>]
let {0}QuerySQL = "DECLARE @id int = @p0; SELECT TOP 500 * FROM %s WHERE %s=(CASE WHEN @id=0 THEN %s ELSE @id END )"
type {0}Query = SqlCommandProvider< {0}QuerySQL, connectionString>
  
let to{0} (a:{0}Query.Record seq )  : %s list =
  a |> Seq.map( fun record -> 
  {{ 
    %s
  }} ) 
  |> Seq.toList
    """ page.AsTable idField.AsDBColumn idField.AsDBColumn page.AsType (dataReaderPropertiesTemplate page), page.AsVal)

(*

INSERT

*)

let insertColumns page =
  page.Fields
  |> List.filter (fun field -> field.FieldType <> ConfirmPassword && field.FieldType <> Id )
  |> List.map (fun field -> field.AsDBColumn)
  |> List.map (pad 2)
  |> flattenWith ","

let passwordTemplate page =
  let password = page.Fields |> List.tryFind (fun field -> field.FieldType = Password)
  match password with
  | Some(password) ->
    sprintf """
  let bCryptScheme = getBCryptScheme currentBCryptScheme
  let salt = BCrypt.GenerateSalt(bCryptScheme.WorkFactor)
  let password = BCrypt.HashPassword(%s.%s, salt)
    """ page.AsVal password.AsProperty
  | None -> ""

let insertValues page =
  let format field =
    sprintf "@%s" field.AsDBColumn

  page.Fields
  |> List.filter (fun field -> field.FieldType <> ConfirmPassword && field.FieldType <> Id )
  |> List.map format
  |> List.map (pad 2)
  |> flattenWith ","

let insertParamTemplate page field =
  if field.FieldType = Password
  then sprintf """%s password""" field.AsDBColumn
  else if field.FieldType = Referenced 
  then sprintf """int %s.%s.%sID""" page.AsVal field.AsProperty field.AsProperty
  else sprintf """%s.%s""" page.AsVal field.AsProperty

let insertParamsTemplate page =
  page.Fields
  |> List.filter (fun field -> field.FieldType <> Id && field.FieldType <> ConfirmPassword)
  |> List.map (insertParamTemplate page)
  |> List.map (pad 1)
  |> flattenWith ","

let insertTemplate site page =
  String.Format(
    sprintf """

[<Literal>]
let sql_insert_{0} = "
INSERT INTO %s
    (
  %s
    ) VALUES (
  %s
    ); SELECT SCOPE_IDENTITY()
  "
let insert_{0} ({0} : %s) =
  %s
    use command = new SqlCommandProvider<sql_insert_{0}, connectionString>(connectionString)
    command.Execute(%s) |> Seq.head |> Option.get |> int64
    """ page.AsTable (insertColumns page) (insertValues page) page.AsType  (passwordTemplate page) (insertParamsTemplate page), page.AsVal )

(*

UPDATE

*)

let updateColumns page =
  page.Fields
  |> List.filter (fun field -> field.FieldType <> ConfirmPassword && field.FieldType <> Id)
  |> List.map (fun field -> sprintf """%s = @%s""" field.AsDBColumn field.AsDBColumn)
  |> List.map (pad 1)
  |> flattenWith ","

let updateParamsTemplate page =
  page.Fields
  |> List.filter (fun field -> field.FieldType <> ConfirmPassword)
  |> List.map (fun field -> 
    if field.FieldType = Referenced 
      then sprintf """int %s.%s.%sID""" page.AsVal field.AsProperty field.AsProperty
      else sprintf """%s.%s""" page.AsVal field.AsProperty
  )
  |> List.map (pad 1)
  |> flattenWith ","

let updateTemplate site page =
  let idField = page.Fields |> List.find (fun field -> field.FieldType = Id)
  String.Format(
    sprintf """
[<Literal>]
let sql_update_{0} = "
  DECLARE @id int = @%s;
  UPDATE %s
  SET
  %s
  WHERE %s = @id;
  "
let update_{0} ({0} : %s) =
    use command = new SqlCommandProvider<sql_update_{0}, connectionString>(connectionString)
    command.Execute(int %s) |> ignore
    """  idField.AsDBColumn page.AsTable (updateColumns page) idField.AsDBColumn page.AsType  (updateParamsTemplate page), page.AsVal )

(*

SELECT

*)

let tryByIdTemplate site page =
  System.String.Format(
    sprintf """

let tryById_{0} (id:int64) =
  use cmd = new SqlCommandProvider<{0}QuerySQL, connectionString>(connectionString)
  cmd.Execute(int id) |> to{0} |> List.tryHead    
  
let get_{0}ById (id:int) =
  (tryById_{0} (int64 id)).Value
  
let get_{0}BySId (id:string) =
  (tryById_{0} (int64 (System.Int32.Parse(id)))).Value

    """, page.AsVal )

let selectManyTemplate site page =
  System.String.Format(
    sprintf """
let getMany_{0} ()=
  use cmd = new SqlCommandProvider<{0}QuerySQL, connectionString>(connectionString)
  cmd.Execute(0) |> to{0}

let getMany_{0}_Names =
  getMany_{0} () |> List.map ( fun p-> p.ToString() ) 
    """ , page.AsVal )

let selectManyWhereTemplate site page =
  sprintf """
let getManyWhere_%s field how value =
  getMany_%s ()
  """ page.AsVal page.AsVal

(*

Authentication

*)

let authenticateTemplate site page =
  sprintf """
[<Literal>]
let sql_authenticate = "
SELECT * FROM users
WHERE email = @email
"
let authenticate (%s : %s) =
  use cmd = new SqlCommandProvider<sql_authenticate, connectionString>(connectionString)
  
  let user =
    cmd.Execute(%s.Email)
    |> toLogin
    |> Seq.tryHead
  match user with
    | None -> None
    | Some(user) ->
      let verified = BCrypt.Verify(%s.Password, user.Password)
      if verified
      then Some(user)
      else None
  """ page.AsVal page.AsType  page.AsVal page.AsVal

(*

Everything else

*)

let createQueriesForPage site page =
  let rec createQueriesForPage pageMode =
    match pageMode with
    | CVELS     -> [Create; Edit; List; Search] |> List.map createQueriesForPage |> flatten
    | CVEL      -> [Create; Edit; List] |> List.map createQueriesForPage |> flatten
    | Create    -> insertTemplate site page
    | Edit      -> [updateTemplate site page; tryByIdTemplate site page] |> flatten
    | View      -> tryByIdTemplate site page
    | List      -> selectManyTemplate site page
    | Search    -> selectManyWhereTemplate site page
    | Register  -> insertTemplate site page
    | Login     -> authenticateTemplate site page
    | Jumbotron -> ""

  let queries = createQueriesForPage page.PageMode
  if needsDataReader page
  then sprintf "%s%s%s" (dataReaderTemplate page) System.Environment.NewLine queries
  else queries

let createQueries (site : Site) =
  site.Pages
  |> List.map (createQueriesForPage site)
  |> flatten

let generated_data_access_template connectionString guts =
  sprintf """module generated_data_access

open generated_types
open helper_general
open helper_ado
open FSharp.Data
open dsl
open BCrypt.Net

type BCryptScheme =
  {
    Id : int
    WorkFactor : int
  }

let bCryptSchemes : BCryptScheme list = [ { Id = 1; WorkFactor = 8; } ]
let getBCryptScheme id = bCryptSchemes |> List.find (fun scheme -> scheme.Id = id)
let currentBCryptScheme = 1

[<Literal>]
let connectionString = "%s"

%s""" connectionString guts
