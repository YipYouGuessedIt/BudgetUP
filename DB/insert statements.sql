use dbo
go

insert into Titles values ('Mr');
insert into Titles values ('Mrs');
insert into Titles values ('Miss');
insert into Titles values ('Dr');

insert into Roles values ('Teacher');
insert into Roles values ('Assistant');
insert into Roles values ('Admin');
insert into Roles values ('Tutor');

insert into Faculties values ('EBIT');
insert into Faculties values ('EMS');
insert into Faculties values ('BIO');
insert into Faculties values ('COOKS');

insert into Users values (1,'Rendani','Kruger',2,1,1);
insert into Users values (4,'Niel','Croft',1,1,1);
insert into Users values (2,'Lisa','Economic',4,4,1);
insert into Users values (3,'Amy','loops',3,2,1);

insert into UserCredentials values ('rendani619@up.co.za','1234',1);
insert into UserCredentials values ('croft@up.co.za','mobile',2);
insert into UserCredentials values ('Economics@up.co.za','ems',3);
insert into UserCredentials values ('AmyLoops@tuks.co.za','admin',4);

insert into EmailDomains values ('tuks.co.za');
insert into EmailDomains values ('up.co.za');

use dbo
go

insert into Admin_SysSettings values(0.06,0.10,0.25,24);
use dbo
go

insert into Project_Settings values(0.06,0.10,0.25);
use dbo
go

insert into projects values (1,'Budgetup','Make a budget app',13,1,'5/09/12','5/09/12');
insert into projects values (2,'Website','Basic web site',13,1,1);
insert into projects values (4,'Admin app','App for admins so that they can discuss adminy stuff',13,1,1);

use dbo
go

insert into Objectives values (1,'SetUp DB');
insert into Objectives values (1,'PrezTier');
insert into Objectives values (1,'BussTier');
insert into Objectives values (1,'UX testing');

use dbo
go
insert into Activities values(2,'Make files','5/09/12','5/09/12');
insert into Activities values(2,'delegate tables','5/09/12','5/09/12');
insert into Activities values(2,'Show worth','5/09/12','5/09/12');

use dbo
go

insert into Notes values ('Note1');
insert into Notes values ('Note2');
insert into Notes values ('Note2.1');
insert into Notes values ('Note3');


insert into Incomes values(1,'Mic',1000.00,1);
insert into Incomes values(1,'Dur',2000.00,2);
insert into Incomes values(1,'Ren',3000.00,3);

insert into BursaryTypes values('Honours',20000.00,1);
insert into BursaryTypes values('Masters',40000.00,2);

insert into Bursaries values(1,1,1);

use dbo
go

insert into Expenses values (1,2000.00,1);
insert into Expenses values (1,2000.00,1);
insert into Expenses values (1,2000.00,1);
insert into Expenses values (1,2000.00,1);
insert into Expenses values (1,2000.00,1);

use dbo
go
insert into PostLevels values('Lect','474738');
insert into PostLevels values('Assis Lect','474');
insert into UPStaffMembers values (1,3,1,1);

insert into Travels values (4,4,'5/09/12','perth',2);

insert into Operation_Type values ('op 1');
insert into Operation_Type values ('op 2');
insert into Operationals values (3,1,4,100.00,3);

insert into Equipments values ('driller',4);

insert into Contractors values ('Contracter steve',5)







