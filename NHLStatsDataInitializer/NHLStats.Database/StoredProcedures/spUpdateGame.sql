CREATE PROCEDURE [dbo].[spUpdateGame]
	@scheduleID INT,
	@gameId INT
AS
	UPDATE tblGame SET scheduleId = @scheduleID WHERE gameId = @gameId
RETURN 0