CREATE VIEW [dbo].[vGetDivisionList]
	AS SELECT Id, divisionId, divisionName, shortName, abbreviation, conferenceId, active FROM tblDivision
