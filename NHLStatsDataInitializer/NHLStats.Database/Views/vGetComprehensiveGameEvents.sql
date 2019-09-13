CREATE VIEW [dbo].[vGetComprehensiveGameEvents]
	AS SELECT a.Id,
			  a.eventId,
			  a.correspondingGameId,
			  a.eventType, 
			  a.eventCode,
			  a.eventTypeId,
			  a.eventDescription,
			  a.eventSecondaryType, 
			  a.eventIdX,
			  a.periodId,
			  a.period,
			  a.periodType,
			  a.periodOrdinalNumber,
			  a.periodTimeMinutes,
			  a.periodTimeSeconds,
			  a.periodTimeRemainingMinutes,
			  a.periodTimeRemainingSeconds,
			  a.eventTimeStamp,
			  a.goalsAway,
			  a.goalsHome,
			  a.xCoordinate,
			  a.yCoordinate,
			  a.teamId,
			  b.teamCity,
			  b.teamName,
			  b.teamAbbreviation,
			  b.teamCityDemo,
			  b.teamNameDemo,
			  c.gameDate,
			  c.season
			  
	FROM tblGameEvent a, tblTeam b, tblGame c
	WHERE
		a.teamId = b.nhlTeamId AND
		a.correspondingGameId = c.gameId
