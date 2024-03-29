﻿CREATE PROCEDURE [dbo].[spCreateGame]
	@gameId VARCHAR(15), 
	@scheduleID INT,
    @gameLink VARCHAR(50), 
    @gameType VARCHAR(20), 
    @season VARCHAR(12), 
    @gameDate DATE, 
    @abstractGameState VARCHAR(15), 
    @codedGameState VARCHAR(15), 
    @detailedState VARCHAR(50), 
    @statusCode VARCHAR(20), 
    @homeTeamId INT, 
    @awayTeamId INT, 
    @venueId INT, 
    @previewTitle VARCHAR(250), 
    @previewHeadline VARCHAR(300), 
    @previewSubHead VARCHAR(300), 
    @previewSeoDescription VARCHAR(400), 
    @previewUrl VARCHAR(250), 
    @previewMediaPhoto2568x1444 VARCHAR(350), 
    @previewMediaPhoto2208x1242 VARCHAR(350), 
    @previewMediaPhoto2048x1152 VARCHAR(350), 
    @previewMediaPhoto1704x960 VARCHAR(350), 
    @previewMediaPhoto1536x864 VARCHAR(350), 
    @previewMediaPhoto1284x722 VARCHAR(350), 
    @previewMediaPhoto1136x640 VARCHAR(350), 
    @previewMediaPhoto1024x576 VARCHAR(350), 
    @previewMediaPhoto960x540 VARCHAR(350), 
    @previewMediaPhoto768x432 VARCHAR(350), 
    @previewMediaPhoto640x360 VARCHAR(350), 
    @previewMediaPhoto568x320 VARCHAR(350), 
    @previewMediaPhoto372x210 VARCHAR(350), 
    @previewMediaPhoto320x180 VARCHAR(350), 
    @previewMediaPhoto248x140 VARCHAR(350), 
    @previewMediaPhoto124x70 VARCHAR(350), 
    @recapTitle VARCHAR(350), 
    @recapHeadline VARCHAR(350), 
    @recapSubHead VARCHAR(350), 
    @recapSeoDescription VARCHAR(350), 
    @recapUrl VARCHAR(350), 
    @recapMediaPhoto2568x1444 VARCHAR(350), 
    @recapMediaPhoto2208x1242 VARCHAR(350), 
    @recapMediaPhoto2048x1152 VARCHAR(350), 
    @recapMediaPhoto1704x960 VARCHAR(350), 
    @recapMediaPhoto1536x864 VARCHAR(350), 
    @recapMediaPhoto1284x722 VARCHAR(350), 
    @recapMediaPhoto1136x640 VARCHAR(350), 
    @recapMediaPhoto1024x576 VARCHAR(350), 
    @recapMediaPhoto960x540 VARCHAR(350), 
    @recapMediaPhoto768x432 VARCHAR(350), 
    @recapMediaPhoto640x360 VARCHAR(350), 
    @recapMediaPhoto568x320 VARCHAR(350), 
    @recapMediaPhoto372x210 VARCHAR(350), 
    @recapMediaPhoto320x180 VARCHAR(350), 
    @recapMediaPhoto248x140 VARCHAR(350), 
    @recapMediaPhoto124x70 VARCHAR(350), 
    @recapPlaybackFLASH_192K_320X180 VARCHAR(350), 
    @recapPlaybackFLASH_450K_400X224 VARCHAR(350), 
    @recapPlaybackFLASH_1200K_640X360 VARCHAR(350), 
    @recapPlaybackFLASH_1800K_960X540 VARCHAR(350), 
	@homeTotalGoals INT, 
    @homeTotalPIM INT, 
    @homeTotalShots INT, 
    @homePowerPlayPercentage DECIMAL(5, 2), 
    @homePowerPlayGoals INT, 
    @homePowerPlayOpportunities INT, 
    @homeFaceOffWinPercentage DECIMAL(5, 2), 
    @homeBlockedShots INT, 
    @homeTakeaways INT, 
    @homeGiveaways INT, 
    @awayTotalGoals INT, 
    @awayTotalPIM INT, 
    @awayTotalShots INT, 
    @awayPowerPlayPercentage DECIMAL(5, 2), 
    @awayPowerPlayGoals INT, 
    @awayPowerPlayOpportunities INT, 
    @awayFaceOffWinPercentage DECIMAL(5, 2), 
    @awayBlockedShots INT, 
    @awayTakeaways INT, 
    @awayGiveaways INT,  
    @homeCoachId VARCHAR(50), 
    @awayCoachId VARCHAR(50),
	@gameIdentity INT OUTPUT
