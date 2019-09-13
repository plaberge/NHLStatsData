CREATE PROCEDURE [dbo].[spCreateGameOfficials]
	@personId VARCHAR(50), 
    @gameId VARCHAR(15),
	@gameOfficialsIdentity INT OUTPUT
AS
BEGIN
    IF NOT EXISTS (SELECT personId FROM tblGameOfficials WHERE personId = @personId AND gameId = @gameId)
	BEGIN
		INSERT INTO tblGameOfficials (personId, gameId)
		VALUES (@personId, @gameId)

		SET @gameOfficialsIdentity = SCOPE_IDENTITY()
	END
	ELSE 
		SET @gameOfficialsIdentity = -100
	

END
RETURN SELECT @gameOfficialsIdentity