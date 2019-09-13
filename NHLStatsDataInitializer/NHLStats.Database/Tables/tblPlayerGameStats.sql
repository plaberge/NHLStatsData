CREATE TABLE [dbo].[tblPlayerGameStats]
(
	[Id] INT NOT NULL IDENTITY, 
    [gameId] INT NOT NULL, 
    [playerId] INT NOT NULL, 
    [position] VARCHAR(15) NULL, 
    [timeOnIce] INT NULL, 
    [assists] INT NULL, 
    [goals] INT NULL, 
    [shots] INT NULL, 
    [hits] INT NULL, 
    [powerPlayGoals] INT NULL, 
    [powerPlayAssists] INT NULL, 
    [penaltyMinutes] INT NULL, 
    [faceoffWins] INT NULL, 
    [faceoffWinPercentage] DECIMAL(18, 2) NULL, 
    [faceoffsTaken] INT NULL, 
    [takeaways] INT NULL, 
    [giveaways] INT NULL, 
    [shorthandedGoals] INT NULL, 
    [shorthandedAssists] INT NULL, 
    [blocked] INT NULL, 
    [plusMinus] INT NULL, 
    [evenTimeOnIce] INT NULL, 
    [powerPlayTimeOnIce] INT NULL, 
    [shorthandedTimeOnIce] INT NULL, 
    [goalieTimeOnIce] INT NULL, 
    [shotsFaced] INT NULL, 
    [shotsSaved] INT NULL, 
    [powerPlayShotsSaved] INT NULL, 
    [shorthandedShotsSaved] INT NULL, 
    [evenSaved] INT NULL, 
    [shorthandedShotsAgainst] INT NULL, 
    [evenShotsAgainst] INT NULL, 
    [powerPlayShotsAgainst] INT NULL, 
    [decision] VARCHAR(10) NULL, 
    [savePercentage] DECIMAL(18, 2) NULL, 
    [evenSavePercentage] DECIMAL(18, 2) NULL, 
    [powerPlaySavePercentage] DECIMAL(18, 2) NULL, 
    [shorthandedSavePercentage] DECIMAL(18, 2) NULL
)

GO

CREATE NONCLUSTERED INDEX [nci_wi_tblPlayerGameStats_01] ON [dbo].[tblPlayerGameStats] ([gameId], [playerId]) WITH (ONLINE = ON)

GO