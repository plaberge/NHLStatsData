CREATE TABLE [dbo].[tblPeriod]
(
	[periodId] INT NOT NULL IDENTITY, 
    [gameId] VARCHAR(50) NULL, 
    [periodType] VARCHAR(15) NULL, 
    [periodTimeStart] TIME NULL, 
    [periodTimeEnd] TIME NULL, 
    [periodNum] VARCHAR(2) NULL, 
    [periodNumOrd] VARCHAR(15) NULL, 
    [homeTeamId] INT NULL, 
    [homeGoals] INT NULL, 
    [homeShotsOnGoal] INT NULL, 
    [homeRinkSide] VARCHAR(7) NULL, 
    [awayTeamId] INT NULL, 
    [awayGoals] INT NULL, 
    [awayShotsOnGoal] INT NULL, 
    [awayRinkSide] VARCHAR(7) NULL
    
)
