CREATE PROCEDURE [dbo].[spGetGameWithLatestGameEvent]
	@gameId varchar(15) 
AS
BEGIN

	DECLARE
		@gameEventId int

	SELECT @gameEventId = eventId 
	FROM tblGameEvent
	WHERE
		correspondingGameId = @gameId AND
		eventTimeStamp in (SELECT MAX(eventTimeStamp) FROM tblGameEvent where correspondingGameId = @gameId)


	SELECT 
			g.gameId, 
			g.scheduleId,
			g.gameLink, 
			g.gameType, 
			g.season, 
			g.gameDate, 
			g.abstractGameState, 
			g.codedGameState, 
			g.detailedState, 
			g.statusCode, 
			g.homeTeamId, 
			g.awayTeamId, 
			g.venueId, 
			g.previewTitle, 
			g.previewHeadline, 
			g.previewSubHead, 
			g.previewSeoDescription, 
			g.previewUrl, 
			g.previewMediaPhoto2568x1444, 
			g.previewMediaPhoto2208x1242, 
			g.previewMediaPhoto2048x1152, 
			g.previewMediaPhoto1704x960, 
			g.previewMediaPhoto1536x864, 
			g.previewMediaPhoto1284x722, 
			g.previewMediaPhoto1136x640, 
			g.previewMediaPhoto1024x576, 
			g.previewMediaPhoto960x540, 
			g.previewMediaPhoto768x432, 
			g.previewMediaPhoto640x360, 
			g.previewMediaPhoto568x320, 
			g.previewMediaPhoto372x210, 
			g.previewMediaPhoto320x180, 
			g.previewMediaPhoto248x140, 
			g.previewMediaPhoto124x70, 
			g.recapTitle, 
			g.recapHeadline, 
			g.recapSubHead, 
			g.recapSeoDescription, 
			g.recapUrl, 
			g.recapMediaPhoto2568x1444, 
			g.recapMediaPhoto2208x1242, 
			g.recapMediaPhoto2048x1152, 
			g.recapMediaPhoto1704x960, 
			g.recapMediaPhoto1536x864, 
			g.recapMediaPhoto1284x722, 
			g.recapMediaPhoto1136x640, 
			g.recapMediaPhoto1024x576, 
			g.recapMediaPhoto960x540, 
			g.recapMediaPhoto768x432, 
			g.recapMediaPhoto640x360, 
			g.recapMediaPhoto568x320, 
			g.recapMediaPhoto372x210, 
			g.recapMediaPhoto320x180, 
			g.recapMediaPhoto248x140, 
			g.recapMediaPhoto124x70, 
			g.recapPlaybackFLASH_192K_320X180, 
			g.recapPlaybackFLASH_450K_400X224, 
			g.recapPlaybackFLASH_1200K_640X360, 
			g.recapPlaybackFLASH_1800K_960X540, 
			g.homeTotalGoals, 
			g.homeTotalPIM, 
			g.homeTotalShots, 
			g.homePowerPlayPercentage, 
			g.homePowerPlayGoals, 
			g.homePowerPlayOpportunities, 
			g.homeFaceOffWinPercentage, 
			g.homeBlockedShots, 
			g.homeTakeaways, 
			g.homeGiveaways, 
			g.awayTotalGoals, 
			g.awayTotalPIM, 
			g.awayTotalShots, 
			g.awayPowerPlayPercentage, 
			g.awayPowerPlayGoals, 
			g.awayPowerPlayOpportunities, 
			g.awayFaceOffWinPercentage, 
			g.awayBlockedShots, 
			g.awayTakeaways, 
			g.awayGiveaways,  
			g.homeCoachId, 
			g.awayCoachId,
			ge.eventId,
			ge.eventType,
			ge.eventCode,
			ge.eventTypeId,
			ge.eventDescription,
			ge.eventSecondaryType,
			ge.eventIdX,
			ge.periodId,
			ge.[period],
			ge.periodType,
			ge.periodOrdinalNumber,
			ge.periodTimeMinutes,
			ge.periodTimeSeconds,
			ge.periodTimeRemainingMinutes,
			ge.periodTimeRemainingSeconds,
			ge.eventTimeStamp,
			ge.goalsAway AS latestGoalsAway,
			ge.goalsHome AS latestGoalsHome,
			ge.xCoordinate,
			ge.yCoordinate,
			ge.teamId,
			home.teamCity AS homeTeamCity,
			home.teamName AS homeTeamName,
			home.teamAbbreviation AS homeTeamAbbreviation,
			home.teamCityDemo AS homeTeamCityDemo,
			home.teamNameDemo AS homeTeamNameDemo,
			away.teamCity AS awayTeamCity,
			away.teamName AS awayTeamName,
			away.teamAbbreviation AS awayTeamAbbreviation,
			away.teamCityDemo AS awayTeamCityDemo,
			away.teamNameDemo AS awayTeamNameDemo,
			v.venueName,
			v.venueCity,
			v.venueStateProvince,
			v.venueCountry,
			v.venueLatitude,
			v.venueLongitude
		FROM tblGame g, tblGameEvent ge, tblTeam home, tblTeam away, tblVenue v
		WHERE 
			g.gameId = @gameId AND
			ge.correspondingGameId = g.gameId AND
			ge.eventId = @gameEventId AND
			g.homeTeamId = home.nhlTeamId AND
			g.awayTeamId = away.nhlTeamId AND
			g.venueId = v.venueId

		    
END
RETURN 0
