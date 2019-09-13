CREATE VIEW [dbo].[vGetGamesByScheduleDate]
AS
	SELECT s.Id AS ScheduleId,
	       s.season,
		   s.scheduleDate,
		   away.nhlTeamId as awayNHLTeamId,
		   away.teamCity as awayTeamCity,
		   away.teamCityDemo as awayDemoTeamCity,
		   away.teamName as awayTeamName,
		   away.teamNameDemo as awayDemoTeamName,
		   home.nhlTeamId as homeNHLTeamId,
		   home.teamCity as homeTeamCity,
		   home.teamCityDemo as homeDemoTeamCity,
		   home.teamName as homeTeamName,
		   home.teamNameDemo as homeDemoTeamName,
		   g.abstractGameState,
		   g.detailedState,
		   g.homeTotalGoals,
		   g.awayTotalGoals
	FROM [tblSchedule] s, [tblGame] g, [tblTeam] away, [tblTeam] home
	WHERE
	   g.scheduleId = s.Id AND
	   g.awayTeamId = away.nhlTeamId AND
	   g.homeTeamId = home.nhlTeamId
		
