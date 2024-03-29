﻿CREATE TABLE [dbo].[tblGame]
(
	[Id] INT NOT NULL  IDENTITY, 
    [gameId] VARCHAR(15) NOT NULL,
	[scheduleId] INT,
    [gameLink] VARCHAR(50) NULL, 
    [gameType] VARCHAR(20) NULL, 
    [season] VARCHAR(12) NOT NULL, 
    [gameDate] DATE NOT NULL, 
    [abstractGameState] VARCHAR(15) NULL, 
    [codedGameState] VARCHAR(15) NULL, 
    [detailedState] VARCHAR(50) NULL, 
    [statusCode] VARCHAR(20) NULL, 
    [homeTeamId] INT NOT NULL, 
    [awayTeamId] INT NOT NULL, 
    [venueId] INT NULL, 
    [previewTitle] VARCHAR(250) NULL, 
    [previewHeadline] VARCHAR(300) NULL, 
    [previewSubHead] VARCHAR(300) NULL, 
    [previewSeoDescription] VARCHAR(400) NULL, 
    [previewUrl] VARCHAR(250) NULL, 
    [previewMediaPhoto2568x1444] VARCHAR(350) NULL, 
    [previewMediaPhoto2208x1242] VARCHAR(350) NULL, 
    [previewMediaPhoto2048x1152] VARCHAR(350) NULL, 
    [previewMediaPhoto1704x960] VARCHAR(350) NULL, 
    [previewMediaPhoto1536x864] VARCHAR(350) NULL, 
    [previewMediaPhoto1284x722] VARCHAR(350) NULL, 
    [previewMediaPhoto1136x640] VARCHAR(350) NULL, 
    [previewMediaPhoto1024x576] VARCHAR(350) NULL, 
    [previewMediaPhoto960x540] VARCHAR(350) NULL, 
    [previewMediaPhoto768x432] VARCHAR(350) NULL, 
    [previewMediaPhoto640x360] VARCHAR(350) NULL, 
    [previewMediaPhoto568x320] VARCHAR(350) NULL, 
    [previewMediaPhoto372x210] VARCHAR(350) NULL, 
    [previewMediaPhoto320x180] VARCHAR(350) NULL, 
    [previewMediaPhoto248x140] VARCHAR(350) NULL, 
    [previewMediaPhoto124x70] VARCHAR(350) NULL, 
    [recapTitle] VARCHAR(350) NULL, 
    [recapHeadline] VARCHAR(350) NULL, 
    [recapSubHead] VARCHAR(350) NULL, 
    [recapSeoDescription] VARCHAR(350) NULL, 
    [recapUrl] VARCHAR(350) NULL, 
    [recapMediaPhoto2568x1444] VARCHAR(350) NULL, 
    [recapMediaPhoto2208x1242] VARCHAR(350) NULL, 
    [recapMediaPhoto2048x1152] VARCHAR(350) NULL, 
    [recapMediaPhoto1704x960] VARCHAR(350) NULL, 
    [recapMediaPhoto1536x864] VARCHAR(350) NULL, 
    [recapMediaPhoto1284x722] VARCHAR(350) NULL, 
    [recapMediaPhoto1136x640] VARCHAR(350) NULL, 
    [recapMediaPhoto1024x576] VARCHAR(350) NULL, 
    [recapMediaPhoto960x540] VARCHAR(350) NULL, 
    [recapMediaPhoto768x432] VARCHAR(350) NULL, 
    [recapMediaPhoto640x360] VARCHAR(350) NULL, 
    [recapMediaPhoto568x320] VARCHAR(350) NULL, 
    [recapMediaPhoto372x210] VARCHAR(350) NULL, 
    [recapMediaPhoto320x180] VARCHAR(350) NULL, 
    [recapMediaPhoto248x140] VARCHAR(350) NULL, 
    [recapMediaPhoto124x70] VARCHAR(350) NULL, 
    [recapPlaybackFLASH_192K_320X180] VARCHAR(350) NULL, 
    [recapPlaybackFLASH_450K_400X224] VARCHAR(350) NULL, 
    [recapPlaybackFLASH_1200K_640X360] VARCHAR(350) NULL, 
    [recapPlaybackFLASH_1800K_960X540] VARCHAR(350) NULL, 
    [homeTotalGoals] INT NULL, 
    [homeTotalPIM] INT NULL, 
    [homeTotalShots] INT NULL, 
    [homePowerPlayPercentage] DECIMAL(5, 2) NULL, 
    [homePowerPlayGoals] INT NULL, 
    [homePowerPlayOpportunities] INT NULL, 
    [homeFaceOffWinPercentage] DECIMAL(5, 2) NULL, 
    [homeBlockedShots] INT NULL, 
    [homeTakeaways] INT NULL, 
    [homeGiveaways] INT NULL, 
    [awayTotalGoals] INT NULL, 
    [awayTotalPIM] INT NULL, 
    [awayTotalShots] INT NULL, 
    [awayPowerPlayPercentage] DECIMAL(5, 2) NULL, 
    [awayPowerPlayGoals] INT NULL, 
    [awayPowerPlayOpportunities] INT NULL, 
    [awayFaceOffWinPercentage] DECIMAL(5, 2) NULL, 
    [awayBlockedShots] INT NULL, 
    [awayTakeaways] INT NULL, 
    [awayGiveaways] INT NULL,  
    [homeCoachId] VARCHAR(50) NULL, 
    [awayCoachId] VARCHAR(50) NULL, 
    PRIMARY KEY ([Id])
)