AS
BEGIN

	IF NOT EXISTS (SELECT gameId FROM tblGame WHERE gameId = @gameId)
	BEGIN

		INSERT INTO tblGame(
								gameId, 
								scheduleId,
								gameLink, 
								gameType, 
								season, 
								gameDate, 
								abstractGameState, 
								codedGameState, 
								detailedState, 
								statusCode, 
								homeTeamId, 
								awayTeamId, 
								venueId, 
								previewTitle, 
								previewHeadline, 
								previewSubHead, 
								previewSeoDescription, 
								previewUrl, 
								previewMediaPhoto2568x1444, 
								previewMediaPhoto2208x1242, 
								previewMediaPhoto2048x1152, 
								previewMediaPhoto1704x960, 
								previewMediaPhoto1536x864, 
								previewMediaPhoto1284x722, 
								previewMediaPhoto1136x640, 
								previewMediaPhoto1024x576, 
								previewMediaPhoto960x540, 
								previewMediaPhoto768x432, 
								previewMediaPhoto640x360, 
								previewMediaPhoto568x320, 
								previewMediaPhoto372x210, 
								previewMediaPhoto320x180, 
								previewMediaPhoto248x140, 
								previewMediaPhoto124x70, 
								recapTitle, 
								recapHeadline, 
								recapSubHead, 
								recapSeoDescription, 
								recapUrl, 
								recapMediaPhoto2568x1444, 
								recapMediaPhoto2208x1242, 
								recapMediaPhoto2048x1152, 
								recapMediaPhoto1704x960, 
								recapMediaPhoto1536x864, 
								recapMediaPhoto1284x722, 
								recapMediaPhoto1136x640, 
								recapMediaPhoto1024x576, 
								recapMediaPhoto960x540, 
								recapMediaPhoto768x432, 
								recapMediaPhoto640x360, 
								recapMediaPhoto568x320, 
								recapMediaPhoto372x210, 
								recapMediaPhoto320x180, 
								recapMediaPhoto248x140, 
								recapMediaPhoto124x70, 
								recapPlaybackFLASH_192K_320X180, 
								recapPlaybackFLASH_450K_400X224, 
								recapPlaybackFLASH_1200K_640X360, 
								recapPlaybackFLASH_1800K_960X540, 
								homeTotalGoals, 
								homeTotalPIM, 
								homeTotalShots, 
								homePowerPlayPercentage, 
								homePowerPlayGoals, 
								homePowerPlayOpportunities, 
								homeFaceOffWinPercentage, 
								homeBlockedShots, 
								homeTakeaways, 
								homeGiveaways, 
								awayTotalGoals, 
								awayTotalPIM, 
								awayTotalShots, 
								awayPowerPlayPercentage, 
								awayPowerPlayGoals, 
								awayPowerPlayOpportunities, 
								awayFaceOffWinPercentage, 
								awayBlockedShots, 
								awayTakeaways, 
								awayGiveaways,  
								homeCoachId, 
								awayCoachId
		                       )
		VALUES (
				@gameId, 
				@scheduleID,
			    @gameLink, 
			    @gameType, 
			    @season, 
			    @gameDate, 
			    @abstractGameState, 
			    @codedGameState, 
			    @detailedState, 
			    @statusCode, 
			    @homeTeamId, 
				@awayTeamId, 
				@venueId, 
				@previewTitle, 
				@previewHeadline, 
				@previewSubHead, 
				@previewSeoDescription, 
				@previewUrl, 
				@previewMediaPhoto2568x1444, 
				@previewMediaPhoto2208x1242, 
				@previewMediaPhoto2048x1152, 
				@previewMediaPhoto1704x960, 
				@previewMediaPhoto1536x864, 
				@previewMediaPhoto1284x722, 
				@previewMediaPhoto1136x640, 
				@previewMediaPhoto1024x576, 
				@previewMediaPhoto960x540, 
				@previewMediaPhoto768x432, 
				@previewMediaPhoto640x360, 
				@previewMediaPhoto568x320, 
				@previewMediaPhoto372x210, 
				@previewMediaPhoto320x180, 
				@previewMediaPhoto248x140, 
				@previewMediaPhoto124x70, 
				@recapTitle, 
				@recapHeadline, 
				@recapSubHead, 
				@recapSeoDescription, 
				@recapUrl, 
				@recapMediaPhoto2568x1444, 
				@recapMediaPhoto2208x1242, 
				@recapMediaPhoto2048x1152, 
				@recapMediaPhoto1704x960, 
				@recapMediaPhoto1536x864, 
				@recapMediaPhoto1284x722, 
				@recapMediaPhoto1136x640, 
				@recapMediaPhoto1024x576, 
				@recapMediaPhoto960x540, 
				@recapMediaPhoto768x432, 
				@recapMediaPhoto640x360, 
				@recapMediaPhoto568x320, 
				@recapMediaPhoto372x210, 
				@recapMediaPhoto320x180, 
				@recapMediaPhoto248x140, 
				@recapMediaPhoto124x70, 
				@recapPlaybackFLASH_192K_320X180, 
				@recapPlaybackFLASH_450K_400X224, 
				@recapPlaybackFLASH_1200K_640X360, 
				@recapPlaybackFLASH_1800K_960X540, 
				@homeTotalGoals, 
				@homeTotalPIM, 
				@homeTotalShots, 
				@homePowerPlayPercentage, 
				@homePowerPlayGoals, 
				@homePowerPlayOpportunities, 
				@homeFaceOffWinPercentage, 
				@homeBlockedShots, 
				@homeTakeaways, 
				@homeGiveaways, 
				@awayTotalGoals, 
				@awayTotalPIM, 
				@awayTotalShots, 
				@awayPowerPlayPercentage, 
				@awayPowerPlayGoals, 
				@awayPowerPlayOpportunities, 
				@awayFaceOffWinPercentage, 
				@awayBlockedShots, 
				@awayTakeaways, 
				@awayGiveaways,  
				@homeCoachId, 
				@awayCoachId
			   )

			   SET @gameIdentity = SCOPE_IDENTITY()
	END
	ELSE
		SET @gameIdentity = -100
	

END
RETURN SELECT @gameIdentity