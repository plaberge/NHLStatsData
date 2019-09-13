CREATE FUNCTION [dbo].[fnGetScheduleIdFromDate]
(
	@scheduleDate DATETIME
)
RETURNS INT
AS
BEGIN

    DECLARE
		@scheduleID INT

	SELECT @scheduleID = Id 
	FROM tblSchedule
	WHERE
		scheduleDate = @scheduleDate

	RETURN @scheduleID
END
