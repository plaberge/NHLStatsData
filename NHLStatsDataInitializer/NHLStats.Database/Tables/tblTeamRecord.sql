CREATE TABLE [dbo].[tblTeamRecord]
(
	[Id] INT NOT NULL IDENTITY, 
    [nhlTeamId] INT NOT NULL, 
    [season] INT NOT NULL, 
    [asOfDate] DATE NOT NULL, 
    [wins] INT NOT NULL, 
    [losses] INT NOT NULL, 
    [overtimeLosses] INT NOT NULL, 
    [goalsScored] INT NOT NULL, 
    [goalsAgainst] INT NOT NULL, 
    [points] INT NOT NULL, 
    [divisionRank] INT NULL, 
    [leagueRank] INT NULL, 
    [wildcardRank] INT NULL, 
    [row] VARCHAR(50) NULL, 
    [gamesPlayed] INT NULL, 
    [streakType] VARCHAR(20) NULL, 
    [streakNumber] INT NULL, 
    [streakCode] VARCHAR(15) NULL, 
    [lastUpdated] VARCHAR(50) NULL, 
    CONSTRAINT [PK_tblTeamRecord] PRIMARY KEY ([nhlTeamId], [season], [asOfDate])
)
