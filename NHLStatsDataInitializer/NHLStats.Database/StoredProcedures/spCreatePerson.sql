CREATE PROCEDURE [dbo].[spCreatePerson]
	@personId VARCHAR(50), 
    @fullName VARCHAR(250),
    @role VARCHAR(25),
    @subRole VARCHAR(25),
    @personIdentity INT OUTPUT
AS
BEGIN
    IF NOT EXISTS (SELECT personId FROM tblPerson WHERE fullName = @fullName AND tblPerson.[role] = @role)
	BEGIN
		INSERT INTO tblPerson (personId, fullName, [role], subRole)
		VALUES (@personId, @fullName, @role, @subRole)

		SET @personIdentity = SCOPE_IDENTITY()
	END
	ELSE 
		SET @personIdentity = (SELECT Id FROM tblPerson WHERE fullName = @fullName AND tblPerson.[role] = @role)
	

END
RETURN SELECT @personIdentity