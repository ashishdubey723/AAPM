CREATE TABLE RoleMaster
(
RoleId INT Primary Key NOT NULL,
RoleName NVARCHAR(20)
)

GO
INSERT INTO RoleMaster VALUES(1,'Admin')
INSERT INTO RoleMaster VALUES(2,'Supervisor')
INSERT INTO RoleMaster VALUES(3,'Employee')
INSERT INTO RoleMaster VALUES(4,'Agent')


GO

CREATE TABLE AppUser
(
UserId BigInt Primary Key Identity(1,1),
FirstName NVARCHAR(50),
MiddleName NVARCHAR(50),
LastName NVARCHAR(50),
Email NVARCHAR(50),
LoginId NVARCHAR(50),
LoginPassword NVARCHAR(MAX),
AddressLine NVARCHAR(MAX),
Phone NVARCHAR(MAX),
IsActive BIT,
RoleId INT NOT NULL
)

GO
INSERT INTO AppUser VALUES('ALBERT',NULL,'EINSTINE','elbert@gmail.com','albert001','albert001','test address','215485785',1,1)
INSERT INTO AppUser VALUES('ASHISH','KUMAR','DUBEY','ashish@gmail.com','ashishd','ashishd','test1 address','2125698547',1,2)
INSERT INTO AppUser VALUES('MUKESH','KUMAR','DUBEY','mukesh@gmail.com','mukeshd','mukeshd','test2 address','256987587',1,4)
