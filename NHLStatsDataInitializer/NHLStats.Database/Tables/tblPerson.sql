CREATE TABLE [dbo].[tblPerson]
(
	[Id] INT NOT NULL IDENTITY, 
    [personId] VARCHAR(50) NOT NULL, 
    [fullName] VARCHAR(250) NOT NULL, 
    [role] VARCHAR(25) NOT NULL, 
    [subRole] VARCHAR(25) NULL
)
