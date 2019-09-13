CREATE PROCEDURE [dbo].[spCreateTeam]
	@nhlTeamId INT,
    @teamName VARCHAR(50),
    @teamCity VARCHAR(50),
    @teamAbbreviation VARCHAR(15),
    @teamVenueId INT,
    @firstYearOfPlay INT,
    @divisionId INT,
    @webSite VARCHAR(150),
    @teamIdentity INT OUTPUT
AS
BEGIN
    IF NOT EXISTS (SELECT nhlTeamId FROM tblTeam WHERE  nhlTeamId = @nhlTeamId)
	BEGIN
		INSERT INTO tblTeam (nhlTeamId, teamName, teamCity, teamAbbreviation, teamVenueId, firstYearOfPlay, divisionId, webSite)
		VALUES (@nhlTeamId, @teamName, @teamCity, @teamAbbreviation, @teamVenueId, @firstYearOfPlay, @divisionId, @webSite)

		SET @teamIdentity = SCOPE_IDENTITY()
	END
	ELSE 
		SET @teamIdentity = -100
	

END
RETURN SELECT @teamIdentity