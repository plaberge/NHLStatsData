CREATE PROCEDURE [dbo].[spGetScheduleID]
	@scheduleDate DATE,
	@scheduleID INT OUTPUT
AS
BEGIN
	SELECT @scheduleID = Id FROM tblSchedule WHERE scheduleDate = @scheduleDate
	select @scheduleID
END
RETURN 0