CREATE TABLE [dbo].[tblDivision]
(
	[Id] INT NOT NULL IDENTITY, 
    [divisionId] INT NOT NULL, 
    [divisionName] VARCHAR(100) NOT NULL, 
    [shortName] VARCHAR(50) NULL, 
    [abbreviation] VARCHAR(15) NULL, 
    [conferenceId] INT NOT NULL, 
    [active] VARCHAR(10) NOT NULL, 
    CONSTRAINT [PK_tblDivision] PRIMARY KEY ([divisionId])
)