

USE bobs_burgers
GO

CREATE TABLE users(
  user_id              int IDENTITY (1,1)   PRIMARY KEY NOT NULL,
  first_name           varchar(128)         NOT NULL,
  last_name            varchar(128)         NOT NULL,
  email                varchar(128)         NOT NULL,
  password             varchar(60)          NOT NULL
);
  

USE bobs_burgers
GO

CREATE TABLE orders(
  order_id             int IDENTITY (1,1)   PRIMARY KEY NOT NULL,
  name                 nvarchar(1024)       NOT NULL,
  food                 nvarchar(1024)       NULL,
  drinks               nvarchar(1024)       NULL,
  tip                  decimal(12, 2)       NULL,
  notes                ntext                NULL,
  delivery_date        datetime             NOT NULL,
  phone_number         varchar(15)          NOT NULL,
  address              nvarchar(1024)       NULL,
  city                 nvarchar(1024)       NULL,
  state                nvarchar(1024)       NULL,
  zip                  nvarchar(1024)       NULL,
  free_soda            smallint             NULL
);
  

USE bobs_burgers
GO

CREATE TABLE reserverations(
  reserveration_id     int IDENTITY (1,1)   PRIMARY KEY NOT NULL,
  name                 nvarchar(1024)       NOT NULL,
  date                 datetime             NOT NULL,
  phone_number         varchar(15)          NOT NULL
);
  


  
  