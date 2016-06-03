

USE office_suppliers_details
GO

CREATE TABLE groups(
  group_id             int IDENTITY (1,1)   PRIMARY KEY NOT NULL,
  name                 nvarchar(1024)       NOT NULL
);
  

USE office_suppliers_details
GO

CREATE TABLE suppliers(
  supplier_id          int IDENTITY (1,1)   PRIMARY KEY NOT NULL,
  name                 nvarchar(1024)       NOT NULL,
  address              ntext                NOT NULL,
  email                varchar(128)         NOT NULL,
  phone_number         varchar(15)          NOT NULL
);
  

USE office_suppliers_details
GO

CREATE TABLE supplieringroups(
  supplieringroup_id   int IDENTITY (1,1)   PRIMARY KEY NOT NULL,
  group_id             int                  REFERENCES [groups] (group_id) NOT NULL,
  supplier_id          int                  REFERENCES [suppliers] (supplier_id) NOT NULL
);
  


  
  