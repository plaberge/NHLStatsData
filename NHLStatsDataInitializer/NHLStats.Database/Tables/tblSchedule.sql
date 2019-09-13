CREATE TABLE [dbo].[tblSchedule]
(
	[Id] INT NOT NULL IDENTITY, 
    [scheduleDate] DATE NULL, 
    [season] VARCHAR(10) NULL, 
    [totalItems] INT NULL, 
    [totalEvents] INT NULL, 
    [totalGames] INT NULL, 
	[totalMatches] INT NULL

)
