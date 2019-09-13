CREATE PROCEDURE [dbo].[spCreateDivision]
	@divisionId INT, 
    @divisionName VARCHAR(100), 
    @shortName VARCHAR(50), 
    @abbreviation VARCHAR(15), 
    @conferenceId INT, 
    @active VARCHAR(10),
	@divisionIdentity INT OUTPUT
AS
BEGIN

	IF NOT EXISTS (SELECT divisionId FROM tblDivision WHERE divisionId = @divisionId)
	BEGIN

		INSERT INTO tblDivision (divisionId, divisionName, shortName, abbreviation, conferenceId, active)
		VALUES (@divisionId, @divisionName, @shortName, @abbreviation, @conferenceId, @active)

		SET @divisionIdentity = SCOPE_IDENTITY()

	END
	ELSE SET @divisionIdentity = -100
	

END
RETURN SELECT @divisionIdentity