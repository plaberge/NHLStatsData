CREATE TABLE [dbo].[tblTeam]
(
	[Id] INT NOT NULL IDENTITY, 
    [nhlTeamId] INT NOT NULL, 
    [teamName] VARCHAR(50) NOT NULL, 
	[teamNameDemo] VARCHAR(50) NULL,
    [teamCity] VARCHAR(50) NOT NULL, 
	[teamCityDemo] VARCHAR(50) NULL,
    [teamAbbreviation] VARCHAR(15) NULL, 
    [teamVenueId] INT NULL, 
    [firstYearOfPlay] INT NULL, 
    [divisionId] INT NULL, 
    [webSite] VARCHAR(150) NULL
)