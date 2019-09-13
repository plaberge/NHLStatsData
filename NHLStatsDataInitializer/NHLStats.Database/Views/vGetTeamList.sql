CREATE VIEW [dbo].[vGetTeamList]
	AS SELECT Id, nhlTeamId, teamName, teamCity, teamAbbreviation, teamVenueId, firstYearOfPlay, divisionId, webSite FROM tblTeam
