CREATE VIEW [dbo].[vGetConferenceList]
	AS SELECT Id, conferenceId, conferenceName, conferenceAbbreviation, shortName, active FROM tblConference
