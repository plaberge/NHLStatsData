CREATE TABLE [dbo].[tblGameEvent]
(
	[Id] INT NOT NULL IDENTITY, 
	[eventId] INT NOT NULL,
    [correspondingGameId] INT NOT NULL, 
    [eventType] VARCHAR(25) NULL, 
    [eventCode] VARCHAR(25) NULL, 
    [eventTypeId] VARCHAR(25) NULL, 
    [eventDescription] VARCHAR(300) NULL, 
    [eventSecondaryType] VARCHAR(25) NULL, 
    [eventIdX] VARCHAR(15) NULL,
	[periodId] int NULL,
    [period] INT NULL, 
    [periodType] VARCHAR(50) NULL, 
    [periodOrdinalNumber] VARCHAR(10) NULL, 
    [periodTimeMinutes] INT NULL, 
    [periodTimeSeconds] INT NULL, 
	[periodTimeRemainingMinutes] INT NULL,
	[periodTimeRemainingSeconds] INT NULL,
    [eventTimeStamp] DATETIME NULL, 
    [goalsAway] INT NULL, 
    [goalsHome] INT NULL, 
    [xCoordinate] DECIMAL(5, 2) NULL, 
    [yCoordinate] DECIMAL(5, 2) NULL, 
    [teamId] INT NULL
     
)

GO

CREATE NONCLUSTERED INDEX [index_tblGameEvent_01] ON [dbo].[tblGameEvent] ([correspondingGameId], [eventId]) WITH (ONLINE = ON)

GO