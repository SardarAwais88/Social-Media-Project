create table Registration(ID INT Identity(1,1)primary key, Name Varchar(100),Email Varchar(100),Password Varchar(100)
,PhoneNo Varchar(100), IsActive	int, IsApproved int
);
create table Article(ID INT Identity(1,1)primary key, Title Varchar(100),Content Varchar(100),Email Varchar(100)
,Image Varchar(100), IsActive	int, IsApproved int
);
create table News(ID INT Identity(1,1)primary key, Title Varchar(100),Content Varchar(100),Email Varchar(100)
,Image Varchar(100), IsActive	int, CreatedOn DateTime
);
create table Events(ID INT Identity(1,1)primary key, Title Varchar(100),Content Varchar(100),Email Varchar(100)
,Image Varchar(100), IsActive	int, CreatedOn DateTime
);

create table Staff(ID INT Identity(1,1)primary key, Name Varchar(100),Email Varchar(100),Password Varchar(100)
, IsActive	int
);

Select * from Registration;
select * from Article;
Select * from News where IsActive=1;
SELECT * from Events;